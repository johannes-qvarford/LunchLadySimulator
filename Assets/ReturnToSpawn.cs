using UnityEngine;
using System.Collections;

public class ReturnToSpawn : MonoBehaviour {
	public string returnKey = "B";

	private Vector3 pos;
	private Quaternion rot;
	// Use this for initialization
	void Start ()
	{
		pos = gameObject.transform.position;
		rot = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (returnKey))
		{
			gameObject.transform.position = pos;
			gameObject.transform.rotation = rot;
		}
	}
}
