using UnityEngine;
using System.Collections;

public class ScorePopup : MonoBehaviour {
	public float moveSpeed;
	public float countDownDelay;
	public float queueCountDelay;
	public float countDownTime;
	public string preString;
	public string postString;
	public GUITexture[] textures;
	public Vector2 textureSize;
	
	private Vector2 endPos;
	private int score;
	private int currentScore;
	private ScoreCounter scoreCounter;
	private bool m_active;
	private float startCountTime;
	private float deltaPoints;
	// Use this for initialization
	public void firstInQueue()
	{
		startCountTime = Time.time + queueCountDelay;
		m_active = true;
	}
	public int getScore()
	{
		return currentScore;
	}
	public void setValues(int newScore, ScoreCounter newScoreCounter, Vector2 newEndPos, bool isEnabled)
	{
		currentScore = score = newScore;
		scoreCounter = newScoreCounter;
		endPos = newEndPos;
		m_active = isEnabled;
		updateText ();
	}
	public void changeEndPos(Vector2 changedEndPos)
	{
		endPos += changedEndPos;
	}
	void Start () {
		startCountTime = Time.time + countDownDelay;
		deltaPoints = 0;
	}
	private void updateText()
	{
		guiText.text = preString + currentScore + postString;
	}

	// Update is called once per frame
	void Update () {
		guiText.pixelOffset = Vector2.Lerp (guiText.pixelOffset, endPos, moveSpeed * Time.deltaTime);
		foreach(GUITexture texture in textures)
		{
			texture.pixelInset = new Rect(guiText.pixelOffset.x, guiText.pixelOffset.y, textureSize.x, textureSize.y);
		}
		if(Time.time > startCountTime && m_active)
		{
			deltaPoints += (Time.deltaTime / countDownTime) * score;
			if(deltaPoints > currentScore)
			{
				deltaPoints = currentScore;
				m_active = false;
			}
			if(deltaPoints < 1)
			{
				return;
			}
			int removingPoints = (int) Mathf.Floor(deltaPoints);
			deltaPoints -= removingPoints;
			scoreCounter.AddScore(removingPoints);
			currentScore -= removingPoints;
			updateText();
		}
	}
}
