using UnityEngine;
using System.Collections;
using FMOD.Studio;

/**
 * Class for playing music from an fmod event.
 * Every frame the volume is updated and the music is restarted if it has stopped.
 **/
public class MusicPlayer : MonoBehaviour
{
	public FMODAsset path;
	public float vol;
	public int track = 1;
	
	public float Volume { set { SetVolume(value); } }
	public float Mood { set { SetMood(value); } }
	public float Track { set { if(pTrack != null) { pTrack.setValue(value); } } }
	public bool Playing { set { SetPlaying(value); } get { return IsPlaying(); } }

	private FMOD.Studio.EventInstance eMusic;
	private FMOD.Studio.ParameterInstance pVolume;
	private FMOD.Studio.ParameterInstance pMood;
	private FMOD.Studio.ParameterInstance pState;
	private FMOD.Studio.ParameterInstance pTrack;
	
	private float master = 1.0f;
	
	private DoOncer initMusicOnce = new DoOncer();
	
	private const string MOOD_PARAMETER = "Mood";
	private const string STATE_PARAMETER = "state";
	private const string TRACK_PARAMETER = "Track";
	
	void Start ()
	{
		initMusicOnce.doOnce(InitMusic);
	}
	
	void Update () 
	{
		Volume = Mathf.Clamp(vol, 0, 1);
		Track = track;
		
		if(Playing == false)
		{
			Playing = true;
		}
	}
	
	private void InitMusic()
	{
		eMusic = FMODUtility.GetEvent(path);
		pMood = FMODUtility.GetParameter(eMusic, MOOD_PARAMETER);
		pState = FMODUtility.GetParameter(eMusic, STATE_PARAMETER);
		pTrack = FMODUtility.GetParameter(eMusic, TRACK_PARAMETER);
	}
	
	private void SetVolume(float volume)
	{
		initMusicOnce.doOnce(InitMusic);
		eMusic.setVolume(volume * master);
	}
	
	private void SetMood(float mood)
	{
		initMusicOnce.doOnce(InitMusic);
		pMood.setValue(mood);
	}

	private void SetMaster(float inputMaster)
	{
		master = inputMaster;
	}
	
	private void SetPlaying(bool yes)
	{
		initMusicOnce.doOnce(InitMusic);
		if(yes) 
		{
			eMusic.start(); 
		}
		else
		{
			eMusic.stop();
		}
	}
	
	private bool IsPlaying()
	{
		initMusicOnce.doOnce(InitMusic);
		FMOD.Studio.PLAYBACK_STATE status;
		eMusic.getPlaybackState(out status);
		return status != FMOD.Studio.PLAYBACK_STATE.STOPPED;
	}
}
