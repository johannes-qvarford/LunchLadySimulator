using UnityEngine;
using System.Collections;

public class IgnoreParentRotation : MonoBehaviour
{
	private Quaternion rotation;
	
	void Start ()
	{
		rotation = transform.rotation;	
	}
	
	void Update ()
	{
		transform.rotation = rotation;
	}
}
