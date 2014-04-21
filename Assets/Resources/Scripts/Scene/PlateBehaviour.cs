using UnityEngine;
using System.Collections;

public class PlateBehaviour : MonoBehaviour
{
	public float maxFoodPlateDistanceForSticky = 0.1f;
	public bool debug = false;

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == Tags.FOOD && 
			col.transform.position.y > gameObject.transform.position.y &&
			(transform.position - col.transform.position).magnitude < maxFoodPlateDistanceForSticky)
		{
			col.transform.parent = transform;
			GameObject.Destroy(col.rigidbody);
		}
	}
	
	void Update()
	{
		if(debug)
		{
			Debug.DrawLine(transform.position, transform.position + (Vector3.forward * maxFoodPlateDistanceForSticky), Color.green);
		}
	}
}
