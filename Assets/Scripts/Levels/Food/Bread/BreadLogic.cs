using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreadLogic : MonoBehaviour {
	public float breadMass;			//The mass of each slice
	public float spawnInTime = 1;	//A short delay before the bread can be cut again
	public GameObject[] slices;		//All the slices in order.
	private float startedTime;		//The time the object started
	GameObject left = null;		//The arms
	GameObject right = null;	//
	// Use this for initialization
	void Start () {
		startedTime = Time.time;
		left = GameObject.FindWithTag(Tags.LEFT_ARM);
		right = GameObject.FindWithTag(Tags.RIGHT_ARM);
	}
	void  OnCollisionStay(Collision collision)
	{
		calcCut (collision);
	}
	void  OnCollisionEnter(Collision collision)
	{
		calcCut (collision);
	}
	private void calcCut(Collision collision)
	{

		foreach (ContactPoint c in collision.contacts)
		{
			GameObject knife = c.otherCollider.gameObject;
			if(knife.GetComponent<CutBread>() == null)
			{
				continue;	//Not a knife
			}
			GameObject thisSlice = c.thisCollider.gameObject;
			if(thisSlice.tag == Tags.FOOD && thisSlice.GetComponent<FoodID>().foodID == "Bread")
			{
				BreadLogic breadScript;
				cutAtObject(thisSlice);
					return;
			}
		}
	}
	// Update is called once per frame
	private void recalc()
	{
		if (slices.Length < 1)
		{
			Destroy(this.gameObject);
			return;
		}
		else if(slices.Length == 1)
		{
			left = GameObject.FindWithTag(Tags.LEFT_ARM);
			right = GameObject.FindWithTag(Tags.RIGHT_ARM);
			if(slices[0].GetComponent<GrabableBehaviour>() == null)
			{
				return;
			}
			slices[0].layer = LayerMask.NameToLayer(Layers.GRABABLE);
			left.SendMessage("AddGrabable", slices[0], SendMessageOptions.RequireReceiver);
			right.SendMessage("AddGrabable", slices[0], SendMessageOptions.RequireReceiver);

		}
		((Rigidbody)gameObject.GetComponent(typeof(Rigidbody))).mass = slices.Length * breadMass;
		//Debug.Log (slices.Length + " breads.");
		//Vector3 newCenter = (slices [0].transform.localPosition + slices [slices.Length-1].transform.localPosition) / 2;
		//Vector3 newSize = slices [0].collider.bounds.size;
		//newSize.x *= slices.Length;
		//Bounds newBounds = new Bounds (newCenter, newSize);
		//this.gameObject.collider.setBounds = newBounds;
		//this.gameObject.collider.bounds.center = newCenter;
		//this.gameObject.collider.bounds.setSize(newSize/2);
		//this.gameObject.GetComponent<BoxCollider>().size = newSize*0.85f;
		//this.gameObject.GetComponent<BoxCollider>().center = newCenter;
	}
	private void rearangeCenter()
	{
		transform.DetachChildren();
		transform.localPosition = ((slices[0].transform.localPosition + slices[slices.Length -1].transform.localPosition)/2);
		foreach(GameObject slice in slices)
		{
			slice.transform.parent = transform;
		}
	}
	public void removeSlices(int start, bool forward)
	{
		List<GameObject> survivingBreads = new List<GameObject>();
		for(int i = 0; i < slices.Length; i++)
		{
			if((i > start) == forward)
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
			Destroy(this.gameObject);
			return;
		}
		recalc ();
		rearangeCenter ();
	}
	public void cutAtObject(GameObject cutSlice)
	{
		if(slices.Length > 1)
		{
			recalc ();
			for(int i = 0; i < slices.Length; i++)
			{
				if(slices[i] == cutSlice)
				{
					cutAtIndex(i);
					return;
				}
			}
		}
	}
	private void cutAtIndex(int place)
	{
		if(startedTime + spawnInTime < Time.time)
		{
			startedTime = Time.time;
			if(gameObject.GetComponent(typeof(PopIn)) != null)
			{
				Destroy (gameObject.GetComponent (typeof(PopIn)));
			}
			GameObject otherPart = Instantiate(this.gameObject, transform.position, transform.rotation) as GameObject;
			bool cuttingBool = place > (slices.Length / 2);
			if(this.gameObject != otherPart)
			{
				removeSlices (place, cuttingBool);
			}
			BreadLogic otherScript = (BreadLogic) otherPart.GetComponent(typeof(BreadLogic));
			otherScript.recalc();
			otherScript.removeSlices (place, !cuttingBool);
		}

	}
}
// */
