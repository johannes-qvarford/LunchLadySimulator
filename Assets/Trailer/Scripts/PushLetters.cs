using UnityEngine;
using System.Collections;

public class PushLetters : MonoBehaviour {
	public Transform magnus;
	public ForceMode mode;
	public float force;

	private Vector3 lastFrameOffset;
	private Vector3 prevPosition;

	void Start()
	{
		prevPosition = transform.position;
	}

	void Update()
	{
		lastFrameOffset = transform.position - prevPosition;
		prevPosition = transform.position;
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.collider.gameObject.layer == LayerMask.NameToLayer("TransparentFX"))
		{
			col.rigidbody.AddForce(lastFrameOffset.normalized*force, mode);
		}
	}

	void OnCollisionStay(Collision col)
	{
		if(col.collider.gameObject.layer == LayerMask.NameToLayer("TransparentFX"))
		{
			col.rigidbody.AddForce(lastFrameOffset.normalized*force, mode);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("TransparentFX"))
		{
			col.rigidbody.AddForce(lastFrameOffset.normalized*force, mode);
		}
	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("TransparentFX"))
		{
			col.rigidbody.AddForce(lastFrameOffset.normalized*force, mode);
		}
	}
}
