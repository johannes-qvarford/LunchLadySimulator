using UnityEngine;
using System.Collections;

using UnityExtensions;

/**
 * Class for things that are drawn to magnet tracks.
 * They gets pulled toward magnet tracks when they are in range of one,
 * and not currently grabbed by a hand.
 **/
public class MagnetFieldBehaviour : MonoBehaviour
{
	GameObject magnetBox;
	bool magnetized = false;
	public Vector3 magnetRotation;
	public Vector3 magnetPosition;
	public float magnetizedMass = 1000;
	
	private ArmLogic leftArmLogic;
	private ArmLogic rightArmLogic;
	private GameObject magnet;
	private MagnetTrackBehaviour magnetTrack;
	private float oldMass;
	
	void Start()
	{
		oldMass = rigidbody.mass;
		leftArmLogic = GameObject.FindWithTag(Tags.LEFT_ARM).GetComponent<ArmLogic>();
		rightArmLogic = GameObject.FindWithTag(Tags.RIGHT_ARM).GetComponent<ArmLogic>();
		magnet = GameObject.FindWithTag(Tags.MAGNET_FIELD);
		magnetTrack = magnet.GetComponent<MagnetTrackBehaviour>();
	}
	
	void Update()
	{		
		Transform rightHeldGrabable = rightArmLogic.heldGrabable;
		Transform leftHeldGrabable = leftArmLogic.heldGrabable;

		if(magnetized && rightHeldGrabable != transform && leftHeldGrabable != transform)
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
			if(magnetBox != null)
			{
				magnetTrack.SetMagnetBoxAvailable(magnetBox);
				magnetBox = null;
			}
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject == magnet && !magnetized)
		{
			if(magnetTrack.EmptyBoxAvailable())
			{
				magnetBox = magnetTrack.GetEmptyBox(requester: transform);
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
