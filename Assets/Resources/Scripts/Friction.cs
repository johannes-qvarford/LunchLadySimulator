using UnityEngine;
using System.Collections;

public class Friction : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Physics.IgnoreLayerCollision(8, 9);
		Physics.IgnoreLayerCollision(8,8);
	}
}
