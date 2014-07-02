using UnityEngine;
using System.Collections;

/**
  * Script for displaying game over when the player loses.
  * When an object calls TriggerGameOver() the game over text is displayed, and counts down.
  * When time is up, the level is reloaded.
  **/
public class GameOverScript : MonoBehaviour
{
	public int countDownTime;
	public GUIText gameOverText;
	public GUIText countDownText;
	public string countDownPreText = "Restart in ";
	public string countDownPostString = ".";
	public GameObject backGround;
	public FMODAsset gameOverSound;

	private DoOncer gameOverOnce = new DoOncer();
	private Color color;
	private float countDownStart;
	private float volume;
	private GameObject masterVolumeObject;

	void Start ()
	{
		volume = 0f;
		masterVolumeObject = GameObject.FindWithTag(Tags.MASTER_VOLUME);
		color = gameObject.guiText.color;
		gameOverText.color = new Color (0, 0, 0, 0);
		countDownText.color = new Color (0, 0, 0, 0);
	}

	public void TriggerGameOver()
	{
		gameOverOnce.doOnce(() => {
			InvokeRepeating("GameOverUpdate", time: 0, repeatRate: 1);
			backGround.SetActive(true);
			countDownText.color = color;
			gameOverText.color = color;
			countDownStart = Time.time;
			masterVolumeObject.BroadcastMessage("SetMaster", volume, SendMessageOptions.RequireReceiver);
			FMOD_StudioSystem.instance.PlayOneShot(gameOverSound, transform.position);
		});
	}
	
	void GameOverUpdate()
	{
		float remainingTime = countDownTime - (Time.time - countDownStart);
		countDownText.text = countDownPreText + (int) Mathf.Ceil(remainingTime) + countDownPostString;
		
		if(remainingTime <= 0)
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
