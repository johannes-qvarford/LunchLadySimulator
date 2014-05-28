using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	public int countDownTime;
	public GUIText gameOverText;
	public GUIText countDownText;
	public string countDownPreText = "Restart in ";
	public string countDownPostString = ".";
	private bool isGameOver;
	private Color color;
	private float countDownStart,volume;
	public FMODAsset gameOverSound;
	private GameObject masterVolumeObject;
	// Use this for initialization
	void Start ()
	{
		volume = 0f;
		masterVolumeObject = GameObject.FindWithTag(Tags.MASTERVOLUME);
		color = gameObject.guiText.color;
		gameOverText.color = new Color (0, 0, 0, 0);
		countDownText.color = new Color (0, 0, 0, 0);
		isGameOver = false;
	}
	public void triggerGameOver()
	{
		if (isGameOver == true)
			return;
		//Only run the following if we haven't alreaddy
		masterVolumeObject.SendMessage("SetVolumeOnSounds",volume,SendMessageOptions.RequireReceiver);
		FMOD_StudioSystem.instance.PlayOneShot(gameOverSound,transform.position);
		isGameOver = true;
		countDownText.color = color;
		gameOverText.color = color;
		countDownStart = Time.time;
		updateCountDown ();
	}
	// Update is called once per frame
	void Update ()
	{
		if (isGameOver == false)
			return;
		updateCountDown ();
	}
	private void updateCountDown ()
	{
		float remainingTime = countDownTime - (Time.time - countDownStart);
		if(remainingTime <= 0)
		{
			Application.LoadLevel (Application.loadedLevelName);
		}
		else
		{
			countDownText.text = countDownPreText + (int) Mathf.Ceil(remainingTime) + countDownPostString;
		}

	}
}
