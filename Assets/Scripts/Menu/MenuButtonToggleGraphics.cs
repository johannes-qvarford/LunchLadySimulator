
using UnityEngine;
using System.Collections;
using UnityExtensions;

/**
 * Display different graphics on menu based on whether or not the button is selected.
 **/
public class MenuButtonToggleGraphics : MonoBehaviour
{
	public GameObject defaultObject;
	public GameObject overObject;

	void SelectedChanged(bool yes)
	{
		overObject.SetActive(yes);
		defaultObject.SetActive(yes == false);
	}
}
