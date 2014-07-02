using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

/**
 * Class for playing sounds when colliding with game objects.
 * No sound is played by NPC:s, and when the collided object is food (a tool hitting 20 soup particles doesn't sound good).
 * 
 * TODO: Clarify why, if any, the check for game object being NPC in OnCollisionEnter is there.
 * If there is no good reason, this class seems rather pointless to place on NPC:s at all in which case the check is unnessesary.
 * 
 * TODO: Break out SoundCheck to two classes TriggerableSound and CollisionTriggerable sound.
 * Triggerable sound has the same behaviour as sound check, 
 * while CollisionTriggerableSound plays a TriggerableSound (either inherited or refered with get component)
 * on collision.
 * Some game objects only need functionality of triggering sounds (NPC?)
 * and therefor doesn't need collision reactions, which need to be filtered out.
 **/
public class SoundCheck : MonoBehaviour
{
	public float volume;
	public float state;
	public float mood;
	public FMODAsset path;
	
	public float State { get { return GetState(); } set { SetState(value); } }
	public float Volume { get { return volume; } set { SetVolume(value); } }
	public float Mood { get { return mood; } set { SetMood(value); } }
	public FMOD.Studio.PLAYBACK_STATE PlaybackState { get { return GetPlayBackState(); } }
	public bool Play { set { if(value) { eSound.start(); } else { eSound.stop(); } } }
	public FMODAsset FModAsset { set { SetFmodAsset(value); } }
	
	private FMOD.Studio.EventInstance eSound;
	private FMOD.Studio.ParameterInstance pVolume;
	private FMOD.Studio.ParameterInstance pState;
	private FMOD.Studio.ParameterInstance pMood;

	private float master = 1.0f;
	private DoOncer loadSoundOnce = new DoOncer(); 

	private const string STATE_PARAMETER = "state";
	private const string VELOCITY_PARAMETER = "Velocity";
	private const string MOOD_PARAMETER = "Mood";

	void Start () 
	{
		loadSoundOnce.doOnce(() => FModAsset = path);
	}

	void OnDisable()
	{
		if(eSound != null)
		{
			eSound.release();
		}
	}

	void Update()
	{
		State = state;
		Mood = mood;
	}

	void OnCollisionEnter(Collision collision)
	{
		loadSoundOnce.doOnce(() => FModAsset = path);
	
		if(tag != Tags.NPC)
		{
			Volume = Mathf.Clamp(collision.relativeVelocity.sqrMagnitude, 0, 1);

			if(collision.gameObject.tag != "Food"
			   && PlaybackState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
			{
				Play = true;
			}
		}
	}

	public void TriggerSound()
	{
		Play = true;
	}

	private void SetVolume(float vol)
	{
		volume = vol * master;
		if(pVolume != null)
		{
			pVolume.setValue(volume);
		}
	}
	
	private void SetMood(float iMood)
	{
		mood = iMood;
		if(pMood != null)
		{
			pMood.setValue(mood);
		}
	}
	
	private void SetState(float iState)
	{
		state = iState;
		if(pState != null)
		{
			pState.setValue(state);
		}
	}

	private FMOD.Studio.PLAYBACK_STATE GetPlayBackState()
	{
		FMOD.Studio.PLAYBACK_STATE status;
		eSound.getPlaybackState(out status);
		return status;
	}

	private float GetState()
	{
		float temp;	
		pState.getValue(out temp);
		return temp;
	}

	private void SetMaster(float inputMaster)
	{
		master = inputMaster;
	}

	private void SetFmodAsset(FMODAsset sound)
	{
		path = sound;
		eSound = FMODUtility.GetEvent(path);
		pState = FMODUtility.GetParameter(eSound, STATE_PARAMETER);
		pVolume = FMODUtility.GetParameter(eSound, VELOCITY_PARAMETER);
		pMood = FMODUtility.GetParameter(eSound, MOOD_PARAMETER);
	}
	
	
}
