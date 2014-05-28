using UnityEngine;
using System.Collections;

public class ScaleMaterialFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.renderer.material.mainTextureScale = new Vector2 (gameObject.transform.localScale.x / 4, gameObject.transform.localScale.z / 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
