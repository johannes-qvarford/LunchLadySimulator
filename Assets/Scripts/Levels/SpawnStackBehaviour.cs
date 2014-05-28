using UnityEngine;
using System.Collections;

public sealed class SpawnStackBehaviour : MonoBehaviour
{
	public GameObject spawnPrefab;
	public GameObject spawnShadow;
	public Vector3 spawnOffsetFromHand = new Vector3(0, 0.04f, -0.2f);
}
