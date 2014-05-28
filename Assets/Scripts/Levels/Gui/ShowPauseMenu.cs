using UnityEngine;
using System.Collections.Generic;

public class ShowPauseMenu : MonoBehaviour {
	private bool paused = false;
	public GameObject graphics;
	
	private List<GameObject> options = new List<GameObject>();
	private int optionsIndex = 0;
	private int frame = 0;
	private int framesSelectCooldown = 0;
	
	
	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < graphics.transform.childCount; ++i)
		{
			options.Add(graphics.transform.GetChild(i).gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		frame++;
	
		if(ArmInputManager.IsDown(ArmInputManager.Action.PAUSE) && paused == false)
		{
			dispalyPauseMenu();
		}
		else if(paused)
		{
			if(ArmInputManager.IsDown(ArmInputManager.Action.PAUSE))
			{
				paused = false;
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
					options[optionsIndex].SetActive(true);
					optionsIndex = (optionsIndex+1) % options.Count;
					framesSelectCooldown = 60;
				}
				else if(ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_UP))
				{
					options[optionsIndex].SetActive(true);
					optionsIndex = ((optionsIndex-1)+options.Count) % options.Count;
				}
				if(frame % 30 == 0)
				{
					options[optionsIndex].SetActive(!options[optionsIndex].active);
				}
				
				if(ArmInputManager.IsDown(ArmInputManager.Action.CONFIRM))
				{
					options[optionsIndex].SendMessage("OnMouseDown", SendMessageOptions.RequireReceiver);
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
