using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreCounter : MonoBehaviour {
	private int score = 0;
	public Vector2 popUpEndPosition;
	public Vector2 popUpInternalDifference;
	public string beforeString = "Score: ";
	public string endString = "";
	public GameObject popUp;

	public int[] prefixBorders;
	public Color[] prefixColors;
	public string[] prefixPostfix;
	public int[] prefixValue;


	public int testScore;

	private Queue<GameObject> popUps;

	// Use this for initialization
	void Start () {
		popUps = new Queue<GameObject>();
		UpdateScore ();
	}
	public void AddScore(int addedValue)
	{
		score += addedValue;
		UpdateScore ();
	}
	public int GetScore()
	{
		return score;
	}
	private void UpdateScore()
	{
		short prefixLevel = -1;
		//This loop finds which prefix we should use. -1 if no prefix.
		for(short i = 0; i < prefixBorders.Length; i++)
		{
			if(prefixBorders[i] > score)
			{
				break;
			}
			prefixLevel = i;
		}
		if(prefixLevel == -1)
		{
			guiText.text = beforeString + score + endString;
		}
		else
		{
			int compressedScore = (int)Mathf.Floor(score/prefixValue[prefixLevel]);
			guiText.text = beforeString + compressedScore + prefixPostfix[prefixLevel] + endString;
			guiText.color = prefixColors[prefixLevel];
		}
	}
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			spawnScore(testScore);
		}
		if(popUps.Count == 0)
		{
			return;
		}
		ScorePopup scorePopup = popUps.Peek().GetComponent ("ScorePopup") as ScorePopup;

		if(scorePopup.getScore() == 0)
		{
			removeFirst();
		}
	}
	private void removeFirst()
	{
		ScorePopup scorePopup = popUps.Peek().GetComponent ("ScorePopup") as ScorePopup;
		score += scorePopup.getScore();
		Destroy (popUps.Peek());		//Remove first
		popUps.Dequeue ();
		foreach(GameObject gameobject in popUps)
		{
			ScorePopup temp = gameobject.GetComponent ("ScorePopup") as ScorePopup;
			temp.changeEndPos(-popUpInternalDifference);	//Move the rest
		}
		if(popUps.Count > 0)
		{
			scorePopup = popUps.Peek().GetComponent ("ScorePopup") as ScorePopup;
			scorePopup.firstInQueue ();	//Activate next
		}
	}
	public void spawnScore(int spawnedScore)
	{
		GameObject newPopup = Instantiate(popUp, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		ScorePopup scorePopup = newPopup.GetComponent ("ScorePopup") as ScorePopup;
		scorePopup.setValues (
			spawnedScore,
		    this,
		    popUpEndPosition + popUpInternalDifference * popUps.Count,	//Targeted position
		    popUps.Count == 0	//If it's allowed to count down or not
		);
		popUps.Enqueue(newPopup);
	}
}
