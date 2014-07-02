using UnityEngine;
using System.Collections;

/**
 * Class for scaling material by a factor based on transform local x and z scale to u and v scale.
 * 
 * TODO: Rename to ScaleMaterialFromXZ.
 **/
public class ScaleMaterialFloor : MonoBehaviour
{
	public float uScaleFactor = 0.25f;
	public float vScaleFactor = 0.25f;

	void Start ()
	{
		gameObject.transform.renderer.material.mainTextureScale = new Vector2(gameObject.transform.localScale.x * uScaleFactor, gameObject.transform.localScale.z * vScaleFactor);
	}
}
