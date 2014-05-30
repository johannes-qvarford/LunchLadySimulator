using System;
using UnityEngine;

/** Script used to identity a ToolHitBox.

	This script is attached to game objects with the Tool tag. It's used to separate certain kinds of colliders from others.
	Currently, those colliders whose game objects have attached ToolHitbox components 
	cause TriggerSpawner to start the tool's spawner to spawn objects
	when entering its trigger zones.
	For example: every collider on the ladle but the handle has ToolHitBoxes, 
	to prevent the spawner from spawning when only the handle is dipped into the soup.
**/
public class ToolHitbox : MonoBehaviour
{
}