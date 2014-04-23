using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour
{
	public bool on = false;
	public int framesBetweenSpawns = 4;
	public Vector3 speed = new Vector3(2, 2, 2);
	
	private GameObject spawnObject;
	private int curFrame = 0;
	private Random random = new Random();
	private bool prevOn = false;
	
	void Start()
	{
	}
	
	void Update()
	{
		//Debug.Log(placeToSpawn.position);
		curFrame++;
		if(curFrame % framesBetweenSpawns == 0 && on && spawnObject != null)
		{
			GameObject g = SpawnedJunk.Instantiate(spawnObject);
			g.transform.position = transform.position;
			g.transform.parent = transform;
		}
		else if(on == false)
		{
			for(int i = 0; i < transform.childCount; ++i)
			{
				Transform t = transform.GetChild(i);
				SpawnedJunk.BecomeParentToGameObject(t);
			}
		}
		prevOn = on;
	}
	
	void OnSpawnObjectChanged(GameObject g)
	{
		spawnObject = g;
	}
	
	void OnSpawnStatusChanged(bool isOn)
	{
		on = isOn;
	}
	
}
