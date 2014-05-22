﻿using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class MusicPlayer : MonoBehaviour 
{

	FMOD.Studio.EventInstance eMusic;
	FMOD.Studio.ParameterInstance pVolume,pStresslevel,pState,pTrack;
	public FMODAsset path;
	public float vol;
	private FMOD.Studio.PLAYBACK_STATE status;
	
	void Start () 
	{
		eMusic = FMOD_StudioSystem.instance.GetEvent(path);
		if(eMusic.getParameter("Mood",out pStresslevel) != FMOD.RESULT.OK)
		{
			Debug.Log ("Error loading mood in "+gameObject.name);
		}
		if(eMusic.getParameter("state",out pState) != FMOD.RESULT.OK)
		{
			Debug.Log ("Error loading state in "+gameObject.name);
		}
		if(eMusic.getParameter("Track",out pTrack) != FMOD.RESULT.OK)
		{
			Debug.Log ("Error Loading track in "+gameObject.name);
		}
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetMusicVolume(vol);
		eMusic.getPlaybackState(out status);
		if(status == FMOD.Studio.PLAYBACK_STATE.STOPPED)
		{
			eMusic.start ();
		}
	
		
	}
	void SetMusicVolume(float inputVolume)
	{
		eMusic.setVolume(Mathf.Clamp(inputVolume,0,1));
	}
	void SetStresslevel(int stress)
	{
		pStresslevel.setValue(stress);
	}
	void SetState(int state)
	{
		pState.setValue(state);
	}
	void SetTrack(float inputTrack)
	{
		pTrack.setValue(inputTrack);
	}
}
