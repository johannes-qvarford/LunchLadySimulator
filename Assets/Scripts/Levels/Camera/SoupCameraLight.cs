using UnityEngine;
using System.Collections;

/**
 * Script for turning on lights before rendering with soup camera.
 * The reason for this is that the main camera needs the light to be on,
 * and the soup camera needs the lights to be off.
 * I'm not sure why the soup camera does this though.
 * 
 * TODO: Remove this class when the soup shader is removed.
 **/
public class SoupCameraLight : MonoBehaviour
{
	public bool on = true;
	public Light[] lights;
	
	void OnPreRender()
	{
		if(on)
		{
			foreach(Light light in lights)
			{
				light.enabled = true;
			}
		}
	}
}
