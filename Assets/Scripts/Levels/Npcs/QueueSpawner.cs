using UnityEngine;
using System.Collections;

public class QueueSpawner : MonoBehaviour {
	

	public int spawnTime;
	public int maxSpawnObjects;
	public GameObject spawnObject;


	int numberOfSpawnedObjects = 0;
	float timer;
	
	// Use this for initialization
	void Start () {
		timer = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {	
		Spawn ();
		UpdateTimer();

	}
	
	//MÖJLIGT ATT GÖRA EN BÄTTRE TIMER SEN FÖR SPAWNTIDEN
	void UpdateTimer()
	{
		timer += Time.deltaTime;
		
	}

	//FUNKTION FÖR ATT SPAWNA NPC
	void Spawn()
	{
		if(numberOfSpawnedObjects < maxSpawnObjects && timer > spawnTime)
		{
			AddNpcInQueue();
			numberOfSpawnedObjects++;
			timer = 0;
		}
	}


	void AddNpcInQueue()
	{
		GameObject npc = SpawnedJunk.Instantiate(spawnObject, transform.position, transform.rotation);
		npc.GetComponent<QueueController>().queueSpawner = this;
		npc.transform.position = transform.position;
		npc.GetComponent<NPCMovement>().walk = true;
	}
	
	public void NPCDestroyed()
	{

		numberOfSpawnedObjects--;
	}

}
