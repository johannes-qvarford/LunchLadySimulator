using UnityEngine;
using System.Collections;

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
	
	/*void OnPostRender()
	{
		foreach(Light light in lights)
		{
			//light.enabled = true;
		}
	}*/
}
