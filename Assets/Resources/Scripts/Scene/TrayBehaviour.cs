using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TrayBehaviour : MonoBehaviour
{
	public bool doIt = false;
	public float maxDistance = 0.4f;
	public float dificulty = 0.5f;

	void Update()
	{
		Debug.DrawLine(transform.position, transform.position + (Vector3.forward * maxDistance));
	}

	private void GotFood()
	{
		var dict = new Dictionary<string, int>();
		var ids = from c in Physics.OverlapSphere(transform.position, maxDistance, Layers.CombineLayerNames(Layers.GRABABLE, Layers.INTERACT, Layers.SOUP))
			where c.tag == Tags.FOOD
				select c.gameObject.GetComponent<FoodID>().foodID;
		foreach(string id in ids)
		{
			if(dict.ContainsKey(id) == false)
			{
				dict.Add(id, 0);
			}
			dict[id]++;
		}

		DetermineFoodPoints(dict);
	}
	private void DetermineFoodPoints(Dictionary<string, int> foodCount)
	{
		//TODO: use dictionary of foodID -> count to determine point based on recipie.

		foreach(string key in foodCount.Keys)
		{
			//score += foodCount[key];
			//Debug.Log(key + " " + foodCount[key]);
		}

		ScoreHandeling scoreHandeling = GameObject.FindWithTag("ScoreHandeler").GetComponent<ScoreHandeling>();
		ScoreCounter customerCounter = GameObject.FindWithTag("CustomerCounter").GetComponent<ScoreCounter>();
		NPCRandomizer randomizer = findNPCRecursive (transform).GetComponent<NPCRandomizer>();
		DishStruct[] mainOrder = randomizer.GetMainOrder();
		DishStruct sideOrder = randomizer.GetSideOrder();
		DishStruct drink = randomizer.GetDrink();

		int score = 0;
		int temp;
		int maxScore = 0;
		for (int i = 0; i < mainOrder.Length; i++)
		{
			if(foodCount.TryGetValue(mainOrder[i].dish, out temp))
			{

				score += (int)((float)mainOrder[i].baseValue * Mathf.Clamp(0, 1, (float)temp / (float)mainOrder[i].number));

			}
			maxScore += mainOrder[i].baseValue;
		}
		if(foodCount.TryGetValue(sideOrder.dish, out temp))
		{
			score += (int)((float)sideOrder.baseValue * Mathf.Clamp(0, 1, (float)temp / (float)sideOrder.number));

		}

		maxScore += sideOrder.baseValue;
		if(foodCount.TryGetValue(drink.dish, out temp))
		{
			score += (int)((float)drink.baseValue * Mathf.Clamp(0, 1, (float)temp / (float)drink.number));
			maxScore += drink.number;
		}
		maxScore += drink.baseValue;
		customerCounter.spawnScore(1);
		scoreHandeling.addScore(score+1, (int)Mathf.Floor(maxScore * dificulty));
	}

	private Transform findNPCRecursive(Transform t)
	{
		if (t.tag == "NPC")
		{
			return t;
		}
		else if(t.parent != null)
		{
			return findNPCRecursive(t.parent);
		}
		else
		{
			return null;
		}
	}
}
