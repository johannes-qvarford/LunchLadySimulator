using UnityEngine;
using System.Collections;

public class PopIn : MonoBehaviour {
	public AnimationCurve curve;
	public float popInSpeed;
	public GameObject smoke;
	private float creationTime;
	// Use this for initialization
	void Start () {
		creationTime = Time.time;
		transform.localScale = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		float scale = curve.Evaluate ((Time.time - creationTime)*popInSpeed);
		transform.localScale = new Vector3(scale, scale, scale);
	}
}
