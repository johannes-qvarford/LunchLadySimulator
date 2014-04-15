using UnityEngine;
using System.Collections;

public class DetectCollision : MonoBehaviour 
{

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(gameObject.name + " collided");
	}
}
