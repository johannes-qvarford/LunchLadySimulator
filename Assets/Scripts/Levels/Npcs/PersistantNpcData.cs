using System;
using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

/**
  * Singleton Class for accessing the contant of NpcRecipies and NpcProperties.
  * Objects that use this class does not need to worry about whether or not the contant
  * need to be loaded from disk.
  **/
public class PersistantNpcData : MonoSingleton<PersistantNpcData>
{
	private const string NPC_RECIPIES_PATH = "Npcs/XML/NpcRecipies";
	private const string NPC_PROPERTIES_PATH = "Npcs/XML/NpcProperties";

	public static NpcPropertiesData PropertiesData { get{ return GetInstance().GetPropertiesData(); } }
	public static NpcRecipiesData RecipiesData { get { return GetInstance().GetRecipiesData(); } }
	
	private NpcPropertiesData propertiesData;
	private NpcRecipiesData recipiesData;
	
	private NpcPropertiesData GetPropertiesData()
	{
		if(propertiesData == null)
		{
			propertiesData = NpcPropertiesData.LoadFromXElement(LoadXElementFromPath(NPC_PROPERTIES_PATH));
		}
		return propertiesData;
	}

	private NpcRecipiesData GetRecipiesData()
	{
		if(recipiesData == null)
		{
			recipiesData = NpcRecipiesData.LoadFromXElement(LoadXElementFromPath(NPC_RECIPIES_PATH));
		}
		return recipiesData;
	}
	
	private static XElement LoadXElementFromPath(string path)
	{
		TextAsset asset = Resources.Load<TextAsset>(path);
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(asset.text);
		return XElement.Load(new XmlNodeReader(doc));
	}
}
