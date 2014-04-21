using UnityEngine;
using System.Collections;

public class FoodKiller : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Food")
		{
			Destroy(collision.gameObject);
		}
	}
}
