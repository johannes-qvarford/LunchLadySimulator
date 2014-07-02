using UnityEngine;
using System.Collections;
using UnityExtensions;

/**
 * Class for food that can be spawned by tools.
 * When the food collides with a tool collider, it takes its tool, 
 * finds the tools spawn transform, and starts spawing food there.
 * It also makes a sound when it starts and stops colliding with something other than food.
 * (A hundren colliding soup particles doesn't sound very nice).
 **/
public class TriggerSpawner : MonoBehaviour
{
	public GameObject spawnObject;
	public float spawnInterval = 4 / 60.0f;
	public float spawnedObjectSpeed = 0.2f;
	public float randomMaxDistance = 0.01f;

	private Transform spawnTransform;
	private bool spawnNextTime = true;

	void Start()
	{
		InvokeRepeating("SpawnObject", 0, spawnInterval);
	}

	void OnTriggerStay(Collider col)
	{
		
		GameObject other = col.gameObject;
		if(other.IsToolCollider())
		{
			spawnTransform = other.GetToolOfToolCollider().GetSpawnTransformFromTool();
			spawnNextTime = true;
		}
	}
	
	void SpawnObject()
	{
		if(spawnTransform != null && spawnNextTime)
		{
			GameObject g = SpawnedJunk.Instantiate(spawnObject);
			g.rigidbody.AddForce(-Vector3.up * spawnedObjectSpeed, ForceMode.Impulse);
			g.transform.position = spawnTransform.position + 
			new Vector3
			(
				Random.Range(-randomMaxDistance, randomMaxDistance), 
				Random.Range(-randomMaxDistance, randomMaxDistance), 
				Random.Range(-randomMaxDistance, randomMaxDistance)
			);
		}
		
		/*
		 * need to do this, because sometimes tools get out of trigger zone without calling OnTriggerExit or something,
		 * causing an endless geiser of food.
		 */
		spawnNextTime = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.IsFood() == false)
		{
			SendMessage("TriggerSound",SendMessageOptions.RequireReceiver);
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.IsFood() == false) 
		{
			SendMessage("TriggerSound",SendMessageOptions.RequireReceiver);
		}
	}

}
