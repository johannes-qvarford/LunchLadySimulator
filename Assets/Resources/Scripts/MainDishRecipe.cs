using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainDishRecipe : MonoBehaviour {

	public float yellow = 0;
	public float green = 0;

	private float totIngredient;
	// Use this for initialization
	void Awake()
	{
		totIngredient = yellow + green;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Food")
		{
			if(collider.GetComponent<FoodID>().foodID == "Yellow")
			{
				yellow--;
			}
			if(collider.GetComponent<FoodID>().foodID == "Green")
			{
				green--;
			}
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if(collider.tag == "Food")
		{
			if(collider.GetComponent<FoodID>().foodID == "Yellow")
			{
				yellow++;
			}
			if(collider.GetComponent<FoodID>().foodID == "Green")
			{
				green++;
			}
		}
	}

	public float GetResult()
	{
		float tempCalc= ((1 / totIngredient) * Mathf.Abs(yellow)) + ((1 / totIngredient) * Mathf.Abs(green));
		float result = Mathf.Clamp01(1 - tempCalc);
		return result;
	}
}
