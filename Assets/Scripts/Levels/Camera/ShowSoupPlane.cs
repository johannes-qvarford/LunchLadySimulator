using UnityEngine;
using System.Collections;

/**
 * Sets the main color of a shader to a given color after a short time.
 * TODO: Remove this class when the soup shader is removed.
 **/
public class ShowSoupPlane : MonoBehaviour {
	public Color color;

	void Start ()
	{
		Invoke("showPlane", 1);
	}

	private void showPlane()
	{
		renderer.material.SetColor("_MainColor", color);
	}
}
