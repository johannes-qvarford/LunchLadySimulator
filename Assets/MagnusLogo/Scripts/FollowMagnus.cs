using UnityEngine;
using System.Collections;

public class FollowMagnus : MonoBehaviour {

	public Transform magnus;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = magnus.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = magnus.position - offset;
		transform.rotation = magnus.rotation;
	}
}
