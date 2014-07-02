using UnityEngine;
using System.Collections;

/*
 * Class for adding score.
 * When it receives a message that the player has received some points (and the average number it should have received),
 * it notifies the happy bar, and creates a score pop up, which it hooks up to the score counter, so whenever the pop up points go down, the score counter goes up.
 * It also creates a customer pop up, and notifies the customer counter.
 */
public class ScoreCustomerHandeling : MonoBehaviour
{
	public GUICounter customerCounter;
	public GUICounter scoreCounter;
	public HappyBarController bar;
	
	public Vector2 popUpCustomerEndPosition;
	public Vector2 popUpScoreEndPosition;
	public GameObject customerPopUp;
	public GameObject scorePopUp;
	
	public void AddScore(int score, int mediumScore)
	{
		if(score != 0)
		{
			SpawnScore(score);
		}
		bar.addScore(score, mediumScore);
		SpawnCustomer();
	}
	
	private void SpawnScore(int spawnedScore)
	{
		GameObject popupGameObject = (GameObject)Instantiate(scorePopUp, gameObject.transform.position, gameObject.transform.rotation);
		CounterPopup scorePopup = popupGameObject.GetComponent<CounterPopup>();
		scorePopup.setValues (
			newScore: spawnedScore,
			scoreIncreasedCallback: increasedAmount => scoreCounter.AddScore(increasedAmount),
			endPos: popUpScoreEndPosition
		);
	}
	
	private void SpawnCustomer()
	{
		GameObject popupGameObject = (GameObject)Instantiate(customerPopUp, gameObject.transform.position, gameObject.transform.rotation);
		CounterPopup customerPopup = popupGameObject.GetComponent<CounterPopup>();
		customerPopup.setValues (
			newScore: 1,
			scoreIncreasedCallback: increasedAmount => customerCounter.AddScore(increasedAmount),
			endPos: popUpScoreEndPosition
			);
	}
}
