using System;
using UnityEngine;

/** Script used to identity a ToolHitBox.
 *
 * This script is attached to game objects with the Tool tag. It's used to separate certain kinds of colliders from others.
 * For example: every collider on the ladle but the handle has ToolHitBoxes, 
 * to prevent the spawning when only the handle is dipped into the soup.
 **/
public class ToolHitbox : MonoBehaviour
{
}
