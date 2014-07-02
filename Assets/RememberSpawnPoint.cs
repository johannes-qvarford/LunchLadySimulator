using UnityEngine;
using System.Collections;

public class RememberSpawnPoint : MonoBehaviour
{
	private Vector3 spawnPos;
	private Quaternion rotation;
	public GameObject smoke;
	
	void OnEnable()
	{
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
		Invoke( "spawnWithDelay", 0.1f );

	}
	private void spawnWithDelay()
	{
		Instantiate(smoke, transform.TransformPoint(Vector3.zero), transform.rotation);
	}
}
