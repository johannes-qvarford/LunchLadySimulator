using UnityEngine;
using System.Collections;

public class DepthCameraOn : MonoBehaviour {
	public Material mat;
	// Use this for initialization
	void Start () {
		camera.depthTextureMode = DepthTextureMode.Depth;
	}
	
	void OnRenderImage (RenderTexture source, RenderTexture destination){
		Graphics.Blit(source,destination,mat);
		//mat is the material which contains the shader
		//we are passing the destination RenderTexture to
	}
}
