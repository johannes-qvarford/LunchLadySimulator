using UnityEngine;
using System.Collections.Generic;

public class ShowPauseMenu : MonoBehaviour {
	private bool paused = false;
	public GameObject graphics;

	private List<GameObject> options = new List<GameObject>();
	private int optionsIndex = 0;
	private int frame = 0;
	private int framesSelectCooldown = 0;
	
	public float pauseMenuSoundMultiplier;
	
	public PauseMenuButton originalCurrent;
	public PauseMenuButton theResumer;
	
	private GameObject masterVolumeObject;
	private PauseMenuButton current;
	
	// Use this for initialization
	void Start () {
		masterVolumeObject = GameObject.FindWithTag(Tags.MASTERVOLUME);
		current = originalCurrent;
		
	}
	
	// Update is called once per frame
	void Update () {
		frame++;
	
		if(ArmInputManager.IsDown(ArmInputManager.Action.PAUSE) && paused == false)
		{
			Debug.Log(Time.timeScale);
			masterVolumeObject.BroadcastMessage("SetVolumeOnSounds",1.0f*pauseMenuSoundMultiplier,SendMessageOptions.RequireReceiver);
			
			dispalyPauseMenu();
			current.BroadcastMessage("OnSelected", true, SendMessageOptions.RequireReceiver);
		}
		else if(paused)
		{
			if(ArmInputManager.IsDown(ArmInputManager.Action.PAUSE))
			{
				returnToGame();
			}
			else
			{
				if(framesSelectCooldown > 0)
				{
					framesSelectCooldown--;
				}
				if(ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_DOWN) && framesSelectCooldown == 0)
				{
					Debug.Log("down");
					var next = current.nextDown;
					current.BroadcastMessage("OnSelected", false, SendMessageOptions.RequireReceiver);
					next.BroadcastMessage("OnSelected", true, SendMessageOptions.RequireReceiver);
					framesSelectCooldown = 30;
					current = next;
				}
				else if(ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_UP) && framesSelectCooldown == 0)
				{
					Debug.Log("up");
					var next = current.nextUp;
					current.BroadcastMessage("OnSelected", false, SendMessageOptions.RequireReceiver);
					next.BroadcastMessage("OnSelected", true, SendMessageOptions.RequireReceiver);
					framesSelectCooldown = 30;
					current = next;
				}
				
				if(ArmInputManager.IsDown(ArmInputManager.Action.CONFIRM))
				{
					if(current.gameObject == theResumer.gameObject)
					{
						returnToGame();
					}
					else
					{
						Time.timeScale = 1;
						current.BroadcastMessage("OnClick", SendMessageOptions.RequireReceiver);
					}
				}
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
		paused = false;
		masterVolumeObject.BroadcastMessage("SetVolumeOnSounds",1.0f,SendMessageOptions.RequireReceiver);
		foreach(var o in options)
		{
			o.SetActive(true);
		}
		graphics.SetActive(false);
		Time.timeScale = 1;
		paused = false;
		optionsIndex = 0;
	}
}
