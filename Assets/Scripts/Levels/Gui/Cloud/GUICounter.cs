using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * counter class for counting and displaying a counter.
 */
public class GUICounter : MonoBehaviour
{
	private int score = 0;

	void Start()
	{
		UpdateScore();
	}
	
	public void AddScore(int addedValue)
	{
		score += addedValue;
		UpdateScore();
	}
	
	private void UpdateScore()
	{
		guiText.text = score.ToString();
	}
}
