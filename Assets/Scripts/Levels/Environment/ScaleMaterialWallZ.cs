using UnityEngine;
using System.Collections;

public class ScaleMaterialWallZ : MonoBehaviour {

	// Use this for initialization
	void Start () {
	gameObject.transform.renderer.material.mainTextureScale = new Vector2 (gameObject.transform.localScale.x, gameObject.transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
