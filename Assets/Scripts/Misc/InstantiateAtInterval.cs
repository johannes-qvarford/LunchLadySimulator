using UnityEngine;
using System.Collections;

/** Instantiate a given game object continiously.
	
	TODO: rename CreateNewNPC to a more general name.
**/
public class InstantiateAtInterval : MonoBehaviour
{
	public GameObject instantiateObject;
	public float repeatTime = 10.0f;
	public float startTime = 0.0f;
	
	void Start()
	{
		InvokeRepeating("CreateNewNPC", startTime, repeatTime);
	}
	
	private void CreateNewNPC()
	{
		SpawnedJunk.Instantiate(instantiateObject, transform.position, transform.rotation);
	}
}
