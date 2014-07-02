using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions;

/**
  * Class handeling relaying information about order points for the food given to the customer.
  * It counts the food on the plate, calculates its point value with the help of ScoreCalculator, and then it sends it to ScoreCustomerHandeling.
  **/
public class NpcScore : MonoBehaviour
{
	public Transform tray;
	public float sphereRadiusOfFoodDetection = 0.4f;

	private float timeMultiplier;
	void TimeMultiplierChanged(float mul)
	{
		timeMultiplier = mul;
	}

	public void NpcGotFood()
	{
		/*
		 * Map FoodIds to the number of each of them that where detected in the spehere.
		 */
		var foodIdCountOnPlate = Physics.OverlapSphere(tray.position, sphereRadiusOfFoodDetection, Layers.CombineLayerNames(Layers.GRABABLE, Layers.INTERACT, Layers.SOUP))
			.Where(c => c.tag == Tags.FOOD)
			.Select(c => c.GetComponent<FoodID>().foodID)
			.GroupBy(id => id)
			.ToDictionary(gr => gr.Key, gr => gr.Count());
		
		var lunchOrder = GetComponent<LunchOrderBehaviour>().TheLunchOrder;
		
		int averageScore = 0;
		int actualScore = 0;
		ScoreCalculator.CalculateScore(
			foodIdCountOnPlate,
			lunchOrder,
			timeMultiplier,
			out averageScore,
			out actualScore);
		
		GameObject.FindWithTag(Tags.SCORE_CUSTOMER_HANDELER)
			.GetComponent<ScoreCustomerHandeling>()
			.AddScore(score: actualScore, mediumScore: averageScore);
	}
}