using UnityEngine;
using System.Collections;

/**
  * A button for the pause menu. 
  * It can be selected, and deselected, and shows a different texture whether or not it's selected.
  **/
public class PauseMenuButton : MonoBehaviour 
{
	public PauseMenuButton nextDown;
	public PauseMenuButton nextUp;

	public GameObject activeTexture;
	public GameObject notActiveTexture;

	void SelectedChanged(bool yes)
	{
		if(yes)
		{
			activeTexture.SetActive(true);
			notActiveTexture.SetActive(false);
		}
		else
		{
			activeTexture.SetActive(false);
			notActiveTexture.SetActive(true);
		}
	}
}
