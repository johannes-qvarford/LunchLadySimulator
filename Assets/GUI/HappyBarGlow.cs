using UnityEngine;
using System.Collections;

public class HappyBarGlow : MonoBehaviour {
	public Color lowColor;
	public Color highColor;
	public float frequens;
	public float centerAlfa;
	public float varyingAlfa;

	private enum State{Low, High, Off};
	private State state;
	// Use this for initialization
	void Start () {
		deactivate ();
	}
	
	// Update is called once per frame
	void Update () {

		if(state == State.Off)
		{
			return;
		}
		float newAlfa = centerAlfa + Mathf.Sin (Time.time * frequens) * varyingAlfa;
		Color newColor;
		if(state == State.High)
		{
			newColor = highColor;
		}
		else
		{
			newColor = lowColor;
		}
		newColor.a = newAlfa;
		gameObject.guiTexture.color = newColor;
	}
	public void activateHigh()
	{
		state = State.High;
		gameObject.guiTexture.enabled = (true);
	}
	public void activateLow()
	{
		state = State.Low;
		gameObject.guiTexture.enabled = (true);
	}
	public void deactivate()
	{
		state = State.Off;
		gameObject.guiTexture.color = new Color (0, 0, 0, 0);
		gameObject.guiTexture.enabled = (false);

	}

}
