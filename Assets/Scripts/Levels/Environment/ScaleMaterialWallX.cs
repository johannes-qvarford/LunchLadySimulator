using UnityEngine;
using System.Collections;

public class ScaleMaterialWallX : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.renderer.material.mainTextureScale = new Vector2 (gameObject.transform.localScale.z, gameObject.transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
