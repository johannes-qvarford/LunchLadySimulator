using UnityEngine;
using System.Collections;

/**
  * Class for npc impatience.
  * As the NPC waits for their food they grow impatient.
  * Every time time passes over a special point they get more impatient.
  * There is a direct correlation between a customers impatience, the time multiplier of the served lunchOrder,
  *  and the "mood" of the customer.
  **/
public class Impatience : MonoBehaviour
{
	public float[] multipliers;
	public float[] timeTreshHolds;
	
	public float TimeWaited { get { return Time.time - startTime; } }
	public float TimeMultiplier { get {	return multipliers[ImpatienceLevel]; } }
	public float Mood { get { return ImpatienceLevelToMood(ImpatienceLevel); } }
	
	/**
	  * The impatiance level.
	  * It notifies interested MonoBehaviours when it's value is changed,
	  *  and the mood and time multiplier is changed as a result.
	  **/
	public int ImpatienceLevel
	{ 
		get
		{
			return impatienceLevel;
		}
		private set
		{
			impatienceLevel = value;
			SendMessage("SetMood", Mood, SendMessageOptions.RequireReceiver);
			SendMessage("TimeMultiplierChanged", TimeMultiplier, SendMessageOptions.RequireReceiver);
		}
	}
	
	
	
	private float startTime;
	private int impatienceLevel;
	
	void Start ()
	{
		startTime = Time.time;
		ImpatienceLevel = 0;
	}
	
	void Update ()
	{
		int nextLevel = ImpatienceLevel + 1;
		if(nextLevel < timeTreshHolds.Length && TimeWaited > timeTreshHolds[nextLevel])
		{
			ImpatienceLevel++;
		}
	}
	
	private int ImpatienceLevelToMood(int level)
	{
		//if impatience is 0,1,2,3,4
		//then mood becomes 1,1,2,2,3
		return (level / 2) + 1;
	}
}
