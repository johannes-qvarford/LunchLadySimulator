using UnityEngine;
using System.Collections;

public class NpcBehaviour : MonoBehaviour
{
	public Vector3 moveVector;

	private bool move = false;
	private GameObject queueControl = null;
	
	void OnCollisionEnter(Collision collision)
	{
		GameObject other = collision.collider.gameObject;
		if(other.tag == Tags.PLATE)
		{
			other.transform.parent = transform;
			GameObject.Destroy(other.rigidbody);
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		GameObject OTHER = col.gameObject;
		switch(OTHER.tag)
		{
			case Tags.DESTROY:
				queueControl.SendMessage("NpcDestroyed", gameObject, SendMessageOptions.RequireReceiver);
				break;
			case Tags.STOP:
				queueControl.SendMessage("NpcStopped", gameObject, SendMessageOptions.RequireReceiver);
				break;
			default:
				break;
		}
	}
	
	void Update()
	{
		transform.position += move ? moveVector : Vector3.zero;
		if(Input.GetKeyDown(KeyCode.U))
		{
			queueControl.SendMessage("NpcGotFood", SendMessageOptions.RequireReceiver);
		}
	}

	private void MoveChanged(bool on)
	{
		move = on;
	}
	
	private void QueueControlChanged(GameObject g)
	{
		queueControl = g;
	}
}