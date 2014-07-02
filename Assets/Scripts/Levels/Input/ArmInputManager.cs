using UnityEngine;
using System.Collections.Generic;

/**
  * Singleton class for managing input related to the arm movement.
  * It helps classes who don't want to care if the player is using a gamepad or not etc.
  */
public class ArmInputManager : MonoSingleton<ArmInputManager>
{
	public enum Holdable
	{
		Z_ROTATION,
		Y_MOVEMENT
	}
	
	private const float AXIS_LOWER_LIMIT = 0.3f;
	
	public static float MovementOnAxis(bool horizontal, bool rightArm)
	{
		bool useJoypad = JoypadState.UseJoypad;
		bool use2Joypads = JoypadState.TwoPlayers;
		bool useSecondJoypad = use2Joypads && rightArm;
		
		/*
		 * Format:
		 * [Keyboard | FirstJoypad | SecondJoypad] [Left | Right] [Vertical | Horizontal]
		 * Example:
		 * Keyboard_Left_Horizontal
		 */
		 var part1 = useJoypad ? (useSecondJoypad ? "SecondJoypad" : "FirstJoypad") : "Keyboard";
		 var part2 = rightArm ? "Right" : "Left";
		 var part3 = horizontal ? "Horizontal" : "Vertical";
		 var name = string.Join("_", new []{part1, part2, part3});
		 return Input.GetAxis(name);
	}
	
	public static bool IsHeld(Holdable holdable, bool rightArm)
	{
		bool useJoypad = JoypadState.UseJoypad;
		bool twoPlayers = JoypadState.TwoPlayers;
		bool useSecondJoypad = twoPlayers && rightArm;
		bool useAxis = useJoypad && holdable == Holdable.Z_ROTATION;
		
		/*
		 * Format:
		 * [Keyboard | FirstJoypad | SecondJoypad] [Left | Right] [ZRotation | YMovement]
		 * Example:
		 * FirstJoypad_Right_ZRotation
		 */
		var part1 = useJoypad ? (useSecondJoypad ? "SecondJoypad" : "FirstJoypad") : "Keyboard";
		var part2 = rightArm ? "Right" : "Left";
		var part3 = holdable == Holdable.Z_ROTATION ? "ZRotation" : "YMovement";
		var name = string.Join("_", new []{part1, part2, part3});
		
		/*
		 * On an Xbox controller the bumpers are not buttons but joystick axices, and need to be normalized to held or not held.
		 */
		if(useAxis)
		{
			float axis = Input.GetAxis(name);
			
			return 	(rightArm == false 	&& axis > AXIS_LOWER_LIMIT) 
				|| 	(rightArm == true	&& axis < -AXIS_LOWER_LIMIT);
		}
		else
		{
			return Input.GetButton(name);
		}
	}
	
	public static bool IsGripPressed(bool rightArm)
	{
		/*
		 * Format:
		 * [Keyboard | FirstJoypad | SecondJoypad] [Left | Right] [Grip]
		 */
		bool useJoypad = JoypadState.UseJoypad;
		bool use2Joypads = JoypadState.TwoPlayers;
		bool useSecondJoypad = use2Joypads && rightArm;
		
		var part1 = useJoypad ? (useSecondJoypad ? "SecondJoypad" : "FirstJoypad") : "Keyboard";
		var part2 = rightArm ? "Right" : "Left";
		var part3 = "Grip";
		var name = string.Join("_", new []{part1, part2, part3});
		
		return Input.GetButtonDown(name);
	}
}