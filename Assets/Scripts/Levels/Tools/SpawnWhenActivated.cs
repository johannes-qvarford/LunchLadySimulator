using UnityEngine;
using System.Collections;

/** Script that spawns a single game object every frame its asked on an interval.
**/
public class SpawnWhenActivated : MonoBehaviour
{
	/*
		Debug variable that gets set to true in the inspector to have the script always spawm game objects at a certain interval.
	*/
	public bool alwaysSpawn = false;
	public int framesBetweenSpawns = 4;
	public float speed = 0.2f;
	public float randomMaxDistance = 0.01f;
	
	private GameObject spawnObject;
	private int curFrame = 0;
	/*
		TODO: remove unused variable.
	*/
	private Random random = new Random();
	private bool doSpawn = false;
	
	void Update()
	{
		curFrame++;
		if(curFrame % framesBetweenSpawns == 0 && (doSpawn || alwaysSpawn) && spawnObject != null)
		{
			GameObject g = SpawnedJunk.Instantiate(spawnObject);
			g.rigidbody.AddForce(-Vector3.up * speed, ForceMode.Impulse);
			g.transform.position = transform.position + 
			new Vector3(
				Random.Range(-randomMaxDistance, randomMaxDistance), 
				Random.Range(-randomMaxDistance, randomMaxDistance), 
				Random.Range(-randomMaxDistance, randomMaxDistance));
		}
		doSpawn = false;
	}
	
	public void OnSpawnObjectChanged(GameObject g)
	{
		spawnObject = g;
	}
	
	public void OnSpawnAgain()
	{
		doSpawn = true;
	}
}
