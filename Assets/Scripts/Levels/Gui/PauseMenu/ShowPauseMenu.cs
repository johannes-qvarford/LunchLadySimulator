using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/**
  * Class used to show the pause menu.
  * It waits for the user to press a button and pause the game,
  *  then it selects different options when the user pressed/down up.
  *  When the user presses confirm, whatever action is tied to option is executed,
  *  Except for the resume button, which this script handles itself.
  **/
public class ShowPauseMenu : MonoBehaviour {
	
	public GameObject graphics;
	public PauseMenuButton firstButton;
	public PauseMenuButton theResumer;
	public float fps = 30;
	public float buttonSelectionCooldownTime = 0.5f;
	public float pauseMenuSoundMultiplier;
	
	private GameObject masterVolumeObject;
	private PauseMenuButton currentOptionButton;
	private List<GameObject> pauseOptions = new List<GameObject>();

	private int nextButtonSelectionFrame = 0;
	private bool paused = false;
	private int frame = 0;
	
	void Start ()
	{
		masterVolumeObject = GameObject.FindWithTag(Tags.MASTER_VOLUME);
	}
	
	void Update ()
	{
		++frame;
		bool canDoAction = nextButtonSelectionFrame < frame;
		if(canDoAction == false)
		{
			return;
		}
		
		if(ActionInputManager.ActionIsPerformed(ActionInputManager.Action.PAUSE) && paused == false)
		{
			pauseGame();
		}
		else if(paused)
		{
			if(ActionInputManager.ActionIsPerformed(ActionInputManager.Action.PAUSE))
			{
				resumeGame();
			}
			else
			{

				if(ActionInputManager.ActionIsPerformed(ActionInputManager.Action.OPTION_DOWN))
				{
					switchPauseOption(currentOptionButton.nextDown);
				}
				else if(ActionInputManager.ActionIsPerformed(ActionInputManager.Action.OPTION_UP))
				{
					switchPauseOption(currentOptionButton.nextUp);
				}
				
				if(ActionInputManager.ActionIsPerformed(ActionInputManager.Action.CONFIRM))
				{
					/*
					 * The resumer is special, because it doesn't know what to do to resume the game.
					 * Instead, this object handles it.
					 */
					if(currentOptionButton.gameObject == theResumer.gameObject)
					{
						resumeGame();
					}
					else
					{
						currentOptionButton.BroadcastMessage("OnClick", SendMessageOptions.RequireReceiver);
					}
				}
			}
		}
	}
	
	private void pauseGame()
	{
		paused = true;
		nextButtonSelectionFrame = frame + (int)(buttonSelectionCooldownTime * fps);
		masterVolumeObject.BroadcastMessage("SetMaster", pauseMenuSoundMultiplier, SendMessageOptions.RequireReceiver);
		graphics.SetActive(true);
		Time.timeScale = 0;
		
		/*
		 * Select the default first button, and deselect the rest.
		 */
		currentOptionButton = firstButton;
		currentOptionButton.BroadcastMessage("SelectedChanged", true, SendMessageOptions.RequireReceiver);
		foreach(var button in pauseOptions.Where(g => g != firstButton))
		{
			button.BroadcastMessage("SelectedChanged", false, SendMessageOptions.RequireReceiver);
		}
	}
	
	private void resumeGame()
	{
		paused = false;
		nextButtonSelectionFrame = frame + (int)(buttonSelectionCooldownTime * fps);
		masterVolumeObject.BroadcastMessage("SetMaster", 1.0f, SendMessageOptions.RequireReceiver);
		graphics.SetActive(false);
		Time.timeScale = 1;
	}
	
	private void switchPauseOption(PauseMenuButton next)
	{
		currentOptionButton.BroadcastMessage("SelectedChanged", false, SendMessageOptions.RequireReceiver);
		next.BroadcastMessage("SelectedChanged", true, SendMessageOptions.RequireReceiver);
		currentOptionButton = next;
		
		/*
		 * Count frames (calls to update) in future, because Time.timeScale is zero, and we need button selection cooldown.
		 */
		nextButtonSelectionFrame = frame + (int)(buttonSelectionCooldownTime * fps);
	}
}
