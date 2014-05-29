using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {
	Transform start;
	float yRotate;
	void Start () 
	{
		yRotate = Random.Range(0,360);
		start = transform;
		transform.rotation = Quaternion.Euler(start.rotation.x,yRotate,start.rotation.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
