using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

using UnityExtensions;

/** Class that manages the possible object (grabable) that an arms hand might hold, and the closest grabable in reach.

	This class makes a lot of assumptions about the state of the game.
	If any of these assumptions doesn't hold in the future, 
		the assumption needs to be removed, and the code changed to not make that assumption anymore.

	The script makes the following assumptions:
		The attached game object has a parent, and the parent has an attached ArmsState component.
		There exist another script on the attached game object that has a ArmChanged method.
		There exist a handle child object to the arm with a given name, that represents the hand of the arm.
		There is a trigger collider near the area of the hand where grabables can be grabbed.
		It's attached to a game object with a "LeftArm" or "RightArm" tag, and there exists
			another game object with the other tag.

	The following assumptions are made about the abstract game object type "grabable":
		A grabable is in a layer named "Grabable"
		A grabable has a child named "Shadow", and for any ungrabbed grabables its on the layer "ShadowPlane".
		All other children is in the "Interact" layer.
		A grabable has a rigidbody and not in a parent object.
		A grabables rigidbody has Unity's default rigidbody values.
		A grabable has a GrabableBehaviour component.
		A grabable makes no assumptions about its parent when not grabbed
		A grabable may have a number of scripts with "void OnGrabbed()" methods.

	When an arms hand grabs a grabable the following happens:
		The grabables rigidbody is removed. 
		All of its childrens' layers are changed (except Shadow) to Control.
		It's is childed to the hand, to "become part of the arm".
	
	When an arms hand releases a grabable, the following happens:
		The grabables rigidbody is added back.
		its and all of its childrens' layers are changed back to their original layers.
		It's childed to the root game object (null)
		It's thrown away in the direction that the arm was moving (none if arm is still).

	TODO: fix function names to follow name standard.

	TODO: create or modify existing script to make and possible check assumptions about grabables, 
		and perform actions on them that require these assumptions, 
		to reduce the complexity of this class and hide its implementation details.
		For instance, change GrabableBehaviour to have OnGrabbed and OnReleased methods that deal with
		grabbing and releasing.

	TODO: fix class to remove assumption on child layers of grabables and its rigidbody.
**/
public class ArmLogic : MonoBehaviour 
{
	public ArmInputManager.Arm arm;
	public Material outlineMaterial;
	public Material invisibleMaterial;
	
	private Transform bounds;
	private Transform handle;
	private Transform heldGrabable = null;
	/*
		Unessesary member, but some scripts current require this to exist.

		TODO: removed this member and all it's depencies and change them to use "heldGrabable" instead.
	*/
	public string heldGrabableName = "null";

	private ArmsState armsState;
	private GameObject debugSphere;
	private Transform otherHandle;
	private Renderer lastOutline;
	private GameObject prevClosest = null;

	private Dictionary<GameObject, int> grabablesInRange = new Dictionary<GameObject, int>();

	
	private int enterCount = 0;
	private int exitCount = 0;
	
	void OnTriggerEnter(Collider col)
	{
		Transform GRABABLE = col.FindAncestor((t) => t.gameObject.layer == LayerMask.NameToLayer(Layers.GRABABLE));
		if(GRABABLE != null)
		{
			enterCount++;
			int count;
			if(grabablesInRange.TryGetValue(GRABABLE.gameObject, out count))
			{
				grabablesInRange[GRABABLE.gameObject] =  count+1;
			}
			else
			{
				grabablesInRange.Add(GRABABLE.gameObject, 1);
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		Transform GRABABLE = col.FindAncestor((t) => t.gameObject.layer == LayerMask.NameToLayer(Layers.GRABABLE));
		if(GRABABLE != null)
		{
			exitCount++;
			
			int count;
			if(grabablesInRange.TryGetValue(GRABABLE.gameObject, out count))
			{
				if(count == 1)
				{
					grabablesInRange.Remove(GRABABLE.gameObject);
				}
				else
				{
					grabablesInRange[GRABABLE.gameObject] =  count-1;
				}
			}
		}
	}
	
	public void AddGrabable(GameObject g)
	{
		if(g.GetComponent<GrabableBehaviour>() == null)
		{
			Debug.LogError("tried to add non grabable gameobject");
		}
		/* 	The first time AddGrabable is called, this script instance may not have yet been intialized and armsState may be null.
			Therefor, this code is duplicated in Start and AddGrabable.

			TODO: break out common code into a function like InitIfHasNot.
		*/
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

		SendMessage("ArmChanged", arm, SendMessageOptions.RequireReceiver);
	}
	

	void Update()
	{
		Debug.DrawLine(handle.position, handle.position + Vector3.up * -1);
		
		/* 	Destroyed game objects overload the identity test to return null.
			This removes grabables that have been destroyed during the past frame.
		*/
		armsState.grabables.RemoveAll((g) => g == null);

		bool GRAB_HELD = ArmInputManager.IsHeld(ArmInputManager.GRIP, arm);
		bool GRAB_CHANGED = ArmInputManager.HeldChanged(ArmInputManager.GRIP, arm);
		
		bool GRAB_RELEASED = GRAB_CHANGED && GRAB_HELD == true && heldGrabable != null;
		bool GRAB_GRABBED = GRAB_CHANGED && GRAB_HELD == true && heldGrabable == null;

		if(GRAB_RELEASED)
		{
			ReleaseHeldGrabable();
		}
		
		GameObject closest = getClosestGrabable();
		handleOutlines(closest);
		prevClosest = closest;
		
		if(GRAB_GRABBED)
		{
			if(closest != null)
			{
				GrabObject(closest);
			}

			/** Add grabables to list of known grabables.

				TODO: determine if this is neccesary anymore, and comment why, if that's the case.
			**/
			if(heldGrabable != null && armsState.grabables.Exists((g) => g.Equals(heldGrabable)) == false)
			{
				armsState.grabables.Add(heldGrabable.gameObject);
			}
		}
	}
	
	private void handleOutlines(GameObject closest)
	{
		/** Remove outline from objects that were previously closest to the hand,
			Add outlines to closest object, if not holding an object already.
		**/
		if(prevClosest != null)
		{
			prevClosest.GetComponent<GrabableBehaviour>().outline.material = invisibleMaterial;
		}
		if(closest != null && heldGrabable == null)
		{
			closest.GetComponent<GrabableBehaviour>().outline.material = outlineMaterial;
		}
	}
	
	private GameObject getClosestGrabable()
	{
		var can = grabablesInRange.Keys.Where((g) => g != null);
		if(can.Count() > 0)
		{
			Func<GameObject, float> distance = (g) => (g.transform.position - handle.position).magnitude;
			/*
				TODO: determine if Where clause is neccesseary, and comment why if that's the case.
			*/
			return can.Where((g) => g != null).Aggregate((a,b) => distance(a) < distance(b) ? a : b);
		}
		else
		{
			return null;
		}
	}

	private bool AreClose(Vector3 p, Vector3 v)
	{
		return Mathf.Abs(p.magnitude - v.magnitude) < armsState.epsilon;
	}
	
	/**
		TODO: remove method as it's not used anymore.
	**/
	private bool CanBeGrabbed(GameObject g, Collider[] overlaps)
	{
		Vector2 hxz = new Vector2(handle.position.x, handle.position.z);
		float hy = handle.position.y;
	
		bool inProximity = new List<Collider>(overlaps).Exists((o) =>
		{
			Transform closestGrabableParent = o.FindAncestor((t) => t.gameObject.layer == LayerMask.NameToLayer(Layers.GRABABLE));
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
	
	private void GrabObject(GameObject g)
	{
		GrabableBehaviour BEHAVIOUR = g.GetComponent<GrabableBehaviour>();
		heldGrabable = g.transform;
		
		grabablesInRange.Remove(heldGrabable.gameObject);
		
		GameObject.Destroy(heldGrabable.rigidbody);
		heldGrabable.parent = handle;
		/**
			TODO: remove offset movement, as no grabables should be moved when grabbed.
		**/
		heldGrabable.position += BEHAVIOUR.moveOffsetOnGrab;
		Layers.SetLayerRecursive(heldGrabable, LayerMask.NameToLayer(Layers.CONTROL));
		heldGrabable.Find("Shadow").gameObject.layer = LayerMask.NameToLayer(Layers.SHADOW_PLANE);
		heldGrabableName = heldGrabable.ToString();
	}
	
	private void ReleaseHeldGrabable()
	{
		grabablesInRange.Remove(heldGrabable.gameObject);
		heldGrabable.GetComponent<GrabableBehaviour>().outline.material = invisibleMaterial;
		prevClosest = heldGrabable.gameObject;
		Layers.SetLayerRecursive(heldGrabable, Layers.INTERACT);
		heldGrabable.gameObject.layer = LayerMask.NameToLayer(Layers.GRABABLE);
		heldGrabable.Find("Shadow").gameObject.layer = LayerMask.NameToLayer(Layers.SHADOW_PLANE);
		heldGrabable.parent = null;
		heldGrabable.gameObject.AddComponent(typeof(Rigidbody));
		heldGrabable.SendMessage("OnGrabbed", SendMessageOptions.DontRequireReceiver);
		heldGrabable.rigidbody.velocity = rigidbody.velocity * armsState.throwVelocityMul;
		heldGrabable = null;
		heldGrabableName = "null";
	}
}
