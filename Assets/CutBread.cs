using UnityEngine;
using System.Collections;
using System.Linq;

public class CutBread : MonoBehaviour
{
	public float lowestSpeedForCut = 0.1f;
	GameObject left;
	GameObject right;
	
	void Start()
	{
		left = GameObject.FindWithTag(Tags.LEFT_ARM);
		right = GameObject.FindWithTag(Tags.RIGHT_ARM);
	}
	
	void OnCollisionStay(Collision col)
	{
		GameObject OTHER = col.gameObject;
		if(OTHER.tag == Tags.FOOD && OTHER.GetComponent<FoodID>().foodID == "Bread" && FindParentRigidbody(gameObject).velocity.magnitude > lowestSpeedForCut)
		{
			if(OTHER.GetComponents<FixedJoint>().Count() == 0)
			{
				return;
			}
			Debug.Log(FindParentRigidbody(gameObject).velocity.magnitude);
			
			var joints = OTHER.GetComponents<FixedJoint>();
			var connected = from j in joints select j.connectedBody;
			foreach(FixedJoint j in joints)
			{
				GameObject.Destroy(j);
			}
			
			OTHER.rigidbody.constraints = RigidbodyConstraints.None;
			OTHER.layer = LayerMask.NameToLayer(Layers.GRABABLE);
			
			left.SendMessage("AddGrabable", OTHER, SendMessageOptions.RequireReceiver);
			right.SendMessage("AddGrabable", OTHER, SendMessageOptions.RequireReceiver);
			
			foreach(var c in connected)
			{
				var otherJoints = c.GetComponents<FixedJoint>();
				int count = otherJoints.Count();
				foreach(var j in otherJoints)
				{
					if(j.connectedBody == OTHER.rigidbody)
					{
						GameObject.Destroy(j);
						count--;
					}
				}
				if(count == 0)
				{
					c.rigidbody.constraints = RigidbodyConstraints.None;
					c.gameObject.layer = LayerMask.NameToLayer(Layers.GRABABLE);
					left.SendMessage("AddGrabable", c.gameObject, SendMessageOptions.RequireReceiver);
					right.SendMessage("AddGrabable", c.gameObject, SendMessageOptions.RequireReceiver);
				}
			}
			GameObject.Destroy(OTHER.GetComponent<ConfigurableJoint>());
		}
	}
	
	Rigidbody FindParentRigidbody(GameObject g)
	{
		Transform t = g.transform;
		do
		{
			Rigidbody r = t.GetComponent<Rigidbody>();
			if(r != null)
			{
				return r;
			}
			t = t.parent;
		} while(t != null);
		Debug.LogError("could not find rigidbody on child to bread");
		return null;
	}
}
