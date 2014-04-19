using UnityEngine;
using System.Collections;

public class PlateBehaviour : MonoBehaviour {

	private GameObject parent;
	private PickUpPlate pickUpPlateScript;

	public bool pickUp = true;

	public Vector3 parentPosition;
	public Vector3 adjustPosition;

	void Awake()
	{
		parent = GameObject.Find("RightHand");
		pickUpPlateScript = parent.GetComponent<PickUpPlate>();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(pickUp)
		{
			parentPosition = parent.transform.position;
			parentPosition += adjustPosition;
			transform.position = parentPosition;
		}
		if(!pickUp)
		{
			Debug.Log("Plate PickUp is false");
		}
	}
}
