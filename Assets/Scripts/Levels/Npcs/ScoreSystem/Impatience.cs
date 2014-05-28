using UnityEngine;
using System.Collections;

public class Impatience : MonoBehaviour {
	public float[] multipliers;
	public float[] timeTreshHolds;
	public TrayBehaviour tray;
	private int currentLevel;
	private float startTime;
	private float currentMultiplier;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		currentMultiplier = multipliers [currentLevel];
		tray.timeMultiplier = currentMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentLevel >= timeTreshHolds.Length -1)
		{
			return;
			Debug.Log("Totaly pissed off");
		}
		if(Time.time - startTime > timeTreshHolds[currentLevel +1])
		{
			increaseTreshHold();
		}
	}
	private void increaseTreshHold()
	{
		Debug.Log ("Growing impatient.");
		currentLevel++;
		currentMultiplier = multipliers [currentLevel];
		tray.timeMultiplier = currentMultiplier;
		// 0 1 2 3 4
		// 1 2 3
		
		// 0 0 1 1 2
		// +1
		// 1 1 2 2 3 
		SendMessage("SetMood", (currentLevel/2)+1,SendMessageOptions.RequireReceiver);
	}
	public int getImpatienceLevel()
	{
		return currentLevel;
	}
	public float getCurrentMultiplier()
	{
		return currentMultiplier;
	}
}
