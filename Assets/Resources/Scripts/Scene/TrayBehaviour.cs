using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TrayBehaviour : MonoBehaviour
{
	public bool doIt = false;
	public float maxDistance = 1.0f; 

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
		int score = 0;
		foreach(string key in foodCount.Keys)
		{
			score += foodCount[key];
			//Debug.Log(key + " " + foodCount[key]);
		}

		ScoreHandeling scoreHandeling = GameObject.FindWithTag("ScoreCHandeler").GetComponent<ScoreHandeling>();
		scoreHandeling.addScore(score, 0);
	}

}
