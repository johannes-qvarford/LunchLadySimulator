using UnityEngine;
using System.Collections;

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

	public bool useJoystick = false;

	private bool[,] switches = new bool[(int)Switch.SIZE, (int)Arm.SIZE];
	private bool[,] prevSwitches = new bool[(int)Switch.SIZE, (int)Arm.SIZE];

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

	public static float GetMovement(Arm arm, Movement movement)
	{
		return GetInstance().GetMovementInternal(arm, movement);
	}

	public static bool IsOn(Switch sw, Arm arm)
	{
		return GetInstance().IsSwitchOnInternal(sw, arm);
	}
	
	public static bool OnToggled(Switch sw, Arm arm)
	{
		return GetInstance().OnToggledInternal(sw, arm);
	}

	public void Update()
	{
		for(int i = 0; i < (int)Switch.SIZE; ++i)
		{
			for(int j = 0; j < (int)Arm.SIZE; ++j)
			{
				prevSwitches[i,j] = switches[i, j];
				Switch SWITCH = (Switch)i;
				Arm ARM = (Arm)j;
				ToggleIfButtonDown(SWITCH, ARM);
			}
		}
	}

	private static string BuildMovementName(Arm arm, Movement movement)
	{
		return BuildArmName(arm) + 
			(movement == Movement.HORIZONTAL ? "Horizontal" : "Vertical");
	}

	private string BuildControllerName()
	{
		return useJoystick ? "Joystick" : "";
	}
	
	private static string BuildArmName(Arm arm)
	{
		return arm == Arm.LEFT ? "Left" : "Right";
	}

	private string BuildName(Arm arm, Switch sw)
	{
		return BuildControllerName() + BuildToggleName(arm, sw);
	}

	private string BuildName(Arm arm, Movement movement)
	{
		return BuildControllerName() + BuildMovementName(arm, movement);
	}
	
	private static string BuildToggleName(Arm arm, Switch toggle) 
	{
		return BuildArmName(arm) + 
			(toggle == Switch.Y_MOVEMENT ? "ToggleYMovement" : 
			 toggle == Switch.Z_ROTATION ? "ToggleZRotation" :
			 								"ToggleGrip");
	}

	private float GetMovementInternal(Arm arm, Movement movement)
	{
		return Input.GetAxis(BuildName(arm, movement));
	}

	private bool IsSwitchOnInternal(Switch sw, Arm arm)
	{
		return switches[(int)sw, (int)arm];
	}

	private void ToggleIfButtonDown(Switch sw, Arm arm)
	{
		bool ON = switches[(int)sw, (int)arm];
		switches[(int)sw, (int)arm] = Input.GetButtonDown(BuildName(arm, sw)) ? !ON : ON;
	}
	
	private bool OnToggledInternal(Switch sw, Arm arm)
	{
		return prevSwitches[(int)sw, (int)arm] != switches[(int)sw, (int)arm];
	}
}
