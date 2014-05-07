using System;
using UnityEngine;
public class ArmPhysics : MonoBehaviour
{
	private bool insideSolid = false;
	private ArmInputManager.Arm arm;
	private int framesInsideSolid = 0;
	
	private ArmsState armsState;
	private Transform handle;
	private Vector3 lastPush = Vector3.zero;
	private Transform otherHandle;
	private SpringJoint otherJoint;
	private float oldSpring = 0;
	
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
				
				float Z_ROTATION = armsState.rotationAcceleration * -1 * //reverse z direction 
					ArmInputManager.GetMovement(arm, ArmInputManager.HORIZONTAL) *  Convert.ToInt32(ArmInputManager.IsHeld(ArmInputManager.Z_ROTATION, arm)); 
				float X_MOVEMENT = armsState.movementAcceleration * 
					ArmInputManager.GetMovement(arm, ArmInputManager.HORIZONTAL) * 	Convert.ToInt32(ArmInputManager.IsHeld(ArmInputManager.Z_ROTATION, arm) == false);
				float Y_MOVEMENT = armsState.movementAcceleration * 
					ArmInputManager.GetMovement(arm, ArmInputManager.VERTICAL) * 	Convert.ToInt32(ArmInputManager.IsHeld(ArmInputManager.Y_MOVEMENT, arm));
				float Z_MOVEMENT = armsState.movementAcceleration * 
					ArmInputManager.GetMovement(arm, ArmInputManager.VERTICAL) * 	Convert.ToInt32(ArmInputManager.IsHeld(ArmInputManager.Y_MOVEMENT, arm) == false);

				int IUSE_Z_ROTATION = Convert.ToInt32(isAbsGreater(Z_ROTATION, Y_MOVEMENT) && isAbsGreater(Z_ROTATION, Z_MOVEMENT));
				int IUSE_Y_MOVEMENT = Convert.ToInt32(isAbsGreater(Y_MOVEMENT, Z_ROTATION));
				int IUSE_Z_MOVEMENT = Convert.ToInt32(isAbsGreater(Z_MOVEMENT, Z_ROTATION));
				
				{
					otherJoint.spring = IUSE_Z_ROTATION == 1 ? 0 : oldSpring;
					rigidbody.AddTorque(Vector3.forward * Z_ROTATION * IUSE_Z_ROTATION * armsState.rotationAcceleration);
				}

				{
					lastPush = new Vector3(X_MOVEMENT, IUSE_Y_MOVEMENT * Y_MOVEMENT, IUSE_Z_MOVEMENT * Z_MOVEMENT);
					rigidbody.AddForce(lastPush, ForceMode.VelocityChange);
				}
				
				{
					/*
					bool NO_X = Mathf.Abs(X_MOVEMENT) < armsState.minMovementWithoutFreeze;
					bool NO_Y = Mathf.Abs(Y_MOVEMENT) < armsState.minMovementWithoutFreeze;
					bool NO_Z = Mathf.Abs(Z_MOVEMENT) < armsState.minMovementWithoutFreeze;
					bool NO_R = Mathf.Abs(Z_ROTATION) < armsState.minZRotWithoutFreeze;
					*/
					
					float HX = Mathf.Max(Mathf.Abs(rigidbody.velocity.x), Mathf.Abs(X_MOVEMENT));
					float HY = Mathf.Max(Mathf.Abs(rigidbody.velocity.y), Mathf.Abs(Y_MOVEMENT));
					float HZ = Mathf.Max(Mathf.Abs(rigidbody.velocity.z), Mathf.Abs(Z_MOVEMENT));
					float HRZ = Mathf.Max(Mathf.Abs(rigidbody.angularVelocity.z), Mathf.Abs(Z_ROTATION));
					
					
					bool NO_X = HX < armsState.minMovementWithoutFreeze;
					bool NO_Y = HY < armsState.minMovementWithoutFreeze;
					bool NO_Z = HZ < armsState.minMovementWithoutFreeze;
					bool NO_R = HRZ < armsState.minZRotWithoutFreeze;
					
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
			rigidbody.AddForce(new Vector3(armsState.recoilMulOnSolidCollision * -lastPush.x, armsState.recoilMulOnSolidCollision * -lastPush.y, armsState.recoilMulOnSolidCollision * -lastPush.z), ForceMode.VelocityChange);
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
		otherJoint = otherHandle.parent.GetComponent<SpringJoint>();
		oldSpring = GetComponent<SpringJoint>().spring;
	}
	
	private bool isAbsGreater(float a, float b)
	{
		return Mathf.Abs(a) > Mathf.Abs(b);
	}
}

