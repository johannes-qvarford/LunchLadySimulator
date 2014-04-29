using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TrayBehaviour : MonoBehaviour
{
	public bool doIt = false;
	public float maxDistance = 0.4f; 

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
		string[] mainOrder = randomizer.GetMainOrder();
		string sideOrder = randomizer.GetSideOrder();
		string drink = randomizer.GetDrink();

		int score = 0;
		int temp;
		if(foodCount.TryGetValue(mainOrder[0], out temp))
		{
			Debug.Log("main0");
			score++;
		}
		if(foodCount.TryGetValue(mainOrder[1], out temp))
		{
			Debug.Log("main1");
			score++;
		}
		if(foodCount.TryGetValue(sideOrder, out temp))
		{
			Debug.Log("side");
			score++;
		}
		if(foodCount.TryGetValue(drink, out temp))
		{
			Debug.Log("drink");
			score++;
		}

		customerCounter.spawnScore(1);
		scoreHandeling.addScore(score, 1);
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
