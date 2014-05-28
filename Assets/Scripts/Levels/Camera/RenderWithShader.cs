using UnityEngine;
using System.Collections;

public class RenderWithShader : MonoBehaviour {
	public Material material;
	// Use this for initialization
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}
