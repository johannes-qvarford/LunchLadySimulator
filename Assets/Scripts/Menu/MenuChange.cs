using UnityEngine;
using System.Collections;

public class MenuChange : MonoBehaviour {
	public MenuChange leftButton;
	public MenuChange rightButton;
	public MenuChange upButton;
	public MenuChange downButton;
	
	public GameObject thisMenu;
	public GameObject targetMenu;
	
	public bool isSelected = false;
	
	public int waitTime = 30;
	
	private int wait = 0;
	
	//right now we can't go back from level select
	private bool done;
	
	void Start()
	{
		if(isSelected)
		{
			SendMessage("OnSelected", true, SendMessageOptions.RequireReceiver);
		}
	}
	
	void OnSelected(bool yes)
	{
		isSelected = true;
		wait = waitTime;
	}
	
	void Update()
	{
		if(wait > 0)
		{
			--wait;
		}
		
		if(done == false && ArmInputManager.IsDown(ArmInputManager.Action.CONFIRM))
		{
			SendMessage("OnClick", SendMessageOptions.RequireReceiver);
			targetMenu.SetActive(true);
			thisMenu.SetActive(false);
			done = true;
		}
		
		if(isSelected && wait == 0)
		{
			if(leftButton != null && ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_LEFT))
			{
				SendMessage("OnSelected", false, SendMessageOptions.RequireReceiver);
				leftButton.SendMessage("OnSelected", true, SendMessageOptions.RequireReceiver);
			}
			if(rightButton != null && ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_RIGHT))
			{
				SendMessage("OnSelected", false, SendMessageOptions.RequireReceiver);
				rightButton.SendMessage("OnSelected", true, SendMessageOptions.RequireReceiver);
			}
			if(upButton != null && ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_UP))
			{
				SendMessage("OnSelected", false, SendMessageOptions.RequireReceiver);
				upButton.SendMessage("OnSelected", true, SendMessageOptions.RequireReceiver);
			}
			if(downButton != null && ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_DOWN))
			{
				SendMessage("OnSelected", false, SendMessageOptions.RequireReceiver);
				downButton.SendMessage("OnSelected", true, SendMessageOptions.RequireReceiver);
			}
		}
	}
}
