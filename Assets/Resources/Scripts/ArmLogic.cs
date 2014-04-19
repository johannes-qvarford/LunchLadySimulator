using UnityEngine;
using System.Collections;
using System;

public class ArmLogic : MonoBehaviour 
{
	public bool debug = true;
	public float movementSpeed = 0.05f;
	public float rotationSpeed = 2;
	public float maxGrabDistance = 0.3f;
	public float lowestArmHandleDegrees = 30;
	public float epsilon = 0.01f;
	public float minZRotFreeze = 0.01f;
	public float minMovementWithoutFreeze = 0.0025f;
	public float maxVelocity = 0.25f;
	public float framesUntilGiveUpSolidSolve = 60;
	public float solidRecoilMul = 1;
	public float maxRotRestrictionAngles = 30;
	public Vector3 moveOffsetOnGrab = new Vector3(0, 0.005f, 0);
	public ArmInputManager.Arm arm;
	
	public string handleName = "Handle";
	public string boundsName = "Bounds";
	public string grabableName = "Grabable";
	
	private Transform bounds;
	private Transform handle;
	private GameObject[] grabables; 
	private Transform heldGrabable = null;
	private bool insideSolid = false;
	public Vector3 lastPush = Vector3.zero;
	private int framesInsideSolid = 0;

	void FixedUpdate()
	{
		if(insideSolid && framesInsideSolid < framesUntilGiveUpSolidSolve)
		{
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation
				| (Mathf.Abs(lastPush.x) < minMovementWithoutFreeze ? RigidbodyConstraints.FreezePositionX : 0)
					| (Mathf.Abs(lastPush.y) < minMovementWithoutFreeze ? RigidbodyConstraints.FreezePositionY : 0)
					| (Mathf.Abs(lastPush.z) < minMovementWithoutFreeze ? RigidbodyConstraints.FreezePositionZ : 0);
		}
		else
		{
			{
				//x and z axis is backwards on the model
				float Z_ROTATION = -1 * rotationSpeed * 		
					ArmInputManager.GetMovement(arm, ArmInputManager.HORIZONTAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Z_ROTATION, arm)); 
				float X_MOVEMENT = -1 * movementSpeed * 
					ArmInputManager.GetMovement(arm, ArmInputManager.HORIZONTAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Z_ROTATION, arm) == false);
				float Y_MOVEMENT = movementSpeed * 		
					ArmInputManager.GetMovement(arm, ArmInputManager.VERTICAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Y_MOVEMENT, arm));
				float Z_MOVEMENT = -1 * movementSpeed * 
					ArmInputManager.GetMovement(arm, ArmInputManager.VERTICAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Y_MOVEMENT, arm) == false);
				
				/*float Z_DEG = minus180Plus180Degress(transform.eulerAngles.z);
				if((Z_DEG > -180 + maxRotRestrictionAngles && Z_ROTATION < 0)  
				|| (Z_DEG < 180 - maxRotRestrictionAngles && Z_ROTATION > 0 ))*/
				{
					rigidbody.AddTorque(Vector3.forward * Z_ROTATION * rotationSpeed);
				}
				
				Vector3 MOVEMENT = new Vector3(X_MOVEMENT, Y_MOVEMENT, Z_MOVEMENT);
				float FPS = 60;
				Vector3 OFFSET = (handle.position + MOVEMENT / FPS) - bounds.position;
				Vector3 LIMIT = bounds.localScale;
				
				int MOVING_INSIDE_X = Convert.ToInt32(Mathf.Abs(OFFSET.x) <= LIMIT.x);
				int MOVING_INSIDE_Y = Convert.ToInt32(Mathf.Abs(OFFSET.y) <= LIMIT.y);
				int MOVING_INSIDE_Z = Convert.ToInt32(Mathf.Abs(OFFSET.z) <= LIMIT.z);
				
				if(rigidbody.velocity.magnitude < maxVelocity) 
				{
					lastPush = new Vector3(MOVING_INSIDE_X * MOVEMENT.x, MOVING_INSIDE_Y * MOVEMENT.y, MOVING_INSIDE_Z * MOVEMENT.z);
					rigidbody.AddForce(lastPush, ForceMode.VelocityChange);
				}
				bool NO_X = Mathf.Abs(X_MOVEMENT) < minMovementWithoutFreeze;
				bool NO_Y = Mathf.Abs(Y_MOVEMENT) < minMovementWithoutFreeze;
				bool NO_Z = Mathf.Abs(Z_MOVEMENT) < minMovementWithoutFreeze;
				bool NO_R = Mathf.Abs(Z_ROTATION) < minZRotFreeze;
				
				rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY 
					| (NO_X ? RigidbodyConstraints.FreezePositionX : 0)
						| (NO_Y ? RigidbodyConstraints.FreezePositionY : 0)
						| (NO_Z ? RigidbodyConstraints.FreezePositionZ : 0)
						| (NO_R ? RigidbodyConstraints.FreezeRotationZ : 0);
			}
			
			//adjust inside movement box if gotten outside		
			{
				Vector3 BOUNDS = bounds.localScale;
				Vector3 OFFSET = handle.position - bounds.position;
				handle.position = bounds.position + 
					new Vector3(Mathf.Clamp(OFFSET.x, -BOUNDS.x, BOUNDS.x), 
						Mathf.Clamp(OFFSET.y, -BOUNDS.y, BOUNDS.y), 
						Mathf.Clamp(OFFSET.z, -BOUNDS.z, BOUNDS.z));
			}
			
			//fuck it, just let the engine solve it
			if(framesInsideSolid >= framesUntilGiveUpSolidSolve)
			{
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			}
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.gameObject.layer == LayerMask.NameToLayer("CoverFood") ||
		   collision.collider.gameObject.layer == LayerMask.NameToLayer("Cover"))
		{
			return;
		}
	
		if(collision.collider.tag == "SpawnArea")
		{
			handle.BroadcastMessage("OnSpawnStatusChanged", true);
			return;
		}
	
		if(lastPush.magnitude > minMovementWithoutFreeze && collision.collider.gameObject.layer != LayerMask.NameToLayer("Interact"))
		{
			Debug.Log("inside solid");
			framesInsideSolid = 0;
		}
	}
	
	void OnCollisionExit(Collision collision)
	{
		if(collision.collider.tag == "SpawnArea")
		{
			handle.BroadcastMessage("OnSpawnStatusChanged", false);
			return;
		}
	
		if(lastPush.magnitude > minMovementWithoutFreeze && collision.collider.gameObject.layer != LayerMask.NameToLayer("Interact"))
		{
			insideSolid = false;
			framesInsideSolid = 0;
		}
	}
	
	void OnCollisionStay(Collision collision)
	{
		if(insideSolid)
		{
			framesInsideSolid++;
			rigidbody.AddForce(new Vector3(solidRecoilMul * -lastPush.x, solidRecoilMul * -lastPush.y, solidRecoilMul * -lastPush.z), ForceMode.VelocityChange);
		}
	}
	
	void OnGUI()
	{
		if(debug)
		{
			GUI.TextArea(new Rect(0, 0, 100, 100), 
				ArmInputManager.IsOn(ArmInputManager.GRIP, arm) ? "GRAB ON" : "GRAB OFF");
			GUI.TextArea(new Rect(0, 100, 100, 100), 
				ArmInputManager.IsOn(ArmInputManager.Y_MOVEMENT, arm) ? "Y MOVEMENT ON" : "Y MOVEMENT OFF");
			GUI.TextArea(new Rect(0, 200, 100, 100), 
				ArmInputManager.IsOn(ArmInputManager.Z_ROTATION, arm) ? "Z_ROTATION ON" : "Z ROTATION OFF");
		}
	}
	
	void Start()
	{
		handle = transform.Find(handleName);
		bounds = transform.Find(boundsName);
		grabables = GameObject.FindGameObjectsWithTag(grabableName);
	}

	void Update()
	{
		bool GRAB_ON = ArmInputManager.IsOn(ArmInputManager.GRIP, arm);
		bool GRAB_TOGGLED = ArmInputManager.OnToggled(ArmInputManager.GRIP, arm);
		
		if(debug)
		{
			foreach (var g in grabables) 
			{
				Transform t = g.transform;
				Vector3 OFFSET = t.position - handle.position;
				Color COLOR = canBeGrabbed(t) ? Color.blue : Color.red;
				Debug.DrawLine(t.position, handle.position, COLOR);
			}
		}
		
		bool GRAB_RELEASED = GRAB_TOGGLED && GRAB_ON == false;
		if(GRAB_RELEASED && heldGrabable != null) 
		{
			setLayerRecursive(heldGrabable, LayerMask.NameToLayer("Interact"));
			heldGrabable.parent = null;
			heldGrabable.gameObject.AddComponent<Rigidbody>();
			heldGrabable = null;
		}
		
		if(GRAB_ON)
		{
			foreach(var g in grabables) 
			{
				Transform t = g.transform;
				if(canBeGrabbed(t))
				{
					heldGrabable = t;
					heldGrabable.forward = handle.forward;
					GameObject.Destroy(t.rigidbody);
					heldGrabable.parent = handle;
					heldGrabable.position += moveOffsetOnGrab;
					setLayerRecursive(heldGrabable, LayerMask.NameToLayer("Control"));
				}
			}
		}
	}
	
	bool areClose(Vector3 p, Vector3 v)
	{
		return Mathf.Abs(p.magnitude - v.magnitude) < epsilon;
	}
	
	bool canBeGrabbed(Transform t)
	{
		bool CLOSE_DISTANCE = (t.position - handle.position).magnitude < maxGrabDistance;
		bool CLOSE_ANGLE = (Vector3.Angle(t.right, handle.right)) < lowestArmHandleDegrees;
		bool OTHER_HAND_HOLDS = t.parent != null && 
			((arm == ArmInputManager.LEFT && t.parent.tag == "RightArm") || 
			 (arm == ArmInputManager.RIGHT && t.parent.tag == "LeftArm"));
		
		return CLOSE_ANGLE && CLOSE_DISTANCE && heldGrabable == null && OTHER_HAND_HOLDS == false;
	}
	
	float zero360Degrees(float deg)
	{
		return deg < 0 ? deg + 360 : deg;
	}
	
	float minus180Plus180Degress(float deg)
	{
		deg = (deg + 360) % 360;
		return deg >= 180 ? deg - 360 : deg;
	}
	
	Transform findWithTagRecursive(Transform t, string tag)
	{
		if(t.gameObject.tag == tag)
		{
			return t;
		}
		for(int i = 0; i < t.childCount; ++i)
		{
			Transform found = findWithTagRecursive(t.GetChild(i), tag);
			if(found != null)
			{
				return found;
			}
		}
		return null;
	}
	
	void setLayerRecursive(Transform t, int layer)
	{
		t.gameObject.layer = layer;
		for(int i = 0; i < t.childCount; ++i)
		{
			setLayerRecursive(t.GetChild(i), layer);
		}
	}
}
