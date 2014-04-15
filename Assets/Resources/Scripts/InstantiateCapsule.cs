using UnityEngine;
using System.Collections;

public class InstantiateCapsule : MonoBehaviour {

	public GameObject create;


	// Use this for initialization
	void Start ()
	{


	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			GameObject gameObject = Instantiate(create, transform.position, transform.rotation) as GameObject;
		}
	}
}
