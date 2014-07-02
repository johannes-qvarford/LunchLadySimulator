using UnityEngine;
using System.Collections;
using UnityExtensions;

/**
 * Notifies other components when the button is clicked.
 **/
public class MenuNotifyButtonClick : MonoBehaviour
{
	private bool isSelected = false;
	
	void SelectedChanged(bool yes)
	{
		isSelected = yes;
	}
	
	void Update()
	{
		if(isSelected && ActionInputManager.ActionIsPerformed(ActionInputManager.Action.CONFIRM))
		{
			SendMessage("OnClick", SendMessageOptions.RequireReceiver);
		}
	}
}

