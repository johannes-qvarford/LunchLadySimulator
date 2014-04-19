using UnityEngine;
using System.Collections;

public class PickUpPlate : MonoBehaviour {

	public GameObject create;

	public float plateRayDistance = 1f;

	public bool plateContact = false;

	public Vector3 createPosOffset;
	public Vector3 createRotOffset;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		plateContact = false;
		Ray testRay = new Ray(this.transform.position, this.transform.forward);
		RaycastHit testInfo;
		if(Physics.Raycast(testRay, out testInfo, plateRayDistance))
		{
			Debug.DrawLine(testRay.origin, testInfo.point, Color.green);
			if(testInfo.collider.tag == "Plate")
			{
				plateContact = true;
				if(Input.GetKeyDown(KeyCode.Keypad1))
				{
					PickUp(true);
				}
			}
		}
	}

	private void PickUp(bool p)
	{
		GameObject gameObject = Instantiate(create, this.transform.position + createPosOffset, Quaternion.Euler(createRotOffset)) as GameObject;
		if(p)
		{
			gameObject.GetComponent<PlateBehaviour>().pickUp = true;
		}
		else if(!p)
		{
			gameObject.GetComponent<PlateBehaviour>().pickUp = false;
		}
	}
}
