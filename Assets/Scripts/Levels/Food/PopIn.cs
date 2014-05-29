using UnityEngine;
using System.Collections;

public class PopIn : MonoBehaviour {
	public AnimationCurve curve;
	public float popInSpeed;
	public GameObject smoke;
	
	public FMODAsset popSound;
	
	private float creationTime;
	// Use this for initialization
	void Start () {
		creationTime = Time.time;
		transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

		Instantiate(smoke, transform.position, transform.rotation);
		FMOD_StudioSystem.instance.PlayOneShot(popSound,transform.position);
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
			Destroy(this);
		}
	}
}
