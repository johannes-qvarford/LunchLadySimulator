using System;
using UnityEngine;

/** Class that deals with the physics of the attached arm.

	The script makes the following assumptions:
		The attached game object is an arm.
		The attached game object has a parent, and the parent has an attached ArmsState component.
		The parent has two children called "LeftArm" and "RightArm", and the attached game object is one of them.
		There exist another script on the attached game object that relies on this class calling its ArmChanged method 
			before its first Update call including information whether the attached arm is the left or the right one.
		There exist a handle child object to the arm with a given name, that represents the hand of the arm.
		There is a rigidbody attached to the attched game object.
		There is a SpringJoint attached to the attached game object.
		It's attached to a game object with a "LeftArm" or "RightArm" tag, and there exists
			another game object with the other tag. Both have an attached SpringJoint component.
		There may exist child objects in the hand that are interested in collisions with game objects that have the Food tag.

	This class rotates and moves the attached arm, stopping when moving into a solid unmoveable object like the workbench.
	To achieve this it uses a hack described here:
		The attached rigidbody has mass high enough that no interactable objects can move it on their own.
		However, when a solid object pushes it out of a collision, 
		it may do so in any direction, not just in the opposite direction that
		the player moved it in.
		To prevent this, the arm is freezed in all directions and rotation axices except those it's currently moving in.
		To allow the arm to slow down during several frames when the player stops moving in a direction, the arm only freezes when
		its rotation/movement magnitude falls below a certain threshhold.
		If the arm somehow gets stuck inside a solid with its last push direction being the zero vector or just wrong,
		all restriction are eventually removed, and then added back when the arm isn't stuck anymore.

	Maintaining max arm distance:
		When the arms gets to far from each other, 
		a spring activates on the two arms that pull the arms towards their others springs
			(Note: only a non freezed arm will be moved)
			(Note: the spring on the other arm PULLS the current arm towards it)
		The other spring is not activated if the arm is being rotated.

	Bugs:
		Right arm is not rotating as fast after releasing a previously held grabable despite no visible change to it, like mass.

	TODO: break out FixedUpdate into seperate functions that are easier to understand on their own.
**/
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
	private SpringJoint joint;
	private float shortestDistanceUntilSpring = 0;
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
					Vector3 OFFSET = (otherHandle.position - transform.position);
					float XY_MAGNITUDE = new Vector2(OFFSET.x, OFFSET.y).magnitude;
					
					otherJoint.spring = IUSE_Z_ROTATION == 1 || XY_MAGNITUDE < shortestDistanceUntilSpring ? 0 : oldSpring;
					rigidbody.AddTorque(Vector3.forward * Z_ROTATION * IUSE_Z_ROTATION * armsState.rotationAcceleration);
				}

				{
					lastPush = new Vector3(X_MOVEMENT, IUSE_Y_MOVEMENT * Y_MOVEMENT, IUSE_Z_MOVEMENT * Z_MOVEMENT);
					rigidbody.AddForce(lastPush, ForceMode.VelocityChange);
				}
				
				//freeze if input indicates that the arm should be accelerated at a low enough speed, or the current speed is low enough.
				{
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
		otherHandle = transform.parent.Find((arm == ArmInputManager.LEFT ? "RightArm" : "LeftArm")+ "/" + armsState.handleName);
		joint = GetComponent<SpringJoint>();
		otherJoint = otherHandle.parent.GetComponent<SpringJoint>();
		/*
			save the spring value, when it needs to be reapplied.
		*/
		oldSpring = joint.spring;
		shortestDistanceUntilSpring = joint.maxDistance;
	}
	
	private bool isAbsGreater(float a, float b)
	{
		return Mathf.Abs(a) > Mathf.Abs(b);
	}
}

