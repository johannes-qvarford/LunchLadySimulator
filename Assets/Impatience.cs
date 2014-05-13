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
