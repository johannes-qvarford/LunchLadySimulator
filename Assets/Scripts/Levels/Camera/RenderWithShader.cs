using UnityEngine;
using System.Collections;

/*
 * Class for rendering from a render texture to another with a shader material.
 **/
public class RenderWithShader : MonoBehaviour {
	public Material shaderMaterial;
	public RenderTexture intermediateRT;

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit (source, destination, shaderMaterial);
	}
}
