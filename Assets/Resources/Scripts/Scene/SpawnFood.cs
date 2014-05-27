using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour
{
	public bool alwaysSpawn = false;
	public int framesBetweenSpawns = 4;
	public float speed = 0.2f;
	public float randomMaxDistance = 0.01f;
	
	private GameObject spawnObject;
	private int curFrame = 0;
	private Random random = new Random();
	private bool doSpawn = false;
	
	
	void Start()
	{
	}
	
	void Update()
	{
		//Debug.Log(placeToSpawn.position);
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
			g.transform.parent = transform;
		}
		doSpawn = false;
	}
	
	void OnSpawnObjectChanged(GameObject g)
	{
		spawnObject = g;
	}
	
	void OnSpawnAgain()
	{
		doSpawn = true;
	}
	
}
