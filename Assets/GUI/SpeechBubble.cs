using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour {
	public float speed = 3;
	private Vector3 scale;
	// Use this for initialization
	private bool isFirst = false;
	void Start () {
		scale = gameObject.transform.localScale;
		hide ();
	}
	public void display()
	{
		//gameObject.transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
		isFirst = true;
	}
	public void hide()
	{

		gameObject.transform.localScale = new Vector3 (0, 0, 0);
		isFirst = false;
	}
	// Update is called once per frame
	void Update () {
		if (isFirst == false)
			return;
		Vector3 newScale = Vector3.Lerp (gameObject.transform.localScale, scale, Time.deltaTime * speed);
		gameObject.transform.localScale = newScale;
	}
}
