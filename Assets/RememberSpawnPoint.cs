using UnityEngine;
using System.Collections;

public class RememberSpawnPoint : MonoBehaviour {
	private Vector3 spawnPos;
	private Quaternion rotation;
	public GameObject smoke;
	// Use this for initialization
	void OnEnable() {
		spawnPos = transform.TransformPoint(Vector3.zero);
		rotation = transform.localRotation;
	}
	
	public void returnToSpawn()
	{
		Instantiate(smoke, transform.TransformPoint(Vector3.zero), transform.rotation);
		transform.localPosition = spawnPos;
		transform.localRotation = rotation;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		Instantiate(smoke, transform.TransformPoint(Vector3.zero), transform.rotation);
	}
}
