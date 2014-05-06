using UnityEngine;
using System.Collections;

public class ShowSoupPlane : MonoBehaviour {
	public Color color;
	// Use this for initialization
	void Start () {
		Invoke ("showPlane", 1);
		//showPlane ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void showPlane()
	{
		
		renderer.material.SetColor("_MainColor", color);
	}
}
