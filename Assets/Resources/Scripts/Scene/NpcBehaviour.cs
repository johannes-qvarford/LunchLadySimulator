using UnityEngine;
using System.Collections;

public class NpcBehaviour : MonoBehaviour
{
	public float maxSpeed;
	public float moveSpeed;

	private bool move = false;
	private GameObject queueControl = null;
	private bool firstInLine = false;

	void OnTriggerEnter(Collider col)
	{
		GameObject OTHER = col.gameObject;
		switch(OTHER.tag)
		{
			case Tags.DESTROY:
				queueControl.SendMessage("NpcDestroyed", gameObject, SendMessageOptions.RequireReceiver);
				break;
			case Tags.STOP:
				firstInLine = true;
				queueControl.SendMessage("NpcStopped", gameObject, SendMessageOptions.RequireReceiver);
				break;
			default:
				break;
		}
	}
	
	void Update()
	{
		if(move && rigidbody.velocity.magnitude <= maxSpeed)
		{
			//transform.position += Vector3.right * moveSpeed;
			//rigidbody.velocity += Vector3.right * moveSpeed;
			rigidbody.AddForce(Vector3.right * moveSpeed, ForceMode.VelocityChange);
		} 
		else if(move == false)
		{
			rigidbody.velocity = Vector3.zero;
		}
	}
	
	private void NpcGotFood()
	{
		if(firstInLine)
		{
			BroadcastMessage("GotFood", SendMessageOptions.RequireReceiver);
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
