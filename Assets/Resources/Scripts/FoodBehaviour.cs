using UnityEngine;
using System.Collections;

public class FoodBehaviour : MonoBehaviour {

	private GameObject parent;
	private PickUpFood pickUpFoodScript;
	private CapsuleCollider capsuleCollider;
	//private MeshCollider msCollider;
	private Rigidbody rigidBody;

	public bool pickUp = true;

	public Vector3 parentPosition;
	public Vector3 adjustPosition;

	// Use this for initialization
	void Awake()
	{
		parent = GameObject.Find("LeftHand");
		pickUpFoodScript = parent.GetComponent<PickUpFood>();
		capsuleCollider = this.GetComponent<CapsuleCollider>();
		//msCollider = this.GetComponent<MeshCollider>();
		rigidBody = this.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{

		if(pickUp)
		{
			parentPosition = parent.transform.position;
			parentPosition += adjustPosition;
			rigidbody.transform.position = parentPosition;
		}

		if(!pickUpFoodScript.foodPlateContact)
		{
			capsuleCollider.enabled = true;
			//msCollider.enabled = true;
			rigidBody.isKinematic = false;
		}

		if(!pickUp)
		{
			rigidBody.useGravity = true;
		}
	}
/*
	void OnCollisionEnter(Collision collision)
	{
		if(!pickUp)
		{
			if(collision.collider.tag == "NPC")
			{
				collision.collider.GetComponent<NpcMove>().move = true;
			}
		}

	}
*/
}
