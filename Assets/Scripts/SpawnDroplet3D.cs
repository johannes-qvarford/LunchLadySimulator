using UnityEngine;
using System.Collections;

public class SpawnDroplet3D : MonoBehaviour {
	public GameObject droplet;
	public float dropletSpawnRate = 0.5f;
	public float dropletLifetime = 10;
	public float dropletSpeed = 10;
	public Transform dropletSpawn;

	
	private float nextDropletSpawn = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextDropletSpawn)
		{
			nextDropletSpawn = Time.time + dropletSpawnRate;
			GameObject drop = Instantiate(droplet, dropletSpawn.position, Quaternion.identity) as GameObject;
			drop.rigidbody.velocity = Random.insideUnitSphere * dropletSpeed;
			Destroy (drop, dropletLifetime);
		}
	}
}
