using System;
using UnityEngine;
using UnityExtensions;

/** Class that deals with the physics of the attached arm.
  * 
  * The script makes the following assumptions:
  * 	There is a rigidbody attached to the attached game object.
  * 	There is a SpringJoint attached to the attached game object.
  * 	There may exist child objects in the hand that are interested in collisions with game objects that have the Food tag.
  * 
  * This class rotates and moves the attached arm, stopping when moving into a solid unmoveable object like the workbench.
  * To achieve this it uses a hack described here:
  * 	The attached rigidbody has mass high enough that no interactable objects can move it on their own.
  * 	However, when a solid object pushes it out of a collision, 
  * 	it may do so in any direction, not just in the opposite direction that
  * 	the player moved it in.
  * 	To prevent this, the arm is freezed in all directions and rotation axices except those it's currently moving in.
  * 	To allow the arm to slow down during several frames when the player stops moving in a direction, the arm only freezes when
  * 	its rotation/movement magnitude falls below a certain threshhold.
  * 	If the arm somehow gets stuck inside a solid with its last push direction being the zero vector or just wrong,
  * 	all restriction are eventually removed, and then added back when the arm isn't stuck anymore.
  * 
  * Maintaining max arm distance:
  * 	When the arms gets to far from each other, 
  * 	a spring activates on the two arms that pull the arms towards their others springs
  * 		(Note: only a non freezed arm will be moved)
  * 		(Note: the spring on the other arm PULLS the CURRENT arm towards it)
  * 	The other spring is not activated if the arm is being rotated.
  * 
  * Bugs:
  * 	Right arm is not rotating as fast after releasing a previously held grabable despite no visible change to it, like mass.
  *		Arms frequently get stuck together because they are unstoppable and they freeze inside each other.
  * 	Arms are more unstoppable then NPC:s, and NPC:s HAS TO move around a frozen arm (maybe they shouldn't interact at all?)
  * 
  * TODO: break out FixedUpdate into seperate functions that are easier to understand on their own.
**/
public class ArmPhysics : MonoBehaviour
{
	public bool rightArm;
	public ArmsState armsState;
	public SpringJoint joint;
	public Transform handle;
	public SpringJoint otherJoint;
	public Transform otherHandle;
	
	private bool insideSolid = false;
	private int framesInsideSolid = 0;
	
	private Vector3 lastPush = Vector3.zero;
	
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
				float horizontal = ArmInputManager.MovementOnAxis(horizontal: true, rightArm: rightArm);
				float vertical = ArmInputManager.MovementOnAxis(horizontal: false, rightArm: rightArm);
				int zRotationHeld = Convert.ToInt32(ArmInputManager.IsHeld(ArmInputManager.Holdable.Z_ROTATION, rightArm));
				int zRotationNotHeld = zRotationHeld == 1 ? 0 : 1;
				int yMovementHeld = Convert.ToInt32(ArmInputManager.IsHeld(ArmInputManager.Holdable.Y_MOVEMENT, rightArm));
				int yMovementNotHeld = yMovementHeld == 1 ? 0 : 1;
				
				float zRotation = armsState.rotationAcceleration * -1 * horizontal * zRotationHeld;//reverse z direction 
				float xMovement = armsState.movementAcceleration * horizontal * zRotationNotHeld;
				float yMovement = armsState.movementAcceleration * vertical * yMovementHeld;
				float zMovement = armsState.movementAcceleration * vertical * yMovementNotHeld;

				int useZRotation = Convert.ToInt32(isAbsGreater(zRotation, yMovement) && isAbsGreater(zRotation, zMovement));
				int useYMovement = useZRotation == 1 ? 0 : 1;
				int useZMovement = useZRotation == 1 ? 0 : 1;
				
				{
					Vector3 handlesOffset = (otherHandle.position - transform.position);
					float handlesOffsetXY = new Vector2(handlesOffset.x, handlesOffset.y).magnitude;
					bool dontUseSpring = useZRotation == 1 || handlesOffsetXY < shortestDistanceUntilSpring;
					otherJoint.spring = dontUseSpring ? 0 : oldSpring;
				}
				
				{
					rigidbody.AddTorque(Vector3.forward * zRotation * useZRotation * armsState.rotationAcceleration);
				}

				{
					lastPush = new Vector3(xMovement, useYMovement * yMovement, useZMovement * zMovement);
					rigidbody.AddForce(lastPush, ForceMode.VelocityChange);
				}
				
				//freeze if input indicates that the arm should be accelerated at a low enough speed, or the current speed is low enough.
				{
					float hx = Mathf.Max(Mathf.Abs(rigidbody.velocity.x), Mathf.Abs(xMovement));
					float hy = Mathf.Max(Mathf.Abs(rigidbody.velocity.y), Mathf.Abs(yMovement));
					float hz = Mathf.Max(Mathf.Abs(rigidbody.velocity.z), Mathf.Abs(zMovement));
					float hrz = Mathf.Max(Mathf.Abs(rigidbody.angularVelocity.z), Mathf.Abs(zRotation));
					
					bool noX = hx < armsState.minMovementWithoutFreeze;
					bool noY = hy < armsState.minMovementWithoutFreeze;
					bool noZ = hz < armsState.minMovementWithoutFreeze;
					bool noR = hrz < armsState.minZRotWithoutFreeze;
					
					rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY 
						| (noX ? RigidbodyConstraints.FreezePositionX : 0)
							| (noY ? RigidbodyConstraints.FreezePositionY : 0)
							| (noZ ? RigidbodyConstraints.FreezePositionZ : 0)
							| (noR ? RigidbodyConstraints.FreezeRotationZ : 0);
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
		GameObject other = collision.collider.gameObject;
		if(other.IsFood())
		{
			handle.BroadcastMessage("OnCollisionEnter", collision, SendMessageOptions.DontRequireReceiver);
		}
		
		if(lastPush.magnitude > armsState.minMovementWithoutFreeze && other.IsSolid())
		{
			framesInsideSolid = 0;
		}
	}
	
	void OnCollisionExit(Collision collision)
	{
		GameObject other = collision.collider.gameObject;
		if(other.IsFood())
		{
			handle.BroadcastMessage("OnCollisionExit", collision, SendMessageOptions.DontRequireReceiver);
		}
		
		if(lastPush.magnitude > armsState.minMovementWithoutFreeze && other.IsSolid())
		{
			insideSolid = false;
			framesInsideSolid = 0;
		}
	}
	
	void OnCollisionStay(Collision collision)
	{
		GameObject other = collision.collider.gameObject;
		if(insideSolid)
		{
			framesInsideSolid++;
			rigidbody.AddForce(new Vector3(armsState.recoilMulOnSolidCollision * -lastPush.x, armsState.recoilMulOnSolidCollision * -lastPush.y, armsState.recoilMulOnSolidCollision * -lastPush.z), ForceMode.VelocityChange);
		}
		else if(other.IsFood())
		{
			handle.BroadcastMessage("OnCollisionStay", collision, SendMessageOptions.DontRequireReceiver);
		}
	}
	
	void Start()
	{
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

