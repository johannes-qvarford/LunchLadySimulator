using UnityEngine;
using System.Collections;

public class TrackChange : MonoBehaviour {

	public float track;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SendMessage("SetTrack",track,SendMessageOptions.RequireReceiver);
	}
}
