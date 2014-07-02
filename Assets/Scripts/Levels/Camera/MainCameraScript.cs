using UnityEngine;
using System.Collections;

/**
 * Script for turning off lights before rendering with main camera.
 * The reason for this is that the soup camera needs the light to be off.
 * I'm not sure why the main camera does this though.
 * 
 * TODO: Remove this class when the soup shader is removed.
 **/
public class MainCameraScript : MonoBehaviour
{
	public Light[] lights;
	public bool on = true;
	
	void OnPreRender()
	{
		if(on)
		{
			foreach(Light light in lights)
			{
				light.enabled = false;
			}
		}
	}
}
