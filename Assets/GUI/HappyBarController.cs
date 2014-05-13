using UnityEngine;
using System.Collections;

public class HappyBarController : MonoBehaviour {
	public int percentage;
	public int edges = 205;
	public Gradient gradient;
	public int maxPoints;
	public GameOverScript gameOverScript;

	public HappyBarGlow glow;
	public GUITexture tip;
	public int tipX = -11;
	public int tipY = -8;
	public int tipW = 22;
	public int tipH = 22;

	public GUITexture sadBar;

	public int score;
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
		score += addedScore - normal;
		percentage = (int)(((float)score / (float)maxPoints)*100);
		updateBar ();
	}
	private void updateBar()
	{
		percentage = Mathf.Clamp (percentage, -100, 100);
		RectOffset tempOffset = new RectOffset(0, 0, -(percentage*edges)/100, 0);
		tip.pixelInset = new Rect(tipX + (percentage*edges)/100, tipY, tipW, tipH);

		float gradPos = percentage;
		gradPos += 100f;
		gradPos /= 200.0f;
		gameObject.GetComponent<GUITexture>().color = gradient.Evaluate(gradPos);
		tip.color = gradient.Evaluate(gradPos);

		if(percentage > 0)
		{
			gameObject.GetComponent<GUITexture>().border = tempOffset;
			sadBar.border = new RectOffset(0, 0, 0, 0);
		}
		else
		{
			gameObject.GetComponent<GUITexture>().border = new RectOffset(0, 0, 0, 0);
			sadBar.border = tempOffset;
		}
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
			if(percentage <= -99)
			{
				gameOverScript.triggerGameOver();
			}
		}
		else
		{
			glow.deactivate();
		}
	}
}
