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
			//Debug.LogError("Error loading mood parameter in "+gameObject.name);
			valid[2] = false;
		}
		ChangeParameter();
	}
	void Update ()
	{
		eSound.getPlaybackState(out status);
		if(valid[0])
		{
		
			Debug.LogError(name + " " + GetState());
		}
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
			if(valid[0] && tag == Tags.NPC)
			{
				Debug.LogError("triggerSound "+GetState());
			}
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
		if(valid[0] && tag == Tags.NPC)
		{
			Debug.LogError("Setvolume "+GetState());
		}
	}
	
	public void SetMood(float iMood)
	{
		mood = iMood;
		pMood.setValue(mood);
		if(valid[0] && tag == Tags.NPC)
		{
			Debug.LogError("setmood "+GetState());
		}
	}
	
	public void SetState(float iState)
	{
		if(valid[0])
		{	
			state = iState;
			if(valid[0] && tag == Tags.NPC)
			{
				Debug.LogError("setstate "+GetState());
			}
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
}
