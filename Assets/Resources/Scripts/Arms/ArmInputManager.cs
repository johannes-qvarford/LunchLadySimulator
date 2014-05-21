using UnityEngine;
using System.Collections.Generic;

public class ArmInputManager : MonoSingleton<ArmInputManager>
{
	//for user convienience
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

	private static readonly Dictionary<Action, string> ACTION_STRING_NAMES = new Dictionary<Action, string>()
	{
		{Action.NEXT_OPTION_RIGHT, "NextOptionRight"},
		{Action.NEXT_OPTION_LEFT, "NextOptionLeft"},
		{Action.CONFIRM, "Confirm"},
		{Action.RESTART_LEVEL, "RestartLevel"}
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
		CONFIRM,
		RESTART_LEVEL,
	}

	public static float GetMovement(Arm arm, Movement movement)
	{
		return GetInstance().GetMovementInternal(arm, movement);
	}
	
	public static bool IsDown(Action action)
	{
		return GetInstance().IsDownInternal(action);
	}

	public static bool IsHeld(Switch sw, Arm arm)
	{
		return GetInstance().IsHeldInternal(sw, arm);
	}
	
	public static bool HeldChanged(Switch sw, Arm arm)
	{
		return GetInstance().HeldChangedInternal(sw, arm);
	}

	public void Update()
	{
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
	
	private string BuildJoystickOptionName()
	{
		return "JoystickNextOption";
	}
	
	private string BuildName(Action action)
	{
		return BuildControllerName() + BuildActionName(action);
	}

	private string BuildName(Arm arm, Switch sw)
	{
		return BuildControllerName(arm) + BuildToggleName(sw);
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
	
	private bool IsDownInternal(Action action)
	{
		//hack because joystick uses joystick axis to check option select button while keyboard uses 
		if(useJoystick && (action == Action.NEXT_OPTION_LEFT || action == Action.NEXT_OPTION_RIGHT))
		{
			float value = Input.GetAxis(BuildJoystickOptionName());
			return action == Action.NEXT_OPTION_LEFT && value < -0.5 || action == Action.NEXT_OPTION_RIGHT && value > 0.5;
		}
		else
		{
			return Input.GetButtonDown(BuildName(action));
		}
	}
	
	private bool IsHeldInternal(Switch sw, Arm arm)
	{
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
