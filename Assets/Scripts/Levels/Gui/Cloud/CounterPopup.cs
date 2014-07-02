using UnityEngine;
using System.Collections;

/*
 * Class for animating popups.
 * They move to a position, then start counting down, and then they dissapear.
 */
public class CounterPopup : MonoBehaviour
{
	public float moveSpeed;
	public float countDownDelay;
	public float countDownTime;
	
	public string preString;
	public string postString;
	
	public GUITexture[] textures;
	public Vector2 textureSize;
	
	public delegate void ScoreIncreased(int deltaScore);
	
	private Vector2 endPos;
	private int totalScore;
	private int currentScore;
	private ScoreIncreased onScoreIncreased;
	
	private float deltaPoints;
	
	private DoOncer beginAnimationOnce = new DoOncer();
	
	void Start () 
	{
		deltaPoints = 0;
		//InvokeRepeating("CountDownUpdate", time: countDownDelay, repeatRate: 1 / 30.0f);
	}
	
	public void setValues(int newScore, ScoreIncreased scoreIncreasedCallback, Vector2 endPos)
	{
		totalScore = newScore;
		currentScore = newScore;
		onScoreIncreased = scoreIncreasedCallback;
		endPos = endPos;
		updateText();
	}
	
	private void updateText()
	{
		guiText.text = preString + currentScore + postString;
	}

	void Update ()
	{
		guiText.pixelOffset = Vector2.Lerp (guiText.pixelOffset, endPos, moveSpeed * Time.deltaTime);
		foreach(GUITexture texture in textures)
		{
			texture.pixelInset = new Rect(guiText.pixelOffset.x, guiText.pixelOffset.y, textureSize.x, textureSize.y);
		}
	}
	
	private void CountDownUpdate()
	{
		/*
		 * Deltapoints is increased a bit every frame.
		 * Every frame, it's increased based on the total score, and the speed of the count down.
		 * The integer part of deltaScore is then removed from currentScore and deltaPoints,
		 * and notified to the point increase callback.
		 * If currentScore is lower than deltaPoints, the popup should be destroyed.
		 */
		deltaPoints += (Time.deltaTime / countDownTime) * totalScore;
		if(deltaPoints >= currentScore)
		{
			deltaPoints = currentScore;
			Destroy(gameObject);
		}
		int removingPoints = (int)Mathf.Floor(deltaPoints);
		deltaPoints -= removingPoints;
		if(onScoreIncreased != null)
		{
			/*
			 * Decreasing pop up score increased something elses score.
			 */
			onScoreIncreased(removingPoints);
		}
		currentScore -= removingPoints;
		updateText();
	}
}
