using UnityEngine;
using System.Collections;

public class NpcBehaviour : MonoBehaviour
{
	public float maxSpeed;
	public float moveSpeed;

	private bool move = false;
	private GameObject queueControl = null;
	private bool firstInLine = false;
	private bool turning = false;
	private bool turned = false;
	public int animation = 0;
	protected Animator animator;
	protected Animator animatorClothes;
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
			case Tags.TURN:
				animation = 1;
				turning = true;
				queueControl.SendMessage("NpcTurning", SendMessageOptions.RequireReceiver);
			
				break;
			default:
				break;
		}
	}
	
	void Update()
	{
		
		animator = GetComponent<Animator>();
		GameObject go = transform.Find("Clothes").gameObject;
		animatorClothes = go.GetComponent<Animator>();
		if(turning && turned == false){
			Debug.Log("fuck you");
			move = false;
		}	
		if(move && rigidbody.velocity.magnitude <= maxSpeed)
		{
			//transform.position += Vector3.right * moveSpeed;
			//rigidbody.velocity += Vector3.right * moveSpeed;
			rigidbody.AddForce(Vector3.right * moveSpeed, ForceMode.VelocityChange);
			Debug.DrawLine(transform.position, transform.position + transform.right, Color.red);
		} 
		else if(move == false)
		{
			rigidbody.velocity = Vector3.zero;
		}
		switch (animation)
		{
		case 0:
			animator.SetInteger("animation",0);
			animatorClothes.SetInteger("animation",0);
			break;
		case 1:
			transform.Rotate(0,1,0);
			animator.SetInteger("animation",2);
			animatorClothes.SetInteger("animation",2);
			break;
		case 2:
			
			animator.SetInteger("animation",1);
			animatorClothes.SetInteger("animation",1);
			break;
		case 3:
			animator.SetInteger("animation",2);
			animatorClothes.SetInteger("animation",2);
			break;
		default:
			break;
		}
		if(transform.rotation ==  Quaternion.Euler (0, 180, 0) && turned == false){
			transform.Rotate (0,0,0);
			animation = 2;
			turning = false;
			queueControl.SendMessage("NpcStoppedTurning", SendMessageOptions.RequireReceiver);
			move = true;
			turned = true;
		}
		if(move == false && !turning){
			animator.SetInteger("animation",2);
			animatorClothes.SetInteger("animation",2);
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
	

	private void TurnMoveChanged(bool on)
	{
		
		if(!turned)
		{
			Debug.Log(on);
			move = on;
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
