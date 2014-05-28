using UnityEngine;

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
	public const string GUISOUND = "GuiSound";
	public const string NPCSOUNDBANK = "NpcSoundBank";
	public const string DYNAMICMUSIC = "DynamicMusic";
	public const string MAGNET_FIELD = "MagnetField";	


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

