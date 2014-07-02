using UnityEngine;
using System.Collections;

/**
 * Class for scaling material by a factor based on transform local z scale to u and v scale.
 * 
 * TODO: Rename to ScaleMaterialFromZ.
 **/
public class ScaleMaterialWallX : MonoBehaviour
{
	public float uScaleFactor = 1;
	public float vScaleFactor = 1;

	void Start ()
	{
		gameObject.transform.renderer.material.mainTextureScale = new Vector2(gameObject.transform.localScale.z * uScaleFactor, gameObject.transform.localScale.z * vScaleFactor);
	}
}
