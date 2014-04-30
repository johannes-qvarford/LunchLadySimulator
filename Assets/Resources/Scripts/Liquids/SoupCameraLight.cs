using UnityEngine;
using System.Collections;

public class SoupCameraLight : MonoBehaviour
{
	public Light[] lights;
	
	void OnPreRender()
	{
		foreach(Light light in lights)
		{
			light.enabled = true;
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
