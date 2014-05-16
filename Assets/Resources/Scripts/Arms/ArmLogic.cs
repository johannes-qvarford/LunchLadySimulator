using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class ArmLogic : MonoBehaviour 
{
	public ArmInputManager.Arm arm;
	public Material outlineMaterial;
	public Material invisibleMaterial;
	
	private Transform bounds;
	private Transform handle;
	//public List<GameObject> grabables; 
	private Transform heldGrabable = null;
	private ArmsState armsState;
	private GameObject debugSphere;
	private Transform otherHandle;
	private Renderer lastOutline;

	
	public void AddGrabable(GameObject g)
	{
		if(g.GetComponent<GrabableBehaviour>() == null)
		{
			Debug.LogError("tried to add non grabable gameobject");
		}
		if(armsState == null)
		{
			armsState = transform.parent.GetComponent(typeof(ArmsState)) as ArmsState;
		}
		armsState.grabables.Add(g);
	}
	
	void Start()
	{
		if(armsState == null)
		{
			armsState = transform.parent.GetComponent(typeof(ArmsState)) as ArmsState;
		}
		handle = transform.Find(armsState.handleName);
		
		bounds = transform.Find(armsState.boundsName);

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
		armsState.grabables.RemoveAll((g) => g == null);

		bool GRAB_HELD = ArmInputManager.IsHeld(ArmInputManager.GRIP, arm);
		bool GRAB_CHANGED = ArmInputManager.HeldChanged(ArmInputManager.GRIP, arm);
		
		bool GRAB_RELEASED = GRAB_CHANGED && GRAB_HELD == true && heldGrabable != null;
		bool GRAB_GRABBED = GRAB_CHANGED && GRAB_HELD == true && heldGrabable == null;

		GameObject closest = getClosestGrabable();
		
		handleOutlines(closest);
		if(GRAB_RELEASED)
		{
			ReleaseHeldGrabable();
		}


		else if(GRAB_GRABBED)
		{
			if(closest != null)
			{

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

			if(heldGrabable != null && armsState.grabables.Exists((g) => g.Equals(heldGrabable)) == false)
			{
				armsState.grabables.Add(heldGrabable.gameObject);
			}
		}
	}
	private void handleOutlines(GameObject closest)
	{
		Renderer newOutline = null;
		if(closest != null && closest.GetComponent("GrabableBehaviour") != null)
		{
			newOutline = ((GrabableBehaviour)closest.GetComponent("GrabableBehaviour")).outline;
		}
		if(lastOutline == newOutline)
		{
			//return;
		}
		if(lastOutline != null && lastOutline.sharedMaterial == outlineMaterial)
		{
			lastOutline.material = invisibleMaterial;
		}
		if(newOutline != null)
		{
			newOutline.material = outlineMaterial;
		}
		lastOutline = newOutline;
	}
	private GameObject getClosestGrabable()
	{
		var sphereCols = GrabableSphereCast();
		var can = from g in armsState.grabables where CanBeGrabbed(g, sphereCols) select g;
		if(can.Count() > 0)
		{
			return can.Aggregate((a,b) => (a.transform.position - handle.position).magnitude < (b.transform.position - handle.position).magnitude ? a : b);
		}
		else
		{
			return null;
		}
	/*
		GameObject closest = null;
		Collider[] overlaps = GrabableSphereCast();
		List<GameObject> inReach = new List<GameObject>();
		foreach(var g in armsState.grabables) 
		{
			//Debug.Log("" + g + " can be grabbed");
			if(CanBeGrabbed(g, overlaps))
			{
				inReach.Add(g);
			}
		}
		if(inReach.Count > 0)
		{
			closest = null;
			foreach(GameObject g in inReach)
			{
				closest = 
					closest == null || (closest.transform.position - handle.position).magnitude > (g.transform.position - handle.position).magnitude 
						? g : closest;
			}
		}
		return closest;
	*/
	}

	private bool AreClose(Vector3 p, Vector3 v)
	{
		return Mathf.Abs(p.magnitude - v.magnitude) < armsState.epsilon;
	}
	
	private bool CanBeGrabbed(GameObject g, Collider[] overlaps)
	{
		Vector2 hxz = new Vector2(handle.position.x, handle.position.z);
		float hy = handle.position.y;
	
		bool inProximity = new List<Collider>(overlaps).Exists((o) => {
			Transform closestGrabableParent = ClosestGrabableParent(o.transform);
			if(closestGrabableParent == null || closestGrabableParent.gameObject != g)
			{
				return false;
			}
			else
			{
				Vector2 xz = new Vector2(closestGrabableParent.position.x, closestGrabableParent.position.z);
				float y = closestGrabableParent.position.y;
				return (xz-hxz).magnitude < armsState.grabCylinderRadius && (hy-y) > 0 && (hy-y) < armsState.grabCylinderHeight;
			}
		});
		
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
		Debug.Log("offset " + OFFSET);
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
