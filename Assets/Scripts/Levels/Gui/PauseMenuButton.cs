using UnityEngine;
using System.Collections;

public class PauseMenuButton : MonoBehaviour 
{
	public PauseMenuButton nextDown;
	public PauseMenuButton nextUp;

	public GameObject activeTexture;
	public GameObject notActiveTexture;

	void OnSelected(bool yes)
	{
		
		if(yes)
		{
			Debug.Log("being activated");
			activeTexture.SetActive(true);
			notActiveTexture.SetActive(false);
		}
		else
		{
			Debug.Log("being deactivated :(");
			activeTexture.SetActive(false);
			notActiveTexture.SetActive(true);
		}
	}
}
