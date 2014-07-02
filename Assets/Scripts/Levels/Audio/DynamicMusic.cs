using UnityEngine;
using System.Collections;

/**
 * Class used to set mood of bound game object from how well the player is doing.
 * 
 * TODO: Change Tags.DYNAMIC_MUSIC_BAR tag to Tags.HAPPY_BAR_INNER. This makes it easier to see that the information comes from the happy bar,
 * and others can look for the game object without arbitrarily use the tag "DYNAMICMUSIC".
 * 
 * TODO: Minor, but change Class name to DynamicModeSetter or something. DynamicMusic isn't as clear.
 */
public class DynamicMusic : MonoBehaviour
{
	private GameObject mood;
	void Start () 
	{	
		mood = GameObject.FindWithTag(Tags.DYNAMIC_MUSIC);
	}

	void Update () 
	{
		SendMessage("SetMood", mood.GetComponent<HappyBarController>().GetHappyPercentage(), SendMessageOptions.RequireReceiver);
	}
}
