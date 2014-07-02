using UnityEngine;
using System.Collections;

/**
 * Class for scaling material by a factor based on transform local x and y scale to u and v scale.
 * 
 * TODO: Rename to ScaleMaterialFromXY.
 **/
public class ScaleMaterialWallZ : MonoBehaviour
{
	public float uScaleFactor = 1;
	public float vScaleFactor = 1;

	void Start ()
	{
		gameObject.transform.renderer.material.mainTextureScale = new Vector2(gameObject.transform.localScale.x * uScaleFactor, gameObject.transform.localScale.y * vScaleFactor);
	}
}
