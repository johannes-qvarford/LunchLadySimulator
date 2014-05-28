using UnityEngine;
using System.Collections;

public class MagnetFieldBehaviour : MonoBehaviour {
	GameObject magnetBox;
	string magnetBoxName = "none";
	bool magnetized = false;
	public Vector3 magnetRotation;
	public Vector3 magnetPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		GameObject obj = GameObject.Find("Workbench/PlayerArms/RightArm");
		string heldGrabableR = obj.GetComponent<ArmLogic>().heldGrabableName;

		obj = GameObject.Find("Workbench/PlayerArms/LeftArm");
		string heldGrabableL = obj.GetComponent<ArmLogic>().heldGrabableName;		
		

		GameObject magnet = GameObject.Find ("Magnet Track");
		

		if(magnetized && heldGrabableR != transform.ToString() && heldGrabableL != transform.ToString ())
		{
		
			transform.position = magnetBox.transform.position;
			Quaternion changeRotation = transform.localRotation;
			
			changeRotation.eulerAngles = magnetRotation;
			transform.localRotation = changeRotation;

			transform.localPosition+= magnetPosition;		
	
			transform.rigidbody.freezeRotation = true;

		}
		else{
			magnetized = false;
			magnet.GetComponent<MagnetTrackBehaviour>().SetMagnetPositionEmpty(magnetBoxName);
			magnetBoxName = "none";
		}
	}


	void OnTriggerEnter(Collider col)
	{	


	}
	

	void OnTriggerExit()
	{
	
		
	

	}

	void OnTriggerStay(Collider col)
	{
		
		GameObject OTHER = col.gameObject;
		
		if(OTHER.tag == Tags.MAGNET_FIELD && !magnetized)
		{
			
			
			if(OTHER.GetComponent<MagnetTrackBehaviour>().isEmptyBox())
			{
				magnetBox = OTHER.GetComponent<MagnetTrackBehaviour>().GetEmptyBox();
				magnetBoxName = magnetBox.ToString ();
				magnetized = true;
			}
		}
		



	}


}
