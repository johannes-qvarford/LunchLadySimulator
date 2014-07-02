using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/**
 * Class for accessing sound banks.
 * Currenly only for different types of NPC:s.
 **/
public class SoundBank : MonoBehaviour
{
	public FMODAsset[] bank;
	public string[] NpcType;

	private Dictionary<string, FMODAsset> NPC_TYPE_TO_SOUND_BANK = new Dictionary<string, FMODAsset>();
	void Start()
	{
		for(int i = 0; i < bank.Length; ++i)
		{
			NPC_TYPE_TO_SOUND_BANK[NpcType[i]] = bank[i];
		}
	}

	public FMODAsset GetNpcSound(string type)
	{
		return NPC_TYPE_TO_SOUND_BANK[type];
	}
}
