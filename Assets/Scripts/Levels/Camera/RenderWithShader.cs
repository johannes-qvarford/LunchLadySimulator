using UnityEngine;
using System.Collections;

public class RenderWithShader : MonoBehaviour {
	public Material shaderMaterial;
	public RenderTexture intermediateRT;
	// Use this for initialization
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, shaderMaterial);

		//Graphics.Blit(source, intermediateRT, shaderMaterial);
		//Graphics.Blit(intermediateRT, destination);
	}
}
