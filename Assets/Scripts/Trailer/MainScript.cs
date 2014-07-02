using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
	public GameObject capsule;
	public Rigidbody2D core;
	public int length = 1;
	public int number = 10;
	
	void Start ()
	{
		Vector3 spawnPositionCore = new Vector3 (0, 0, 0);
		Quaternion spawnRotationCore = Quaternion.identity;
		GameObject lastObject = Instantiate (core, spawnPositionCore, spawnRotationCore) as GameObject;

		for(int i = 0; i < number; i++)
		{
			Quaternion spawnRotation = Quaternion.identity;
			Vector3 spawnPosition = new Vector3 (0, i*length, 0);
			GameObject newObject = Instantiate (capsule, spawnPosition, spawnRotation) as GameObject;

			newObject.GetComponent<HingeJoint2D>().connectedBody = lastObject.rigidbody2D;
			lastObject = newObject;

		}
	}
}
