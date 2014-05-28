using UnityEngine;
using System.Collections;

public class SoundBank : MonoBehaviour {

	// Use this for initialization
	public FMODAsset[] bank;
	public string[] NpcType;
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public FMODAsset GetNpcSound(string type)
	{
		int temp = 0;
		for(int i = 0; i < NpcType.Length; i ++)
		{
			if(NpcType[i].Equals(type))
			{
				temp = i;
				break;
			}
		}
		return bank[temp];
	}
}
