using UnityEngine;
using System.Collections;

public class SoundCheck : MonoBehaviour {

	FMOD.Studio.EventInstance eSound;
	FMOD.Studio.ParameterInstance pVolume,pState,pMood;
	public float volume;
	public float state,mood;
	public FMODAsset path;
	private FMOD.Studio.PLAYBACK_STATE status; 
	private bool [] valid = new bool[3];
	void Start () 
	{
		
		for(int i= 0; i < valid.Length; i ++)
		{
			valid[i] = true;
		}
		if(path != null)
		{
			eSound = FMOD_StudioSystem.instance.GetEvent(path);
			if(eSound.getParameter("state",out pState) != FMOD.RESULT.OK)
			{
				//Debug.Log ("Error loading State parameter in "+gameObject.name);
				valid[0] = false;
			}
			if(eSound.getParameter("Velocity",out pVolume) != FMOD.RESULT.OK)
			{
				//Debug.Log ("Error loading velocity parameter in "+gameObject.name);
				valid[1] = false;
			}	
			if(eSound.getParameter("Mood",out pMood) != FMOD.RESULT.OK)
			{
				valid[2] = false;
			}
			ChangeParameter();
		}
	}
	void Update ()
	{
		eSound.getPlaybackState(out status);

	}
	void OnCollisionEnter(Collision collision)
	{ 
		if(tag != Tags.NPC)
		{
			ChangeParameter();
			if(valid[1])
			{	
				pVolume.setValue(Mathf.Clamp (collision.relativeVelocity.sqrMagnitude,0,1));
				//Debug.Log (Mathf.Clamp (collision.relativeVelocity.sqrMagnitude,0,1)+collision.gameObject.name);
			}
			if(collision.gameObject.tag != "Food")
			{
				if(status != FMOD.Studio.PLAYBACK_STATE.PLAYING)
				{
					eSound.start ();
				}
			}
		}
	}
	public void TriggerSound()
	{
		//if(status != FMOD.Studio.PLAYBACK_STATE.PLAYING)
		//{ 
		
			eSound.start ();
						
		//}
	}
	void OnDisable()
	{
		if(eSound != null)
		{
			eSound.release();
		}
	}
	
	public void ChangeParameter()
	{	
		if(valid[0])
		{
			SetState(state);
			
		}
		if(valid[1])
		{
			SetVolume(1);
		}
		if(valid[2])
		{
			SetMood(mood);
		}
	}
	public void SetVolume(float vol)
	{
		volume = vol;
		pVolume.setValue(volume);

	}
	
	public void SetMood(float iMood)
	{
		mood = iMood;
		pMood.setValue(mood);
	
	}
	
	public void SetState(float iState)
	{
		if(valid[0])
		{	
			state = iState;
			pState.setValue(state);
		}
	}
	FMOD.Studio.PLAYBACK_STATE GetPlayBackState()
	{
		eSound.getPlaybackState(out status);
		return status;
	}
	public float GetState()
	{
		float temp;	
		pState.getValue(out temp);
		return temp;
	}
	public void setFmodAsset(FMODAsset sound)
	{
		path = sound;
		
		for(int i= 0; i < valid.Length; i ++)
		{
			valid[i] = true;
		}
		
		eSound = FMOD_StudioSystem.instance.GetEvent(path);
		
		if(eSound.getParameter("state",out pState) != FMOD.RESULT.OK)
		{
			//Debug.Log ("Error loading State parameter in "+gameObject.name);
			valid[0] = false;
		}
		
		if(eSound.getParameter("Velocity",out pVolume) != FMOD.RESULT.OK)
		{
			//Debug.Log ("Error loading velocity parameter in "+gameObject.name);
			valid[1] = false;
		}	
		
		if(eSound.getParameter("Mood",out pMood) != FMOD.RESULT.OK)
		{
			valid[2] = false;
		}
		
		ChangeParameter();
	}
}
