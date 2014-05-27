using UnityEngine;
using System.Collections;

public class ShowPauseMenu : MonoBehaviour {
	private bool paused = false;
	public GameObject graphics;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape"))
		{
			if(paused == false)
			{
				dispalyPauseMenu();
			}
			else
			{
				returnToGame();
			}
		}
	}
	private void dispalyPauseMenu()
	{
		graphics.SetActive(true);
		Time.timeScale = 0;
		paused = true;
	}
	public void returnToGame()
	{
		graphics.SetActive(false);
		Time.timeScale = 1;
		paused = false;
	}
}
