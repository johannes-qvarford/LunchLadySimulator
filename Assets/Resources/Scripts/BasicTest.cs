using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BasicTest : MonoBehaviour
{
	public Color diffuseColor;
	
	// Update is called once per frame
	void Update ()
	{
		renderer.sharedMaterial.SetColor( "_Color", diffuseColor );
	}
}
