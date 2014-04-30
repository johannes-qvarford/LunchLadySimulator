using UnityEngine;
using System.Collections;

public class HappyBarController : MonoBehaviour {
	public int percentage;
	public int edges = 205;
	public Gradient gradient;
	public int maxPoints;

	public HappyBarGlow glow;
	public GUITexture tip;
	public int tipX = -11;
	public int tipY = -8;
	public int tipW = 22;
	public int tipH = 22;

	private int score;
	private int lastValue = 101;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(lastValue == percentage)
		{
			return;
		}
		lastValue = percentage;
		//Only update the bar if changes has ben made.
		updateBar ();
	}
	public void addScore(int addedScore, int normal)
	{
		score += addedScore;
		percentage = (int)(((float)score / (float)maxPoints) * 50.0f);
		percentage += 50;
		updateBar ();
	}
	private void updateBar()
	{
		percentage = Mathf.Clamp (percentage, -100, 100);
		RectOffset tempOffset = new RectOffset((percentage*edges)/100, 0, 0, 0);
		tip.pixelInset = new Rect(tipX + (percentage*edges)/100, tipY, tipW, tipH);

		float gradPos = percentage;
		gradPos += 100f;
		gradPos /= 200.0f;
		gameObject.GetComponent<GUITexture>().color = gradient.Evaluate(gradPos);
		tip.color = gradient.Evaluate(gradPos);

		gameObject.GetComponent<GUITexture>().border = tempOffset;
		checkGlow ();
	}
	private void checkGlow()
	{
		if(percentage >= 80)
		{
			glow.activateHigh();
		}
		else if(percentage <= -80)
		{
			glow.activateLow();
		}
		else
		{
			glow.deactivate();
		}
	}
}
