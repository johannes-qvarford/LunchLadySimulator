using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour {
	public float speed = 3;
	public string bubbleName = "_Bubble";
	private Vector3 scale;
	// Use this for initialization
	private bool isFirst = false;
	public void displayFood(string food)
	{
		foreach (Transform child in transform)
		{
			if(child.name.ToLower() == food.ToLower())
			{
				child.gameObject.SetActive(true);
			}
		}
	}
	public void clear()
	{
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}
		displayFood (bubbleName);
	}
	void Start () {
		scale = gameObject.transform.localScale;
		hide ();
	}
	public void display()
	{
		isFirst = true;
		displayFood ("breaD");
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
		//Debug.Log("showing bubble");
		Vector3 newScale = Vector3.Lerp (gameObject.transform.localScale, scale, Time.deltaTime * speed);
		gameObject.transform.localScale = newScale;
	}
}
