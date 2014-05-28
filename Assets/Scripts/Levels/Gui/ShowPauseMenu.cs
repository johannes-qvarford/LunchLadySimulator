using UnityEngine;
using System.Collections;

public class ShowPauseMenu : MonoBehaviour {
	private bool paused = false;
	public GameObject graphics;
	public float pauseMenuSoundMultiplier;
	private GameObject masterVolumeObject;
	// Use this for initialization
	void Start () {
		masterVolumeObject = GameObject.FindWithTag(Tags.MASTERVOLUME);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape"))
		{
			if(paused == false)
			{
				masterVolumeObject.SendMessage("SetVolumeOnSounds",1.0f*pauseMenuSoundMultiplier,SendMessageOptions.RequireReceiver);
				dispalyPauseMenu();
			}
			else
			{
				masterVolumeObject.SendMessage("SetVolumeOnSounds",1.0f,SendMessageOptions.RequireReceiver);
				returnToGame();
			}
		}
	}
	private void dispalyPauseMenu()
	{
		graphics.SetActive(true);
		Time.timeScale = 0;
		paused = true;
	}
	public void returnToGame()
	{
		graphics.SetActive(false);
		Time.timeScale = 1;
		paused = false;
	}
}
