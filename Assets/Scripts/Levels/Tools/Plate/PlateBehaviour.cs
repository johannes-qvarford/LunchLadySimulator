using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlateBehaviour : MonoBehaviour
{
	public float maxFoodPlateDistanceForSticky = 0.1f;
	public bool debug = false;

	void OnCollisionEnter(Collision col)
	{
		/*
		if(col.gameObject.tag == Tags.FOOD && 
			col.transform.position.y > gameObject.transform.position.y &&
			(XZ(transform.position - col.transform.position)).magnitude < maxFoodPlateDistanceForSticky)
		{
			Debug.Log("food on plate");
			col.transform.parent = transform;
			GameObject.Destroy(col.rigidbody);
		}
		*/
	}
	
	void Update()
	{
		if(debug)
		{
			Debug.DrawLine(transform.position, transform.position + (Vector3.forward * maxFoodPlateDistanceForSticky), Color.green);
		}
	}
	
	Vector2 XZ(Vector3 v)
	{
		return new Vector2(v.x, v.z);
	}
}
