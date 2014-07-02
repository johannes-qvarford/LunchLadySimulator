using UnityEngine;
using System.Collections;

/**
  * Class for a fading texture around the happy bar.
  * The fading gives the impression of "glow", 
  *  and it's activated when happiness value of happy bar is very low or very high.
  *
  * TODO: Remove this class when the new GUI system is implemented.
  **/
public class HappyBarGlow : MonoBehaviour
{
	public Color lowColor;
	public Color highColor;
	public float frequens;
	public float centerAlfa;
	public float varyingAlfa;
	
	void Start()
	{
		deactivate();
	}
	
	void Update()
	{
		/*
		 * Alpha is a sine of time.
	 	 */
		float newAlpha = centerAlfa + Mathf.Sin(Time.time * frequens) * varyingAlfa;
		
		var newColor = gameObject.guiTexture.color;
		newColor.a = newAlpha;
		gameObject.guiTexture.color = newColor;
	}
	
	public void activateHigh()
	{
		gameObject.SetActive(true);
		gameObject.guiTexture.color = highColor;
	}
	
	public void activateLow()
	{
		gameObject.SetActive(true);
		gameObject.guiTexture.color = lowColor;
	}
	
	public void deactivate()
	{
		gameObject.SetActive(false);
	}

}
