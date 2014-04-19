﻿using UnityEngine;
using System.Collections;

public class LeftHandController : MonoBehaviour {

	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.W))
		{
			transform.position += transform.forward * speed;
		}

		if(Input.GetKey(KeyCode.S))
		{
			transform.position -= transform.forward * speed;
		}

		if(Input.GetKey(KeyCode.D))
		{
			transform.position += transform.right * speed;
		}

		if(Input.GetKey(KeyCode.A))
		{
			transform.position -= transform.right * speed;
		}

		if(Input.GetKey(KeyCode.R))
		{
			transform.position += transform.up * speed;
		}

		if(Input.GetKey(KeyCode.F))
		{
			transform.position -= transform.up * speed;
		}	
	}
}