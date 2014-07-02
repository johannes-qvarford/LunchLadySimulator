using UnityEngine;
using System.Collections;

/** 
  * Always keep the same global rotation the transform had when equipped, not inheriting the parents rotation.
  **/
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
