using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

/**
 * Class for magnet tracks.
 * Magnet tracks have a number of magnet boxes attached to themselves,
 * and every new magnetized object in range gets pulled to a free magnet box.
 **/
public class MagnetTrackBehaviour : MonoBehaviour
{
	public Transform[] magnets;

	private bool[] magnetBoxEmpty;

	void Start ()
	{
		magnetBoxEmpty = new bool[magnets.Count()].Select(b => true).ToArray();
	}
	
	public bool EmptyBoxAvailable()
	{
		return magnetBoxEmpty.Any(b => b == true);
	}

	public GameObject GetEmptyBox(Transform requester)
	{
		Func<Transform, Transform, float> Distance = (a, b) => (a.position - b.position).magnitude;
	
		var emptyIndex = magnetBoxEmpty
			.Select((empty, i) => new { Empty = empty, Index = i })
			.Where(ei => ei.Empty == true)
			.Select(ei => new { Index = ei.Index, Distance = Distance(requester, magnets[ei.Index]) })
			.OrderBy(ei => ei.Distance)
			.First().Index;
			
		return magnets[emptyIndex].gameObject;
	}
	
	public void SetMagnetBoxAvailable(GameObject returned)
	{
		int emptyIndex = magnets
			.Select((box, i) => new { Box = box, Index = i })
			.Single(bi => bi.Box.gameObject == returned)
			.Index;
		magnetBoxEmpty[emptyIndex] = true;
	}


}
