using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour 
{
	public bool on = false;
	public GameObject spawnObject;
	public int framesBetweenSpawns = 10;
	public Vector3 speed = new Vector3(1, 1, 1);
	
	private int curFrame = 0;
	private Random random = new Random();
	private bool prevOn = false;
	
	void Update () 
	{
		curFrame++;
		if(curFrame % framesBetweenSpawns == 0 && on)
		{
			GameObject g = (GameObject)GameObject.Instantiate(spawnObject);
			g.transform.position = transform.position;
			g.transform.parent = transform;
			//g.rigidbody.isKinematic = true;
			//GameObject.Destroy(g.rigidbody);
		}
		else if(on == false)
		{
			for(int i = 0; i < transform.childCount; ++i)
			{
				Transform t = transform.GetChild(i);
				t.parent = null;
				//t.gameObject.AddComponent(typeof(Rigidbody));
			}
		}
		prevOn = on;
	}
	
	void OnSpawnStatusChanged(bool isOn)
	{
		Debug.Log("hello");
		on = isOn;
	}
}
