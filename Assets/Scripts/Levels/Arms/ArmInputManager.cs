using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/**	Singleton class that abstract away the input device used to receive input in the game.

	TODO: rename to more fitting name given its new purpose, like "InputManager".
	TODO: change names that references joypads but are named joystick, to joypad. (like useJoystick to useJoypad)
**/
public class ArmInputManager : MonoSingleton<ArmInputManager>
{
	/** Constants used for convinience,
		so that users only need to write ArmInputManager.NAME instead of ArmInputManager.Class.NAME

		TODO: add missing constants.
	**/
	static public Arm LEFT = Arm.LEFT;
	static public Switch GRIP = Switch.GRIP;
	static public Movement HORIZONTAL = Movement.HORIZONTAL;
	static public Arm RIGHT = Arm.RIGHT;
	static public Movement VERTICAL = Movement.VERTICAL;
	static public Switch Y_MOVEMENT = Switch.Y_MOVEMENT;
	static public Switch Z_ROTATION = Switch.Z_ROTATION;

	public bool useJoystick = true;
	public bool use2Joysticks = false;

	private bool[,] switches = new bool[(int)Switch.SIZE, (int)Arm.SIZE];
	private bool[,] prevSwitches = new bool[(int)Switch.SIZE, (int)Arm.SIZE];

	/** Mapping between Unity input settings names to enum action constants.
	**/
	private static readonly Dictionary<Action, string> ACTION_STRING_NAMES = new Dictionary<Action, string>()
	{
		{Action.NEXT_OPTION_RIGHT, "NextOptionRight"},
		{Action.NEXT_OPTION_LEFT, "NextOptionLeft"},
		{Action.NEXT_OPTION_UP, "NextOptionUp"},
		{Action.NEXT_OPTION_DOWN, "NextOptionDown"},
		{Action.CONFIRM, "Confirm"},
		{Action.NEXT_CUSTOMER, "NextCustomer"},
		{Action.PAUSE, "Pause"}
	};

	public enum Movement
	{
		HORIZONTAL,
		VERTICAL
	}
	
	public enum Arm
	{
		LEFT,
		RIGHT,
		SIZE
	}

	public enum Switch
	{
		Y_MOVEMENT,
		Z_ROTATION,
		GRIP,
		SIZE
	}
	
	public enum Action
	{
		NEXT_OPTION_RIGHT,
		NEXT_OPTION_LEFT,
		NEXT_OPTION_UP,
		NEXT_OPTION_DOWN,
		CONFIRM,
		NEXT_CUSTOMER,
		PAUSE
	}

	/** Called to indicate whether or not two players should play the game
	**/
	public static void Use2Players(bool yes)
	{
		GetInstance().use2Joysticks = yes;
	}

	/**	Determines how much and in what direction the user is moving an arm.
	**/
	public static float GetMovement(Arm arm, Movement movement)
	{
		return GetInstance().GetMovementInternal(arm, movement);
	}
	
	/** Determines whether the user has given input for a certain action to perform this frame.
	**/
	public static bool IsDown(Action action)
	{
		return GetInstance().IsDownInternal(action);
	}

	/** Determine whether a certain button is held for a certain arm, 
		to indicate that the user wishes to perform an action while its active.
	**/
	public static bool IsHeld(Switch sw, Arm arm)
	{
		return GetInstance().IsHeldInternal(sw, arm);
	}
	
	/** Determine whether a button was changed from held to not held or vice versa this frame.
	**/
	public static bool HeldChanged(Switch sw, Arm arm)
	{
		return GetInstance().HeldChangedInternal(sw, arm);
	}

	/** Update various button states for use in other functions.
	**/
	public void Update()
	{
		/** Debugging code for swtiching from/to keyboard/gamepad mode and from/to one/two player(s)

			TODO: wrap in if debug statement to ease transition from and to debug mode
		**/
		if(Input.GetKeyDown(KeyCode.T))
		{
			useJoystick = !useJoystick;
		}
		if(Input.GetKeyDown(KeyCode.R))
		{
			use2Joysticks = !use2Joysticks;
		}
		
		for(int i = 0; i < (int)Switch.SIZE; ++i)
		{
			for(int j = 0; j < (int)Arm.SIZE; ++j)
			{
				Switch SWITCH = (Switch)i;
				Arm ARM = (Arm)j;
				prevSwitches[i, j] = switches[i, j];
				switches[i, j] = Input.GetButton(BuildName(ARM, SWITCH));
			}
		}
	}

	/** Functions used to construct strings that can be concatenated to Unity input button names used to test input held/axis values.
		
		TODO: Make code clearer, maybe by separating string building code to a seperate class?
	**/

	private static string BuildActionName(Action action)
	{
		return ACTION_STRING_NAMES[action];
	}

	private static string BuildMovementName(Movement movement)
	{
		return movement == Movement.HORIZONTAL ? "Horizontal" : "Vertical";
	}
	
	private string BuildControllerName()
	{
		return useJoystick ? "Joystick" : "";
	}

	private string BuildControllerName(Arm arm)
	{
		string WHICH_JOYSTICK = useJoystick ? "Joystick" + (use2Joysticks && arm == Arm.RIGHT ? "2" : "") : "";
		string WHICH_SIDE = arm == Arm.LEFT ? "Left" : "Right";
		return WHICH_JOYSTICK + WHICH_SIDE;
	}
	
	private string BuildJoystickOptionName(bool vertical)
	{
		return "JoystickNextOption" + (vertical ? "Vertical" : "");
	}
	
	private string BuildName(Action action)
	{
		return BuildControllerName() + BuildActionName(action);
	}

	private string BuildName(Arm arm, Switch sw)
	{
		var s = BuildControllerName(arm) + BuildToggleName(sw);
		return s;
	}

	private string BuildName(Arm arm, Movement movement)
	{
		return BuildControllerName(arm) + BuildMovementName(movement);
	}
	
	private static string BuildToggleName(Switch toggle) 
	{
		return toggle == Switch.Y_MOVEMENT ? "ToggleYMovement" : 
			 toggle == Switch.Z_ROTATION ? "ToggleZRotation" :
			 								"ToggleGrip";
	}

	private float GetMovementInternal(Arm arm, Movement movement)
	{
		return Input.GetAxis(BuildName(arm, movement));
	}
	
	private bool IsAnyEq(Action action, params Action[] actions)
	{
		return actions.Any((a) => a == action);
	}
	
	private bool IsDownInternal(Action action)
	{
		/* 	Some code relies on option selection being binary, either chosing another option or not.
			a joystick is used select options on a gamepad, so the axis value needs to normalized, which is a special case.
		*/
		bool IS_OPTION_VERTICAL = IsAnyEq(action, Action.NEXT_OPTION_DOWN, Action.NEXT_OPTION_UP);
		bool IS_OPTION_HOZIONTAL = IsAnyEq(action, Action.NEXT_OPTION_RIGHT, Action.NEXT_OPTION_LEFT);
		bool IS_OPTION_NEGATIVE = IsAnyEq(action, Action.NEXT_OPTION_LEFT, Action.NEXT_OPTION_DOWN);
		bool IS_OPTION = IS_OPTION_VERTICAL || IS_OPTION_HOZIONTAL;
		
		if(useJoystick && IS_OPTION)
		{
			float value = Input.GetAxis(BuildJoystickOptionName(IS_OPTION_VERTICAL));
			return (IS_OPTION_NEGATIVE && value < -0.5) || 
			(IS_OPTION_NEGATIVE == false && value > 0.5);
		}
		else
		{
			return Input.GetButtonDown(BuildName(action));
		}
	}
	
	private bool IsHeldInternal(Switch sw, Arm arm)
	{
		/* On an Xbox controller the bumpers are not buttons but joystick axices, and need to be normalized to binary.

			TODO: fix to not always assume Xbox controller, or decide to always use Xbox controllers.
		*/
		bool IS_XBOX = true;
		if(useJoystick && IS_XBOX && sw == Switch.Z_ROTATION) 
		{
			double axis = Input.GetAxis(BuildName(arm, sw));
			return (arm == Arm.LEFT && axis > 0.3) || (arm == Arm.RIGHT && axis < -0.3);
		}
		return Input.GetButton(BuildName(arm, sw));
	}

	private bool IsSwitchOnInternal(Switch sw, Arm arm)
	{
		return switches[(int)sw, (int)arm];
	}

	private void SetButtonState(Switch sw, Arm arm)
	{
		bool ON = switches[(int)sw, (int)arm];
		
	}
	
	private bool HeldChangedInternal(Switch sw, Arm arm)
	{
		return prevSwitches[(int)sw, (int)arm] != switches[(int)sw, (int)arm];
	}
}
