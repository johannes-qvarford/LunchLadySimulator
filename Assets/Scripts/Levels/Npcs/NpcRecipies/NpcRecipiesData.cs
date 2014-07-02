using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

/**
  * Class for loading NPCRecipies.xml as an xml tree.
  * NpoRecipies.xml contains an array of type elements.
  * See NpcRecipieCustomerType for the structure of these type elements.
  **/
public class NpcRecipiesData
{
	public Dictionary<string, NpcRecipieCustomerType> CustomerTypesToRecipies { get; private set; }
	
	public static NpcRecipiesData LoadFromXElement(XElement element)
	{
		return new NpcRecipiesData
		{
			CustomerTypesToRecipies = element.Elements("type")
				.Select(elem => NpcRecipieCustomerType.LoadFromXElement(elem))
				.ToDictionary(type => type.Type, type => type)
		};
	}
}

