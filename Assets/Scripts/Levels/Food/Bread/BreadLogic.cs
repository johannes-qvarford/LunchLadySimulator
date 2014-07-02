using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityExtensions;

/**
 * Class for cutable bread.
 * When a knife touches a bread slice, the load is split into two new loafs where each half has half of the slices.
 * One slice loafs gets detroyed, and their single slice becomes grabable.
 * 
 * The class makes the following assumptions
 * * A knife has an attached CutBread component.
 * * The attached game object is parent to its slices.
 **/
public class BreadLogic : MonoBehaviour
{
	public float breadMass;			//The mass of each slice
	public float spawnInTime = 1;	//A short delay before the bread can be cut again
	public GameObject[] slices;		//All the slices in order.

	private float startedTime;		//The time the object started
	private GameObject arms;		//The arm
	private DoOncer getArmsOnce = new DoOncer();

	private const int NO_CUT_INDEX = -1;

	void Start()
	{
		startedTime = Time.time;
		
	}

	void  OnCollisionStay(Collision collision)
	{
		CalcCut(collision);
	}

	void  OnCollisionEnter(Collision collision)
	{
		CalcCut(collision);
	}

	private void CalcCut(Collision collision)
	{
		var sliceIndices = collision.contacts
			.Where((c) => c.otherCollider.IsKnife())
			.Select((c) => c.thisCollider.gameObject)
			.Where((g) => g.IsBreadSlice())
			.Select((g) => IndexOfCutSlice(g))
			.Where((i) => i != NO_CUT_INDEX);

		if(sliceIndices.Count() > 0)
		{
			CutAtIndex(sliceIndices.First());
		}
	}

	private void RecalculateMass()
	{
		((Rigidbody)gameObject.GetComponent(typeof(Rigidbody))).mass = slices.Length * breadMass;
	}

	private void MakeSingleBreadGrabable()
	{
		Debug.Log("making single grabable");
		if(slices[0].IsInactiveGrabable() == false)
		{
			return;
		}
		slices[0].layer = LayerMask.NameToLayer(Layers.GRABABLE);
		
		getArmsOnce.doOnce(() =>
		{
			arms = GameObject.FindWithTag(Tags.ARMS);
			if(arms == null)
			{
				Debug.LogError("could not find arms");
				Debug.DebugBreak();
			}
		});
		arms.SendMessage("AddGrabable", slices[0], SendMessageOptions.RequireReceiver);
	}

	private int IndexOfCutSlice(GameObject cutSlice)
	{
		for(int i = 0; i < slices.Length; i++)
		{
			if(slices[i] == cutSlice)
			{
				return i;
			}
		}
		return NO_CUT_INDEX;
	}
	
	private void CutAtIndex(int place)
	{
		if(startedTime + spawnInTime < Time.time)
		{
			startedTime = Time.time;
			
			/*
			 * If the loaf is popping in, remove the animation.
			 */
			if(gameObject.GetComponent<PopIn>() != null)
			{
				Destroy(gameObject.GetComponent<PopIn>());
			}
			
			/*
			 * Create duplicate, and then split both.
			 */
			GameObject otherPart = Instantiate(this.gameObject, transform.position, transform.rotation) as GameObject;
			SpawnedJunk.BecomeParentToGameObject(otherPart);
			BreadLogic otherScript = (BreadLogic) otherPart.GetComponent(typeof(BreadLogic));

			bool removeForward = place > (slices.Length / 2);
			removeSlices(place, removeForward);
			otherScript.removeSlices(place, !removeForward);
		}
	}

	private void removeSlices(int start, bool removeForward)
	{
		List<GameObject> survivingBreads = new List<GameObject>();
		for(int i = 0; i < slices.Length; i++)
		{
			if((i > start) == removeForward)
			{
				Destroy (slices[i]);
			}
			else
			{
				survivingBreads.Add(slices[i]);
			}
		}
		if(survivingBreads.Count > 0)
		{
			slices = new GameObject[survivingBreads.Count];
			for(int i = 0; i < survivingBreads.Count; i++)
			{
				slices[i] = survivingBreads[i];
			}
		}
		else
		{
			/*
			 * We have no slices, time to be removed.
			 */
			Destroy(this.gameObject);
			return;
		}

		RearangeCenter();

		if (slices.Length < 1)
		{
			Destroy(gameObject);
			return;
		}
		else if(slices.Length == 1)
		{
			MakeSingleBreadGrabable();
		}

		RecalculateMass();
	}

	private void RearangeCenter()
	{
		/*
		 * Detach children temporarily so that center point can be moved, then reparent them again. 
		 */
		transform.DetachChildren();
		transform.localPosition = ((slices[0].transform.localPosition + slices[slices.Length -1].transform.localPosition)/2);
		foreach(GameObject slice in slices)
		{
			slice.transform.parent = transform;
		}
	}
}

