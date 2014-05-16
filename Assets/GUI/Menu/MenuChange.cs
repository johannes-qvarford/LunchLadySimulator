using UnityEngine;
using System.Collections;

public class MenuChange : MonoBehaviour {
	public GameObject thisMenu;
	public GameObject targetMenu;
	void OnMouseUpAsButton()
	{
		targetMenu.SetActive(true);
		thisMenu.SetActive(false);
	}
}
