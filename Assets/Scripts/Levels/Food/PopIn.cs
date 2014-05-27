using UnityEngine;
using System.Collections;

public class PopIn : MonoBehaviour {
	public AnimationCurve curve;
	public float popInSpeed;
	public GameObject smoke;
	private GameObject mySmoke;
	private float creationTime;
	// Use this for initialization
	void Start () {
		creationTime = Time.time;
		transform.localScale = new Vector3(0, 0, 0);
		mySmoke = (GameObject) Instantiate(smoke, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if(((Time.time - creationTime)*popInSpeed) < 2)
		{
			float scale = curve.Evaluate ((Time.time - creationTime)*popInSpeed);
			transform.localScale = new Vector3(scale, scale, scale);
		}
		else
		{
			Destroy(mySmoke);
			Destroy(this);
		}
	}
}
