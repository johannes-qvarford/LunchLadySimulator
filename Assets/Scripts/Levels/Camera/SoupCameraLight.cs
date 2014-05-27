using UnityEngine;
using System.Collections;

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
	
	/*void OnPostRender()
	{
		foreach(Light light in lights)
		{
			//light.enabled = true;
		}
	}*/
}
