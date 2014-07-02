
using UnityEngine;
using System.Collections;
using UnityExtensions;

/**
 * Change the button when pressing any valid direction.
 **/
public class MenuButtonChangeButton : MonoBehaviour
{
	public GameObject leftButton;
	public GameObject rightButton;
	public GameObject upButton;
	public GameObject downButton;
	public float maxCooldown = 0.1f;
	
	private bool isSelected = false;
	private float cooldown = 0;
	
	void SelectedChanged(bool yes)
	{
		isSelected = yes;
		cooldown = maxCooldown;
	}
	
	void Update()
	{
		cooldown -= Time.deltaTime;
		if(isSelected && cooldown < 0)
		{
			if(leftButton != null && ActionInputManager.ActionIsPerformed(ActionInputManager.Action.OPTION_LEFT))
			{
				SendMessage("SelectedChanged", false, SendMessageOptions.RequireReceiver);
				leftButton.SendMessage("SelectedChanged", true, SendMessageOptions.RequireReceiver);
			}
			if(rightButton != null && ActionInputManager.ActionIsPerformed(ActionInputManager.Action.OPTION_RIGHT))
			{
				SendMessage("SelectedChanged", false, SendMessageOptions.RequireReceiver);
				rightButton.SendMessage("SelectedChanged", true, SendMessageOptions.RequireReceiver);
			}
			if(upButton != null && ActionInputManager.ActionIsPerformed(ActionInputManager.Action.OPTION_UP))
			{
				SendMessage("SelectedChanged", false, SendMessageOptions.RequireReceiver);
				upButton.SendMessage("SelectedChanged", true, SendMessageOptions.RequireReceiver);
			}
			if(downButton != null && ActionInputManager.ActionIsPerformed(ActionInputManager.Action.OPTION_DOWN))
			{
				SendMessage("SelectedChanged", false, SendMessageOptions.RequireReceiver);
				downButton.SendMessage("SelectedChanged", true, SendMessageOptions.RequireReceiver);
			}
		}
	}
}
