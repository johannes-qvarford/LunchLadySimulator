﻿using UnityEngine;
using System.Collections;

public class SoundCheck : MonoBehaviour {

	FMOD.Studio.EventInstance eSound;
	FMOD.Studio.ParameterInstance pVolume,pState,pMood;
	public float state,mood,volume;
	public FMODAsset path;
	private bool [] valid = new bool[3];
	void Start () 
	{
	
		for(int i= 0; i < valid.Length; i ++)
		{
			valid[i] = true;
		}
		eSound = FMOD_StudioSystem.instance.GetEvent(path);
		if(eSound.getParameter("state",out pState) != FMOD.RESULT.OK)
		{
			Debug.Log ("Error loading State parameter in "+gameObject.name);
			valid[0] = false;
		}
		if(eSound.getParameter("Velocity",out pVolume) != FMOD.RESULT.OK)
		{
			Debug.Log ("Error loading velocity parameter in "+gameObject.name);
			valid[1] = false;
		}	
		if(eSound.getParameter("Mood",out pMood) != FMOD.RESULT.OK)
		{
			Debug.Log("Error loading mood parameter in "+gameObject.name);
			valid[2] = false;
		}
	}
	void Update ()
	{
		
	}
	void OnCollisionEnter(Collision collision)
	{ 
		ChangeParameter();
		if(valid[1])
		{
			pVolume.setValue(Mathf.Clamp (collision.relativeVelocity.sqrMagnitude,0,1));
			Debug.Log (Mathf.Clamp (collision.relativeVelocity.sqrMagnitude,0,1));
		}
		eSound.start ();
	}
	void TriggerSound()
	{
		
		ChangeParameter();
		eSound.start ();
	}
	void OnDisable()
	{
		eSound.release();
	}
	
	private void ChangeParameter()
	{	
		if(valid[0])
		{
			pState.setValue(state);
			
		}
		if(valid[1])
		{
			SetVolume(1);
		}
		if(valid[2])
		{
			pMood.setValue(mood);
		}
	}
	void SetVolume(float vol)
	{
		pVolume.setValue(vol);
	}
	
	void SetMood(float iMood)
	{
		pMood.setValue(iMood);
	}
	
	void setState(float iState)
	{
		pState.setValue(iState);
	}
}