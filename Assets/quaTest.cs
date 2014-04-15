using UnityEngine;
using System.Collections;

public class quaTest : MonoBehaviour {

	public Vector3 testVector;

	public GameObject gameObject;
	public GameObject create;

	// Use this for initialization
	void Start ()
	{
		gameObject = Instantiate(create, this.transform.position, Quaternion.Euler(0f, 45f, 0)) as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{


	}
}
