using UnityEngine;
using System.Collections;

/**
 * Class for creating a "pop" in effect.
 * Plays a sound, applies an animation curve until the animation is over,
 * at which point the script is destroyed.
 **/
public class PopIn : MonoBehaviour
{
	public AnimationCurve curve;
	public float popInSpeed;
	public GameObject smoke;
	public FMODAsset popSound;
	
	private float creationTime;

	void Start()
	{
		creationTime = Time.time;
		transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

		Instantiate(smoke, transform.position, transform.rotation);
		FMOD_StudioSystem.instance.PlayOneShot(popSound, transform.position);
	}

	void Update ()
	{
		if(((Time.time - creationTime)*popInSpeed) < 2)
		{
			float scale = curve.Evaluate((Time.time - creationTime) * popInSpeed);
			transform.localScale = new Vector3(scale, scale, scale);
		}
		else
		{
			Destroy(this);
		}
	}
}
