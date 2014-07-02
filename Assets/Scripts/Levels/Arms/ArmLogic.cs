using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

using UnityExtensions;

/** 
  * Class that manages the possible object (grabable) that an arms hand might hold, and the closest grabable in reach.
  * 
  * This class makes a lot of assumptions about the state of the game.
  * If any of these assumptions doesn't hold in the future, 
  * the assumption needs to be removed, and the code changed to not make that assumption anymore.
  * 
  * The script makes the following assumptions:
  * 	There is a trigger collider near the area of the hand where grabables can be grabbed.
  * 
  * The following assumptions are made about the abstract game object type "grabable":
  * 	A grabable has a child named "Shadow", and for any ungrabbed grabables its on the layer "ShadowPlane".
  * 	All other children is in the "Interact" layer.
  * 	A grabable has a rigidbody and not in a parent object.
  * 	A grabables rigidbody has Unity's default rigidbody values.
  * 	A grabable makes no assumptions about its parent when not grabbed
  * 	A grabable may have a number of scripts with "void OnGrabbed()" methods.
  * 
  * When an arms hand grabs a grabable the following happens:
  * 	The grabables rigidbody is removed.
  * 	All of its childrens' layers are changed (except Shadow) to Control.
  * 	It's is childed to the hand, to "become part of the arm".
  * 
  * When an arms hand releases a grabable, the following happens:
  * 	The grabables rigidbody is added back.
  * 	its and all of its childrens' layers are changed back to their original layers.
  * 	It's childed to the root game object (null)
  * 	It's thrown away in the direction that the arm was moving (none if arm is still).
  * 
  * TODO: create or modify existing script to make it possible check assumptions about grabables, 
  * 	and perform actions on them that require these assumptions, 
  * 	to reduce the complexity of this class and hide its implementation details.
  * 	For instance, change GrabableBehaviour to have OnGrabbed and OnReleased methods that deal with
  * 	grabbing and releasing (instead of using GrabGrabable() and ReleateHeldGrabable().
  * 
  * TODO: fix class to remove assumption on child layers of grabables and its rigidbody.
  **/
public class ArmLogic : MonoBehaviour 
{
	public bool rightArm;
	public ArmsState armsState;
	public Transform handle;
	public Transform otherHandle;
	
	public Material outlineMaterial;
	public Material invisibleMaterial;
	
	public Transform heldGrabable = null;

	private Renderer lastOutline;
	private GameObject prevClosest = null;
	private Dictionary<GameObject, int> grabablesInRange = new Dictionary<GameObject, int>();
	private int enterCount = 0;
	private int exitCount = 0;
	
	void OnTriggerEnter(Collider col)
	{
		Transform colGrabable = col.FindAncestorOrSelf((t) => t.IsActiveGrabable());
		if(colGrabable != null)
		{
			enterCount++;
			int count;
			if(grabablesInRange.TryGetValue(colGrabable.gameObject, out count))
			{
				grabablesInRange[colGrabable.gameObject] =  count + 1;
			}
			else
			{
				grabablesInRange.Add(colGrabable.gameObject, 1);
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		Transform grabable = col.FindAncestorOrSelf((t) => t.gameObject.layer == LayerMask.NameToLayer(Layers.GRABABLE));
		if(grabable != null)
		{
			exitCount++;
			
			int count;
			if(grabablesInRange.TryGetValue(grabable.gameObject, out count))
			{
				if(count == 1)
				{
					grabablesInRange.Remove(grabable.gameObject);
				}
				else
				{
					grabablesInRange[grabable.gameObject] =  count - 1;
				}
			}
		}
	}
	
	void Start()
	{
		if(armsState == null)
		{
			armsState = transform.parent.GetComponent(typeof(ArmsState)) as ArmsState;
		}
	}

	void Update()
	{
		Debug.DrawLine(handle.position, handle.position + Vector3.up * -1);
		
		/* 	
		 * Destroyed game objects overload the identity test to return null.
		 * This removes grabables that have been destroyed during the past frame.
		*/
		armsState.grabables.RemoveAll((g) => g == null);

		bool released = ArmInputManager.IsGripPressed(rightArm) && heldGrabable != null;
		bool grabbed = ArmInputManager.IsGripPressed(rightArm) && heldGrabable == null;

		if(released)
		{
			ReleaseHeldGrabable();
		}
		
		GameObject closest = GetClosestGrabable();
		HandleOutlines(closest);
		prevClosest = closest;
		
		if(grabbed)
		{
			if(closest != null)
			{
				GrabGrabable(closest);
			}

			/* Add grabables to list of known grabables, as it was removed when it was grabbed.
			 */
			if(heldGrabable != null && armsState.grabables.Exists((g) => g.Equals(heldGrabable)) == false)
			{
				armsState.grabables.Add(heldGrabable.gameObject);
			}
		}
	}
	
	private void HandleOutlines(GameObject closest)
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
	
	private GameObject GetClosestGrabable()
	{
		var can = grabablesInRange.Keys.Where((g) => g != null);
		if(can.Count() > 0)
		{
			Func<GameObject, float> distance = (g) => (g.transform.position - handle.position).magnitude;
			return can.Aggregate((a,b) => distance(a) < distance(b) ? a : b);
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
	
	private void GrabGrabable(GameObject g)
	{
		GrabableBehaviour BEHAVIOUR = g.GetComponent<GrabableBehaviour>();
		heldGrabable = g.transform;
		
		grabablesInRange.Remove(heldGrabable.gameObject);
		
		GameObject.Destroy(heldGrabable.rigidbody);
		heldGrabable.parent = handle;
		SetLayerRecursive(heldGrabable.gameObject, Layers.CONTROL);
		heldGrabable.Find("Shadow").gameObject.layer = LayerMask.NameToLayer(Layers.SHADOW_PLANE);
	}
	
	private void ReleaseHeldGrabable()
	{
		grabablesInRange.Remove(heldGrabable.gameObject);
		heldGrabable.GetComponent<GrabableBehaviour>().outline.material = invisibleMaterial;
		prevClosest = heldGrabable.gameObject;
		SetLayerRecursive(heldGrabable.gameObject, Layers.INTERACT);
		
		heldGrabable.gameObject.layer = LayerMask.NameToLayer(Layers.GRABABLE);
		heldGrabable.Find("Shadow").gameObject.layer = LayerMask.NameToLayer(Layers.SHADOW_PLANE);
		heldGrabable.parent = null;
		heldGrabable.gameObject.AddComponent(typeof(Rigidbody));
		heldGrabable.SendMessage("OnGrabbed", SendMessageOptions.DontRequireReceiver);
		heldGrabable.rigidbody.velocity = rigidbody.velocity * armsState.throwVelocityMul;
		heldGrabable = null;
	}
	
	private void SetLayerRecursive(GameObject g, string layerName)
	{
		foreach(Transform t in g.AllChildren().Union(new []{ g.transform }))
		{
			t.gameObject.layer = LayerMask.NameToLayer(layerName);
		}
	}
}
