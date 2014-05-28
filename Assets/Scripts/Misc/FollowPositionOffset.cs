using UnityEngine;
using System.Collections;

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
