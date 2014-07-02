using UnityEngine;

/**
 * Class for keeping the initial selected state of the button,
 * and informing all other buttons at the start, of the selected state.
 **/
class MenuButtonSelected : MonoBehaviour
{
	public bool menuButtonSelected;
	
	void Start()
	{
		SendMessage("SelectedChanged", menuButtonSelected, SendMessageOptions.RequireReceiver);
	}
	
	private void SelectedChanged(bool yes)
	{
		menuButtonSelected = yes;
	}
}