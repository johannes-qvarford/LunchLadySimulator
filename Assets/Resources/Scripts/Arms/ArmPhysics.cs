using System;
using UnityEngine;
public class ArmPhysics : MonoBehaviour
{
	private bool insideSolid = false;
	private ArmInputManager.Arm arm;
	private int framesInsideSolid = 0;
	
	private ArmsState armsState;
	private Transform handle;
	public Vector3 lastPush = Vector3.zero;
	private Transform otherHandle;
	
	void FixedUpdate()
	{
		if(insideSolid && framesInsideSolid < armsState.framesUntilGiveUpSolidSolve)
		{
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation
				| (Mathf.Abs(lastPush.x) < armsState.minMovementWithoutFreeze ? RigidbodyConstraints.FreezePositionX : 0)
					| (Mathf.Abs(lastPush.y) < armsState.minMovementWithoutFreeze ? RigidbodyConstraints.FreezePositionY : 0)
					| (Mathf.Abs(lastPush.z) < armsState.minMovementWithoutFreeze ? RigidbodyConstraints.FreezePositionZ : 0);
		}
		else
		{
			{
				float Z_ROTATION = armsState.rotationSpeed * 		
					ArmInputManager.GetMovement(arm, ArmInputManager.HORIZONTAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Z_ROTATION, arm)); 
				float X_MOVEMENT = armsState.movementSpeed * 
					ArmInputManager.GetMovement(arm, ArmInputManager.HORIZONTAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Z_ROTATION, arm) == false);
				float Y_MOVEMENT = armsState.movementSpeed * 		
					ArmInputManager.GetMovement(arm, ArmInputManager.VERTICAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Y_MOVEMENT, arm));
				float Z_MOVEMENT = armsState.movementSpeed * 
					ArmInputManager.GetMovement(arm, ArmInputManager.VERTICAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Y_MOVEMENT, arm) == false);
				
				{
					rigidbody.AddTorque(Vector3.forward * Z_ROTATION * armsState.rotationSpeed);
				}
				
				Vector3 MOVEMENT = new Vector3(X_MOVEMENT, Y_MOVEMENT, Z_MOVEMENT);
				
				int MOVING_INSIDE_X = 1;//Convert.ToInt32(Mathf.Abs(OFFSET.x) <= LIMIT.x);
				int MOVING_INSIDE_Y = 1;//Convert.ToInt32(Mathf.Abs(OFFSET.y) <= LIMIT.y);
				int MOVING_INSIDE_Z = 1;//Convert.ToInt32(Mathf.Abs(OFFSET.z) <= LIMIT.z);
				
				float HAND_MUL = arm == ArmInputManager.Arm.LEFT ? -1 : 1;
				bool MOVING_TOWARDS_OTHER_ARM = HAND_MUL * MOVEMENT.x < 0;
				bool TO_CLOSE_TO_OTHER_ARM = Mathf.Abs((handle.position - otherHandle.position).x) < armsState.minDistanceBetweenArms;
				
				if(rigidbody.velocity.magnitude < armsState.maxVelocity && 
					((MOVING_TOWARDS_OTHER_ARM && TO_CLOSE_TO_OTHER_ARM) == false) || armsState.checkIfAtonamyCorrect == false) 
				{
					lastPush = new Vector3(MOVING_INSIDE_X * MOVEMENT.x, MOVING_INSIDE_Y * MOVEMENT.y, MOVING_INSIDE_Z * MOVEMENT.z);
					rigidbody.AddForce(lastPush, ForceMode.VelocityChange);
				}
				
				{
					bool NO_X = Mathf.Abs(X_MOVEMENT) < armsState.minMovementWithoutFreeze;
					bool NO_Y = Mathf.Abs(Y_MOVEMENT) < armsState.minMovementWithoutFreeze;
					bool NO_Z = Mathf.Abs(Z_MOVEMENT) < armsState.minMovementWithoutFreeze;
					bool NO_R = Mathf.Abs(Z_ROTATION) < armsState.minZRotFreeze;
					
					rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY 
						| (NO_X ? RigidbodyConstraints.FreezePositionX : 0)
							| (NO_Y ? RigidbodyConstraints.FreezePositionY : 0)
							| (NO_Z ? RigidbodyConstraints.FreezePositionZ : 0)
							| (NO_R ? RigidbodyConstraints.FreezeRotationZ : 0);
				}
			}
			
			//fuck it, just let the engine solve it
			if(framesInsideSolid >= armsState.framesUntilGiveUpSolidSolve)
			{
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			}
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		GameObject OTHER = collision.collider.gameObject;
		if(OTHER.tag == Tags.FOOD)
		{
			handle.BroadcastMessage("OnCollisionEnter", collision, SendMessageOptions.DontRequireReceiver);
		}
		
		if(lastPush.magnitude > armsState.minMovementWithoutFreeze && Layers.IsAnyLayer(OTHER.layer, Layers.INTERACT, Layers.GRABABLE) == false)
		{
			framesInsideSolid = 0;
		}
	}
	
	void OnCollisionExit(Collision collision)
	{
		GameObject OTHER = collision.collider.gameObject;
		if(OTHER.tag == Tags.FOOD)
		{
			handle.BroadcastMessage("OnCollisionExit", collision, SendMessageOptions.DontRequireReceiver);
		}
		
		if(lastPush.magnitude > armsState.minMovementWithoutFreeze && Layers.IsAnyLayer(OTHER.layer, Layers.INTERACT, Layers.GRABABLE) == false)
		{
			insideSolid = false;
			framesInsideSolid = 0;
		}
	}
	
	void OnCollisionStay(Collision collision)
	{
		GameObject OTHER = collision.collider.gameObject;
		if(insideSolid)
		{
			framesInsideSolid++;
			rigidbody.AddForce(new Vector3(armsState.solidRecoilMul * -lastPush.x, armsState.solidRecoilMul * -lastPush.y, armsState.solidRecoilMul * -lastPush.z), ForceMode.VelocityChange);
		} 
		else if(OTHER.tag == Tags.FOOD)
		{
			handle.BroadcastMessage("OnCollisionStay", collision, SendMessageOptions.DontRequireReceiver);
		}
	}
	
	void Start()
	{
		armsState = transform.parent.GetComponent(typeof(ArmsState)) as ArmsState;
		handle = transform.Find(armsState.handleName);
	}
	
	private void ArmChanged(ArmInputManager.Arm a)
	{
		armsState = transform.parent.GetComponent(typeof(ArmsState)) as ArmsState;
		arm = a;
		Debug.Log((arm == ArmInputManager.LEFT ? "RightArm" : "LeftArm")+ "/" + armsState.handleName);
		otherHandle = transform.parent.Find((arm == ArmInputManager.LEFT ? "RightArm" : "LeftArm")+ "/" + armsState.handleName);
	}
}

