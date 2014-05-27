using UnityEngine;
using System.Collections;

public class ScoreHandeling : MonoBehaviour {
	public ScoreCounter counter;
	public HappyBarController bar;
	public void addScore(int score, int mediumScore)
	{
		counter.spawnScore (score);
		bar.addScore (score, mediumScore);
	}
}
