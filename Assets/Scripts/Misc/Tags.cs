using UnityEngine;

/** Utility class for providing compile time safety for Tags.
	
	The reason this class exist is that if you need to write a tag several times,
	you may misspell it and notice that your code doesn't work during runtime for some reason.
	If you instead misspell one of these constants you will get a compile time error.
**/
public static class Tags
{
	public const string LEFT_HAND_TARGET = "LeftHandTarget";
	public const string RIGHT_HAND_TARGET = "RightHandTarget";
	public const string TOOL = "Tool";
	public const string SPAWN_STACK = "SpawnStack";
	public const string LEFT_ARM = "LeftArm";
	public const string RIGHT_ARM = "RightArm";
	public const string SPAWN_ZONE = "SpawnZone";
	public const string FOOD = "Food";
	public const string SPAWNER = "Spawner";
	public const string NPC = "NPC";
	public const string PLATE = "Plate";
	public const string FOOD_PLATE = "FoodPlate";
	public const string DESTROY = "Destroy";
	public const string STOP = "Stop";
	public const string TURN = "Turn";
	/**
		TODO: fix these to use the correct naming convention; GUI_SOUND instead of GUISOUND etc.
	**/
	public const string GUISOUND = "GuiSound";
	public const string NPCSOUNDBANK = "NpcSoundBank";
	public const string DYNAMICMUSIC = "DynamicMusic";
	public const string MASTERVOLUME = "MasterVolume";
	public const string MAGNET_FIELD = "MagnetField";

	/*
		TODO: rewrite using Linq
	*/

	/** Find the first ancestor of a transform or the transform itself,
		that has a certain tag.
	**/
	public static Transform FindWithTagRecursive(Transform t, string tag)
	{
		if(t.gameObject.tag == tag)
		{
			return t;
		}
		for(int i = 0; i < t.childCount; ++i)
		{
			Transform found = FindWithTagRecursive(t.GetChild(i), tag);
			if(found != null)
			{
				return found;
			}
		}
		return null;
	}
}

