using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed;

	Rigidbody testRigid;

	void Awake()
	{
		testRigid = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.W))
		{
			testRigid.AddForce(transform.up * speed, ForceMode.Acceleration);
		}
		if(Input.GetKey(KeyCode.S))
		{
			testRigid.AddForce(-transform.up * speed, ForceMode.Acceleration);
		}
		if(Input.GetKey(KeyCode.A))
		{
			testRigid.AddForce(-transform.right * speed, ForceMode.Acceleration);
		}
		if(Input.GetKey(KeyCode.D))
		{
			testRigid.AddForce(transform.right * speed, ForceMode.Acceleration);
		}
	}
}
