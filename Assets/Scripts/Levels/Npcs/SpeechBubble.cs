using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityExtensions;

/**
  * Class for displaying the food from a customers lunch order in a speechbubble.
  **/
public class SpeechBubble : MonoBehaviour
{
	public float speed = 3;
	public Transform bubbleGraphics;
	public Transform bubble;
	private Vector3 scale;
	
	void Start ()
	{
		scale = bubble.localScale;
		Hide();
	}
	
	public void LunchOrderCreated(LunchOrder lunchOrder)
	{
		var foodIds = lunchOrder.Recipies().Select(r => r.Name);
		
		var foodChildren = transform.Children().Where(child => child.gameObject != bubbleGraphics);
		
		var childrenToActivate = foodChildren
			.Where(child => foodIds.Any(id => MatchingFoodIds(id, child.name)))
			.Concat(new []{ bubbleGraphics });
		
		var childrenToDeactivate = foodChildren.Except(childrenToActivate);
		
		foreach (Transform child in childrenToActivate)
		{
			child.gameObject.SetActive(true);
		}
		
		foreach(Transform child in childrenToDeactivate)
		{
			child.gameObject.SetActive(false);
		}
	}
	
	public void Display()
	{
		InvokeRepeating("BubbleShownUpdate", time: 0, repeatRate: 1 / 30f);
	}
	
	public void Hide()
	{
		CancelInvoke("BubbleShownUpdate");
		gameObject.transform.localScale = new Vector3 (0, 0, 0);
	}
	
	private void BubbleShownUpdate()
	{
		bubble.localScale = Vector3.Lerp(gameObject.transform.localScale, scale, Time.deltaTime * speed);
	}
	
	private static bool MatchingFoodIds(string a, string b)
	{
		return a.ToLower() == b.ToLower();
	}
}
