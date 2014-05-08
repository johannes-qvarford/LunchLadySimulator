using UnityEngine;
using System.Collections;

public class ShadowPlaneFollowing : MonoBehaviour {
	public Transform m_parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = m_parent.position;
		gameObject.transform.rotation = m_parent.rotation;
	}
}
