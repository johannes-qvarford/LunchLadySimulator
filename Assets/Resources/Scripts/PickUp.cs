using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	private GameObject gameObject;
	public GameObject create;

	public Vector3 createPosition;

	public float foodRayDistance = 1f;

	public bool release = false;

	public bool foodPlateContact = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		foodPlateContact = false;
		if(Input.GetKeyDown(KeyCode.J))
		{
			PickUpFood(false);
		}

		if(Input.GetKeyDown(KeyCode.K))
		{
			PickUpFood(true);
		}

		Ray testRay = new Ray(this.transform.position, -this.transform.up);
		RaycastHit testInfo;
		if(Physics.Raycast(testRay, out testInfo, foodRayDistance))
		{
			Vector3 temp = new Vector3(testRay.origin.x, testRay.origin.y - testInfo.distance, testRay.origin.z);
			Debug.DrawLine(testRay.origin, temp, Color.green);
			if(testInfo.collider.tag == "FoodPlate")
				foodPlateContact = true;
		}
	}

	private void PickUpFood(bool drop)
	{
		Ray pickUpRay = new Ray(this.transform.position, -this.transform.up);
		RaycastHit hitInfo;
		if(Physics.Raycast(pickUpRay, out hitInfo, foodRayDistance))
		{
			if(!drop)
			{
				if(hitInfo.collider.tag == "FoodPlate")
				{
					gameObject = Instantiate(create, this.transform.position, Quaternion.Euler(90f, 0f, 0f)) as GameObject;
					gameObject.GetComponent<FoodBehaviour>().id = 1;
				}

				else if(hitInfo.collider.tag == "Food")
				{
					hitInfo.collider.GetComponent<FoodBehaviour>().pickUp = true;
				}
			}
			else if(drop)
			{
				if(hitInfo.collider.tag == "Food")
				{
					hitInfo.collider.GetComponent<FoodBehaviour>().pickUp = false;
				}
			}
		}
	}
}
