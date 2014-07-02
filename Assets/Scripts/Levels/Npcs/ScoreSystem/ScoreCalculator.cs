using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
  * A mono singleton that is used to calculate the score and average score of a served lunch order.
  * It is a mono singleton instead of a utility class because of the desired ease to change it's constant during playtesting.
  *
  * TODO: As of 2014-07-01, the point system should change in the future, and then this needs to change too.
  **/
public class ScoreCalculator : MonoSingleton<ScoreCalculator>
{
	public float notAllPartsOfOrderMultiplier = 0.5f;
	public float averagePercentageOfMaxScore = 0.5f;

	public static void CalculateScore(
		Dictionary<string, int> foodIdCountOnPlate, 
		LunchOrder lunchOrder,
		float timeMultiplier,
		out int averageScore,
		out int actualScore
	)
	{
		GetInstance().CalculateScoreInternal(foodIdCountOnPlate, lunchOrder, timeMultiplier, out averageScore, out actualScore);
	}

	private void CalculateScoreInternal(
		Dictionary<string, int> foodIdCountOnPlate, 
		LunchOrder lunchOrder,
		float timeMultiplier,
		out int averageScore,
		out int actualScore
	)
	{
		int score = 0;
		int tempCount;
		int maxScore = 0;
		
		bool gotMainOrder = false;
		bool gotSideOrder = false;
		bool gotDrink = false;
		
		foreach(var recipie in lunchOrder.MainDishes)
		{
			if(foodIdCountOnPlate.TryGetValue(recipie.Name, out tempCount))
			{
				score += (int)((float)recipie.Value * Mathf.Clamp(0, 1, (float)tempCount / (float)recipie.Number));
				gotMainOrder = true;
			}
			maxScore += recipie.Value;
		}
		
		if(foodIdCountOnPlate.TryGetValue(lunchOrder.SideOrder.Name, out tempCount))
		{
			score += (int)((float)lunchOrder.SideOrder.Value * Mathf.Clamp(0, 1, (float)tempCount / (float)lunchOrder.SideOrder.Number));
			gotSideOrder = true;
		}
		maxScore += lunchOrder.SideOrder.Value;
		
		if(foodIdCountOnPlate.TryGetValue(lunchOrder.Drink.Name, out tempCount))
		{
			score += (int)((float)lunchOrder.Drink.Value * Mathf.Clamp(0, 1, (float)tempCount / (float)lunchOrder.Drink.Number));
			gotDrink = true;
		}
		maxScore += lunchOrder.Drink.Value;
		
		bool gotAll = gotMainOrder && gotSideOrder && gotDrink;
		
		actualScore = (int)Mathf.Ceil(score * timeMultiplier * (gotAll ? 1 : notAllPartsOfOrderMultiplier));
		averageScore = (int)Mathf.Floor(maxScore * averagePercentageOfMaxScore);
	}
}
