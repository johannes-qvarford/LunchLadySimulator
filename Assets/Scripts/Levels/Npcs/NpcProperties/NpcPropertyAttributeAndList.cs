using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

/** 
  * Class for loading xml elements with a single attribute, and a list of list.
  * A lot of XML elements in NpcProperties.xml has the structure: 
  *  <elementtype attributeName="x"> <listItemName>y1<listItemName> <listItemName>y2</listItemName> ... </elementtype>
  * This class can load such an element, and places the attribute "x" in Attribute,
  * and the list of [y1, y2 ...] in List.
  **/
public class NpcPropertyAttributeAndList
{
	public string Attribute { get; private set; }
	public List<String> List { get; private set; }
	
	private string attribute;
	private string list;
	
	public static NpcPropertyAttributeAndList LoadFromXElement(XElement element, string attributeName, string listItemName)
	{
		string attribute = element.Attribute(attributeName).Value;
		List<String> list = element.Elements(listItemName)
			.Select(elem => elem.Value)
			.ToList();
		return new NpcPropertyAttributeAndList
		{
			Attribute = attribute,
			List = list
		};
	}
}