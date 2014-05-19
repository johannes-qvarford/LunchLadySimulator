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
	public int animationFaceInt = 0;
	public bool faceready = false;

	
	protected Animator faceAnimator;
	private bool sidewaysrot = false;

	int tempCounter = 0;

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
					ShowSpeechBubble();
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

		animationFaceInt = transform.GetComponent<Impatience>().getImpatienceLevel();
	//Debug.Log (animationFaceInt);
		if(animationFaceInt > 3)
		{
			animationFaceInt = 3;
		}
		
		if (faceready) 
		{
			GameObject fgo = transform.Find ("Customer_Kid/Hips 1/Spine/Spine1/Spine2/Neck/Head 1/head_kid").gameObject;
			faceAnimator = fgo.GetComponent<Animator> ();
		}


		if(turning && turned == false){
			
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
			
			//		transform.Rotate (0,3,0);
			animator.SetInteger("animation",4);
			animatorClothes.SetInteger("animation",4);
			
			
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("Turn")){
				animator.applyRootMotion = true;
				
				
				
				
				if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > animator.GetCurrentAnimatorStateInfo(0).length)
				{	
					
					animation = 2;
					turning = false;
					move = true;
					turned = true;		
					sidewaysrot = true;
					
					
				}
			}
			
			break;
		case 2:
			animator.applyRootMotion = false;
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
		
		
		if(sidewaysrot)
		{	
			transform.Rotate (0,1,0);
			
			if(transform.rotation.y > 0.9999f){
				sidewaysrot = false;
				Debug.Log ("yoyooy");
			}
			
			tempCounter++;
		}
		if(move == false && !turning){
			animator.SetInteger("animation",2);
			animatorClothes.SetInteger("animation",2);
		}
		
		if (faceready)
		{
			faceAnimator.SetInteger ("animation", animationFaceInt);
		}
	}
	
	void Start()
	{
		speechBubble = transform.FindChild("SpeechBubble").GetComponent<SpeechBubble>();
		if(speechBubble == null)
		{
			Debug.LogError("no speechbubble found");
		}
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
			//Debug.Log(on);
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
	
	private void ShowSpeechBubble()
	{
		speechBubble.display();
	}
}
