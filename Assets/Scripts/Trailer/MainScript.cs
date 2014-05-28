using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
	//public Rigidbody2D capsule;
	public GameObject capsule;
	public Rigidbody2D core;
	public int length = 1;
	public int number = 10;
	// Use this for initialization
	void Start ()
	{
		Vector3 spawnPositionCore = new Vector3 (0, 0, 0);
		Quaternion spawnRotationCore = Quaternion.identity;
		GameObject lastObject = Instantiate (core, spawnPositionCore, spawnRotationCore) as GameObject;

		for(int i = 0; i < number; i++)
		{
			Quaternion spawnRotation = Quaternion.identity;
			Vector3 spawnPosition = new Vector3 (0, i*length, 0);
			//GameObject newObject = Instantiate (capsule, spawnPosition, spawnRotation) as GameObject;
			GameObject newObject = Instantiate (capsule, spawnPosition, spawnRotation) as GameObject;


			//HingeJoint2D hj = newObject.AddComponent("HingeJoint2D") as HingeJoint2D;
			//HingeJoint2D hj = newObject.GetComponent<HingeJoint2D>();
			newObject.GetComponent<HingeJoint2D>().connectedBody = lastObject.rigidbody2D;
			lastObject = newObject;

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
