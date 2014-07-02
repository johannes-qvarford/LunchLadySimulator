using System;
using UnityEngine;
using System.Collections.Generic;

/** 
  * Utility class for providing compile time safety for FoodId names.
  *	
  *	The reason this class exist is that if you need to write a foodId name several times,
  *	you may misspell it and notice that your code doesn't work during runtime.
  *	If you instead misspell one of these constants you will get a compiler error.
  *	
  *	Note: This utility class does not contain all known FoodIds, only those that have been used in the project,
  *	If you need to use a food id anywhere in the code base, and the constant isn't here; just add it.
  *	
**/
public static class FoodIds
{
	public const string BREAD = "Bread";
}


