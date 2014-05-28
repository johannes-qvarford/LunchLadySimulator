using UnityEngine;
using System.Collections;

public class MasterVolume : MonoBehaviour {

	// Use this for initialization
	private float master;
	void Start () {
		master = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void SetMasterVolume(float inputMaster)
	{
		master = inputMaster;
	}
	public void SetVolumeOnSounds(float inputMaster)
	{
		SetMasterVolume(inputMaster);
		BroadcastMessage("SetMaster",master);
	}
}
