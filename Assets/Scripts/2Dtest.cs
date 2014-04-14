using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
	//public Rigidbody2D capsule;
	public GameObject capsule;
	public GameObject core;
	public int length = 1;
	public int number = 10;
	public float startGravity = -0.5f;
	public float endGravity = 0.5f;
	public float dropletSpawnRate = 0.5f;
	public GameObject droplet;
	public Transform dropletSpawn;
	public float dropletSpeed = 10;
	public float dropletLifetime = 10;

	private float nextDropletSpawn = 0;
	// Use this for initialization
	void Start ()
	{
		Vector3 spawnPositionCore = new Vector3 (0, 0, 0);
		Quaternion spawnRotationCore = Quaternion.identity;
		GameObject lastObject = Instantiate (core, spawnPositionCore, spawnRotationCore) as GameObject;
		GameObject end1 = spawnChain(lastObject, new Vector3(0.4f, 0, 0));
		GameObject end2 = spawnChain(lastObject, new Vector3(-0.4f, 0, 0));
		HingeJoint2D hj = end1.AddComponent ("HingeJoint2D") as HingeJoint2D;
		hj.connectedBody = end2.GetComponent<Rigidbody2D>();
		hj.anchor = new Vector2 (0, 0.75f);
		hj.connectedAnchor = new Vector2 (0, 0.75f);
/*
		for(int i = 0; i < number; i++)
		{
			Quaternion spawnRotation = Quaternion.identity;
			Vector3 spawnPosition = new Vector3 (0, i*length, 0);
			GameObject newObject = Instantiate (capsule, spawnPosition, spawnRotation) as GameObject;
			Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
			rb.gravityScale = startGravity + (endGravity - startGravity) * i / number;

			HingeJoint2D hj = newObject.GetComponent<HingeJoint2D>();
			hj.connectedBody = lastObject.GetComponent<Rigidbody2D>();
			lastObject = newObject;
		}
*/
	}
	private GameObject spawnChain(GameObject child, Vector3 position){
		GameObject lastObject = child;
		for(int i = 0; i < number; i++)
		{
			Quaternion spawnRotation = Quaternion.identity;
			Vector3 spawnPosition = new Vector3 (0, i*length+1, 0)+position;
			GameObject newObject = Instantiate (capsule, spawnPosition, spawnRotation) as GameObject;
			Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
			rb.gravityScale = startGravity + (endGravity - startGravity) * i / (number-1);
			
			HingeJoint2D hj = newObject.GetComponent<HingeJoint2D>();
			if(i == 0){
				Vector2 ca = hj.connectedAnchor;
				ca.x = position.x;
				hj.connectedAnchor = ca;
			}
			hj.connectedBody = lastObject.GetComponent<Rigidbody2D>();
			lastObject = newObject;

		}
		return lastObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextDropletSpawn)
		{
			nextDropletSpawn = Time.time + dropletSpawnRate;
			GameObject drop = Instantiate(droplet, dropletSpawn.position, Quaternion.identity) as GameObject;
			drop.rigidbody2D.velocity = dropletSpawn.transform.forward * dropletSpeed;
			Destroy (drop, dropletLifetime);
		}
	
	}
}
