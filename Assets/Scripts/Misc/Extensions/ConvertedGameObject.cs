using System;
using UnityEngine;

/**
 * Class to use for extension methdods that should take either a GameObject or a Component.
 * GameObject and Component don't share a common base class with the method GetComponent<T>(),
 * and therefor, to use an extension method aimed for either, 3 things could be done.
 * 
 * 1. Always write one extension method and have caller send in the right an object of the right type.
 *    This has the advantage of not having to write several methods, but sometimes a Componenent isn't more fitting than a GameObject, and caller also has to write more code.
 * 2. Write two extension methods. This is the reverse of the above.
 * 3. Use a class which GameObject and Component can implicitly converted to. This has all the advantages above,
 *    except for the fact that the GameObject/Component has to be extracted in the method.
 *
 * The third option was chosen for this task.
 *
 **/
public class ConvertedGameObject
{
	public GameObject OwnerGameObject { get; private set; }
	
	public ConvertedGameObject ()
	{
	}
	
	public static implicit operator ConvertedGameObject(GameObject g)
	{
		return new ConvertedGameObject { OwnerGameObject = g };
	}
	
	public static implicit operator ConvertedGameObject(Component c)
	{
		return new ConvertedGameObject { OwnerGameObject = c.gameObject };
	}
	
	public static implicit operator GameObject(ConvertedGameObject cg)
	{
		return cg.OwnerGameObject;
	}
}


