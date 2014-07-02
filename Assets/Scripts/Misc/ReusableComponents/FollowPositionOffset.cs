using UnityEngine;
using System.Collections;

/** Always keep the same global distance from a target game object.

	TODO: don't keep rotation or change name of class to be more clear.
**/
public class FollowPositionOffset : MonoBehaviour
{
	public Transform target;
	private Vector3 offset;
	private Quaternion rotation;

	void Start ()
	{
		offset = target.position - transform.position;
		rotation = transform.rotation;
	}
	
	void Update ()
	{
		transform.position = target.position - offset;
		transform.rotation = rotation;
	}
}
