using UnityEngine;
using System.Collections;
using UnityExtensions;

/**
 * Change the menu when the button
 **/
public class MenuChangeMenuOnClick : MonoBehaviour
{
	public GameObject thisMenu;
	public GameObject targetMenu;
	
	void OnClick()
	{
		targetMenu.SetActive(true);
		thisMenu.SetActive(false);
	}
}
