using UnityEngine;
using System.Collections;

public class RightHandController : MonoBehaviour {

	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.Keypad8))
		{
			transform.position += transform.forward * speed;
		}
		
		if(Input.GetKey(KeyCode.Keypad5))
		{
			transform.position -= transform.forward * speed;
		}
		
		if(Input.GetKey(KeyCode.Keypad6))
		{
			transform.position += transform.right * speed;
		}
		
		if(Input.GetKey(KeyCode.Keypad4))
		{
			transform.position -= transform.right * speed;
		}
		
		if(Input.GetKey(KeyCode.Keypad7))
		{
			transform.position += transform.up * speed;
		}
		
		if(Input.GetKey(KeyCode.Keypad9))
		{
			transform.position -= transform.up * speed;
		}
	}
}
