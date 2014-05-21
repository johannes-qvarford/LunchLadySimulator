using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

using UnityExtensions;

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
		if(ArmInputManager.IsDown(ArmInputManager.Action.RESTART_LEVEL))
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
	
		Debug.DrawLine(handle.position, handle.position + Vector3.up * -1);
		armsState.grabables.RemoveAll((g) => g == null);
		//grabablesInRange.Remove(null);
		
		foreach(var g in grabablesInRange)
		{
			Debug.LogWarning(string.Format("name {0} count {1}", g.Key, g.Value));
		}
		

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

			if(heldGrabable != null && armsState.grabables.Exists((g) => g.Equals(heldGrabable)) == false)
			{
				armsState.grabables.Add(heldGrabable.gameObject);
			}
		}
	}
	
	private void handleOutlines(GameObject closest)
	{
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
		var can = grabablesInRange.Keys;
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
	
	private bool CanBeGrabbed(GameObject g, Collider[] overlaps)
	{
		Vector2 hxz = new Vector2(handle.position.x, handle.position.z);
		float hy = handle.position.y;
	
		bool inProximity = new List<Collider>(overlaps).Exists((o) => {
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
		heldGrabable.position += BEHAVIOUR.moveOffsetOnGrab;
		Layers.SetLayerRecursive(heldGrabable, LayerMask.NameToLayer(Layers.CONTROL));
		heldGrabable.Find("Shadow").gameObject.layer = LayerMask.NameToLayer(Layers.SHADOW_PLANE);
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
		heldGrabable.rigidbody.velocity = rigidbody.velocity * armsState.throwVelocityMul;
		heldGrabable = null;
	}
}
