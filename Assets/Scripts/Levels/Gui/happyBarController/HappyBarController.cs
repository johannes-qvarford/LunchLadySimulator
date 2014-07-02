using UnityEngine;
using System.Collections;

/**
  * Class for the happy bar.
  * The happy bar has two GUI textures it manipulates, one is it's own, and the other it's child.
  * The first is the green bar, which moves up as percentage increase, and dissapear on negative percentage,
  * while the red does the opposite.
  * 
  * This class holds the happiness percentage, and trigger game over in GameOverScript when percentage is too low.
  **/
public class HappyBarController : MonoBehaviour
{
	public int score;
	public int maxPoints;
	public int percentage = 100;
	public int edges = 205;
	public int tipX = -11;
	public int tipY = -8;
	public int tipW = 22;
	public int tipH = 22;
	public int glowLimit = 80;
	
	public Gradient gradient;
	public GameOverScript gameOverScript;
	public HappyBarGlow glow;
	public GUITexture sadBar;
	public GUITexture happyBar;
	
	void Start()
	{
		UpdateBar();
	}
	
	public void addScore(int addedScore, int normal)
	{
		score += addedScore - normal;
		percentage = (int)(((float)score / (float)maxPoints)*100);
		UpdateBar();
	}
	
	public int GetHappyPercentage()
	{
		return percentage;
	}
	
	private void UpdateBar()
	{
		/*
		 * Calculate offset of bar texture based on percent points.
		 */
		percentage = Mathf.Clamp (percentage, -100, 100);
		RectOffset tempOffset = new RectOffset(0, 0, -(percentage*edges)/100, 0);
		
		if(percentage > 0)
		{
			happyBar.border = tempOffset;
			sadBar.border = new RectOffset(0, 0, 0, 0);
		}
		else
		{
			happyBar.border = new RectOffset(0, 0, 0, 0);
			sadBar.border = tempOffset;
		}
		
		CheckGlow();
		
		if(percentage <= -99)
		{
			gameOverScript.TriggerGameOver();
		}
	}
	
	private void CheckGlow()
	{
		if(percentage >= glowLimit)
		{
			glow.activateHigh();
		}
		else if(percentage <= -glowLimit)
		{
			glow.activateLow();
		}
		else
		{
			glow.deactivate();
		}
	}
}
