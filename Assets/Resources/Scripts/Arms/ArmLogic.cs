using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class ArmLogic : MonoBehaviour 
{
	public ArmInputManager.Arm arm;
	
	private Transform bounds;
	private Transform handle;
	private List<GameObject> grabables; 
	private Transform heldGrabable = null;
	private ArmsState armsState;
	private GameObject debugSphere;
	private Transform otherHandle;
	
	void Start()
	{
		armsState = transform.parent.GetComponent(typeof(ArmsState)) as ArmsState;
		handle = transform.Find(armsState.handleName);
		
		bounds = transform.Find(armsState.boundsName);
		grabables = new List<GameObject>(Layers.FindGameObjectsInLayer(LayerMask.NameToLayer(Layers.GRABABLE)));
		if(armsState.debug)
		{
			debugSphere = GameObject.Instantiate(armsState.debugSphere) as GameObject;
			
			debugSphere.transform.localScale = new Vector3(armsState.maxGrabDistance, armsState.maxGrabDistance, armsState.maxGrabDistance);
			debugSphere.transform.parent = handle;
		}
		SendMessage("ArmChanged", arm, SendMessageOptions.RequireReceiver);
	}
	

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Joystick1Button9))
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
	
		Debug.DrawLine(handle.position, handle.position + Vector3.up * -1);
		grabables.RemoveAll((g) => g == null);

		bool GRAB_HELD = ArmInputManager.IsHeld(ArmInputManager.GRIP, arm);
		bool GRAB_CHANGED = ArmInputManager.HeldChanged(ArmInputManager.GRIP, arm);
		
		if(armsState.debug)
		{
			debugSphere.transform.localScale = new Vector3(armsState.maxGrabDistance, armsState.maxGrabDistance, armsState.maxGrabDistance);
			debugSphere.transform.localPosition = Vector3.zero;
			Collider[] overlaps = GrabableSphereCast();
			foreach(Collider overlap in overlaps)
			{
				Debug.DrawLine(handle.position, overlap.transform.position, Color.cyan);
			}
			
			bool canBeGrabbedByAny = false;
			foreach (var g in grabables) 
			{
				if(CanBeGrabbed(g, overlaps))
				{
					debugSphere.renderer.material = Resources.Load("Materials/DebugCloseToGrabable", typeof(Material)) as Material;
					canBeGrabbedByAny = true;
					break;
				}
			}
			if(canBeGrabbedByAny == false)
			{
				debugSphere.renderer.material = Resources.Load("Materials/DebugFarFromGrabable", typeof(Material)) as Material;
			}
		}
		
		bool GRAB_RELEASED = GRAB_CHANGED && GRAB_HELD == true && heldGrabable != null;
		bool GRAB_GRABBED = GRAB_CHANGED && GRAB_HELD == true && heldGrabable == null;

		if(GRAB_RELEASED)
		{
			ReleaseHeldGrabable();
		}
		else if(GRAB_GRABBED)
		{
			Collider[] overlaps = GrabableSphereCast();
			List<GameObject> inReach = new List<GameObject>();
			foreach(var g in grabables) 
			{
				//Debug.Log("" + g + " can be grabbed");
				if(CanBeGrabbed(g, overlaps))
				{
					inReach.Add(g);
				}
			}
			
			if(inReach.Count > 0)
			{
				GameObject closest = null;
				foreach(GameObject g in inReach)
				{
					closest = 
						closest == null || (closest.transform.position - handle.position).magnitude > (g.transform.position - handle.position).magnitude 
						? g : closest;
				}
				switch(closest.tag)
				{
					case Tags.TOOL:
					case Tags.FOOD:
					case Tags.PLATE:
						Debug.Log("about to grab " + closest.tag);
						GrabObject(closest);
						break;
					case Tags.SPAWN_STACK:
						GrabFromSpawnStack(closest);
						break;
					default:
						Debug.LogError("held object with unexpected tag " + closest.tag);
						Debug.DebugBreak();
						break;
				}
			}

			if(heldGrabable != null && grabables.Exists((g) => g.Equals(heldGrabable)) == false)
			{
				grabables.Add(heldGrabable.gameObject);
			}
		}
	}
	
	private bool AreClose(Vector3 p, Vector3 v)
	{
		return Mathf.Abs(p.magnitude - v.magnitude) < armsState.epsilon;
	}
	
	private bool CanBeGrabbed(GameObject g, Collider[] overlaps)
	{
		bool inProximity = false;
		foreach(Collider overlap in overlaps)
		{
			if(ClosestGrabableParent(overlap.transform).gameObject == g)
			{
				inProximity = true;
			}
		}
		bool OTHER_HAND_HOLDS = g.transform.parent != null && g.transform.parent.parent != null &&
			((arm == ArmInputManager.LEFT && g.transform.parent.parent.tag == "RightArm") || 
			 (arm == ArmInputManager.RIGHT && g.transform.parent.parent.tag == "LeftArm"));
		
		return inProximity && heldGrabable == null && OTHER_HAND_HOLDS == false;
	}
	
	private Transform ClosestGrabableParent(Transform t)
	{
		return 	t.gameObject.layer == LayerMask.NameToLayer(Layers.GRABABLE) ? t :
				t.parent != null ? ClosestGrabableParent(t.parent) : null;
			
	}
	
	private void GrabObject(GameObject g)
	{
		GrabableBehaviour BEHAVIOUR = g.GetComponent<GrabableBehaviour>();
		heldGrabable = g.transform;
		GameObject.Destroy(heldGrabable.rigidbody);
		heldGrabable.parent = handle;
		heldGrabable.position += BEHAVIOUR.moveOffsetOnGrab;
		Layers.SetLayerRecursive(heldGrabable, LayerMask.NameToLayer(Layers.CONTROL));
	}
	
	private void GrabFromSpawnStack(GameObject stack)
	{
		SpawnStackBehaviour FSB = stack.GetComponent<SpawnStackBehaviour>();
		GameObject PREFAB = FSB.spawnPrefab;
		Vector3 OFFSET = FSB.spawnOffsetFromHand;
		//Debug.Log(OFFSET);
		heldGrabable = ((GameObject)GameObject.Instantiate(PREFAB)).transform;
		var shadow = ((GameObject)GameObject.Instantiate(FSB.spawnShadow));
		heldGrabable.transform.position = handle.position;
		shadow.transform.position = heldGrabable.position;
		ShadowPlaneFollowing followScript = shadow.GetComponent<ShadowPlaneFollowing> ();
		followScript.m_parent = heldGrabable;
		GameObject.Destroy(heldGrabable.rigidbody);
		heldGrabable.transform.parent = handle;
		heldGrabable.transform.position += OFFSET;
		heldGrabable.gameObject.layer = LayerMask.NameToLayer(Layers.CONTROL);
	}
	
	private Collider[] GrabableSphereCast()
	{
		return Physics.OverlapSphere(
			//position:
			handle.position, 
			//radius:
			armsState.maxGrabDistance,
		    //layerMask:
		    Layers.CombineLayerNames(Layers.GRABABLE, Layers.INTERACT)
		    );
	}
	
	private float Minus180Plus180Degress(float deg)
	{
		deg = (deg + 360) % 360;
		return deg >= 180 ? deg - 360 : deg;
	}
	
	private void ReleaseHeldGrabable()
	{
		Layers.SetLayerRecursive(heldGrabable, Layers.INTERACT);
		heldGrabable.gameObject.layer = LayerMask.NameToLayer(Layers.GRABABLE);
		heldGrabable.parent = null;
		heldGrabable.gameObject.AddComponent(typeof(Rigidbody));
		heldGrabable.rigidbody.velocity = rigidbody.velocity * armsState.throwVelocityMul;
		heldGrabable = null;
	}
	
	private float Zero360Degrees(float deg)
	{
		return deg < 0 ? deg + 360 : deg;
	}
}
