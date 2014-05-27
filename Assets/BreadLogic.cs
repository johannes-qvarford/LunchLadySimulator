using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreadLogic : MonoBehaviour {
	public float breadMass;
	public float spawnInTime = 1;
	public GameObject[] slices;
	private int numberOfSlices;
	private bool started;
	private float startedTime;
	private int shouldRemove;
	private GameObject otherPart;
	GameObject left = null;
	GameObject right = null;
	// Use this for initialization
	void Start () {
		startedTime = Time.time;
		shouldRemove = 0;
		numberOfSlices = slices.Length;
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
				continue;
			}
			GameObject OTHER = c.thisCollider.gameObject;
			if(OTHER.tag == Tags.FOOD && OTHER.GetComponent<FoodID>().foodID == "Bread")
			{
				BreadLogic breadScript;
				cutAtObject(OTHER);
					return;
			}
		}
	}
	// Update is called once per frame
	private void recalc()
	{
		numberOfSlices = slices.Length;
		if (numberOfSlices < 1)
		{
			Destroy(this.gameObject);
			return;
		}
		else if(numberOfSlices == 1)
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
		((Rigidbody)gameObject.GetComponent(typeof(Rigidbody))).mass = numberOfSlices * breadMass;
		//Debug.Log (numberOfSlices + " breads.");
		//Vector3 newCenter = (slices [0].transform.localPosition + slices [numberOfSlices-1].transform.localPosition) / 2;
		//Vector3 newSize = slices [0].collider.bounds.size;
		//newSize.x *= numberOfSlices;
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
		for(int i = 0; i < numberOfSlices; i++)
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
			numberOfSlices = survivingBreads.Count;
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
		if(numberOfSlices > 1)
		{
			recalc ();
			for(int i = 0; i < numberOfSlices; i++)
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
			otherPart = Instantiate(this.gameObject, transform.position, transform.rotation) as GameObject;
			bool cuttingBool = place > (numberOfSlices / 2);
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
