using UnityEngine;


/**
  * Singleton class for managing input NOT related to the arm movement.
  * It helps classes who don't want to care if the player is using a gamepad or not etc.
  *
  * Based on joypad is used, and what actions state should be checked,
  * DIfferent strings are built to be passed to Input.GetButton() or Input.GetAxis().
  * The structure of these strings are described in the methods.
  **/
public class ActionInputManager : MonoSingleton<ActionInputManager>
{
	public enum Action
	{
		OPTION_RIGHT,
		OPTION_LEFT,
		OPTION_UP,
		OPTION_DOWN,
		CONFIRM,
		PAUSE,
		NEXT_CUSTOMER
	}
	
	private const float AXIS_LOWER_BOUND = 0.5f;
	
	public static bool ActionIsPerformed(Action action)
	{
		bool useJoypad = JoypadState.UseJoypad;
		bool selectOption = action != Action.CONFIRM && action != Action.PAUSE && action != Action.NEXT_CUSTOMER;
		bool optionNegative = action == Action.OPTION_DOWN || action == Action.OPTION_LEFT;
		bool optionHorizontal = action == Action.OPTION_RIGHT || action == Action.OPTION_LEFT;
		
		/*
		 * Format: (Keyboard cannot be combined with Option_Vertical or Option_Horizontal, while Joypad cannot with the other Option_XXX)
		 * [Keyboard | Joypad] _ [[Option _ [Right | Left | Up | Down | Vertical | Horizontal]] | Confirm | Pause | NextCustomer]
		 * Example:
		 * Keyboard_Confirm
		 * Joypad_Option_Vertical
		 * Keyboard_Option_Right
		 */
		
		string part1 = useJoypad ? "Joypad" : "Keyboard";
		string part2 = null;
		if(selectOption)
		{
			string part21 = "Option";
			string part22 = null;
			if(useJoypad)
			{
				part22 = optionHorizontal ? "Horizontal" : "Vertical";
			}
			else
			{
				switch(action)
				{
				case Action.OPTION_RIGHT: part22 = "Right"; break;
				case Action.OPTION_LEFT: part22 = "Left"; break;
				case Action.OPTION_UP: part22 = "Up"; break;
				case Action.OPTION_DOWN: part22 = "Down"; break;
				default: break; 
				}
			}
			part2 = string.Join("_", new []{part21, part22});		}
		else
		{
			part2 = action == Action.CONFIRM ? "Confirm" : (action == Action.PAUSE ? "Pause" : "NextCustomer");
		}
		
		var name = string.Join("_", new []{part1, part2});
		
		/*
		 * Select options are done with joysticks on joypads, and they need to be normalized to held or not.
		 */
		if(selectOption && useJoypad)
		{
			float axis = Input.GetAxis(name);
			return (optionNegative && axis < -AXIS_LOWER_BOUND) || 
				(optionNegative == false && axis > AXIS_LOWER_BOUND);
		}
		else
		{
			return Input.GetButtonDown(name);
		}
	}
}


