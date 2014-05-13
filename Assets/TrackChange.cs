using UnityEngine;
using System.Collections;

public class TrackChange : MonoBehaviour {

	public GameObject music;
	public float track;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		music.SendMessage("setTrack",track,SendMessageOptions.RequireReceiver);
	}
}
