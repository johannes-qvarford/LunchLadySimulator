using UnityEngine;
using System.Collections;

public class FoodBehaviour : MonoBehaviour {

	private GameObject parent;
	private PickUp pickUpScript;
	private CapsuleCollider capsuleCollider;
	private Rigidbody rigidBody;

	public bool pickUp = true;

	public Vector3 parentPosition;
	public Vector3 adjustPosition;

	public int id = 0;

	// Use this for initialization
	void Awake()
	{
		parent = GameObject.Find("LeftHand");
		pickUpScript = parent.GetComponent<PickUp>();
		capsuleCollider = this.GetComponent<CapsuleCollider>();
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

		if(!pickUpScript.foodPlateContact)
		{
			capsuleCollider.enabled = true;
			rigidBody.isKinematic = false;
		}

		if(!pickUp)
		{
			rigidBody.useGravity = true;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(!pickUp)
		{
			if(collision.collider.tag == "NPC")
			{
				collision.collider.transform.parent.GetComponent<NpcMove>().move = true;
				//collision.collider.GetComponent<NpcMove>().move = true;
			}
		}

	}
}
