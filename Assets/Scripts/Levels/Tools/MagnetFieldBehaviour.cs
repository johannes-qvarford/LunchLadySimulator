using UnityEngine;
using System.Collections;

using UnityExtensions;

public class MagnetFieldBehaviour : MonoBehaviour
{
	GameObject magnetBox;
	string magnetBoxName = "none";
	bool magnetized = false;
	public Vector3 magnetRotation;
	public Vector3 magnetPosition;
	public float magnetizedMass = 1000;
	
	private float oldMass;
	
	void Start()
	{
		oldMass = rigidbody.mass;
	}
	
	void Update ()
	{
		GameObject obj = GameObject.FindWithTag(Tags.RIGHT_ARM);
		string heldGrabableR = obj.GetComponent<ArmLogic>().heldGrabableName;

		obj = GameObject.FindWithTag(Tags.LEFT_ARM);
		string heldGrabableL = obj.GetComponent<ArmLogic>().heldGrabableName;		
		
		GameObject magnet = GameObject.Find("MagnetTrack");

		if(magnetized && heldGrabableR != transform.ToString() && heldGrabableL != transform.ToString ())
		{
			transform.position = magnetBox.transform.position;
			Quaternion changeRotation = transform.localRotation;
			
			changeRotation.eulerAngles = magnetRotation;
			transform.localRotation = changeRotation;

			transform.localPosition+= magnetPosition;		
	
			transform.rigidbody.freezeRotation = true;
		}
		else
		{
			magnetized = false;
			magnet.GetComponent<MagnetTrackBehaviour>().SetMagnetPositionEmpty(magnetBoxName);
			magnetBoxName = "none";
		}
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
				rigidbody.mass = magnetizedMass;
			}
		}
	}
	
	void OnGrabbed()
	{
		rigidbody.mass = oldMass;
	}
}
