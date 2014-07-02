using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

/**
  * Class for loading NPCProperties.xml as an xml tree.
  * NpcProperties.xml contains an array of category elements.
  * See NpcPropertyCustomerType for the structure of these category elements.
  **/
public class NpcPropertiesData
{
	public Dictionary<string, NpcPropertyCustomerType> CustomerTypesToProperties { get; private set; }
	
	public static NpcPropertiesData LoadFromXElement(XElement element)
	{
		return new NpcPropertiesData
		{
			CustomerTypesToProperties = 
				element.Elements("category")
					.Select(elem => NpcPropertyCustomerType.LoadFromXElement(elem))
					.ToDictionary(cat => cat.Name, cat => cat)
		};
	}
}

