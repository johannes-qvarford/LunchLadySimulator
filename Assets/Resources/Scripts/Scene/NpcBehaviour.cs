using UnityEngine;
using System.Collections;

public class NpcBehaviour : MonoBehaviour
{
	public float maxSpeed;
	public float moveSpeed;

	private bool move = false;
	private GameObject queueControl = null;
	private bool firstInLine = false;
	public SpeechBubble speechBubble;
	void OnTriggerEnter(Collider col)
	{
		GameObject OTHER = col.gameObject;
		switch(OTHER.tag)
		{
			case Tags.DESTROY:
				if(queueControl != null)
				{
					queueControl.SendMessage("NpcDestroyed", gameObject, SendMessageOptions.RequireReceiver);
				}
				break;
			case Tags.STOP:
				firstInLine = true;
				if(queueControl != null)
				{
					queueControl.SendMessage("NpcStopped", gameObject, SendMessageOptions.RequireReceiver);
					speechBubble.display();
				}
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
	
	void Start()
	{
		speechBubble = transform.FindChild("SpeechBubble").GetComponent<SpeechBubble>();
	}
	
	private void NpcGotFood()
	{
		if(firstInLine)
		{
			BroadcastMessage("GotFood", SendMessageOptions.RequireReceiver);
			speechBubble.hide();
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
	
	private void ShowSpeechBubble(bool on)
	{
		speechBubble.gameObject.SetActive(on);
	}
}
