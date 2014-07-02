
using UnityEngine;

/**
  * Holds the state whether or not the joypad should be used, and whether or not two players can play.
  **/
public class JoypadState : MonoSingleton<JoypadState>
{
	public bool debug = true;
	public bool useJoypad;
	public bool twoPlayers;
	
	public static bool UseJoypad{ get{ return GetInstance().useJoypad; } set { GetInstance().useJoypad = value; } }
	public static bool TwoPlayers{ get { return GetInstance().twoPlayers; } set { GetInstance().twoPlayers = value; } }
	
	void Update()
	{
		if(debug)
		{
			/*
			 * Used for debugging and playtestning.
			 */
			if(Input.GetKeyDown(KeyCode.T))
			{
				useJoypad = !useJoypad;
			}
			if(Input.GetKeyDown(KeyCode.R))
			{
				twoPlayers = !twoPlayers;
			}
		}
	}
}