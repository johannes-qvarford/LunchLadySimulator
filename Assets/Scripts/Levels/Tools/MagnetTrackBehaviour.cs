using UnityEngine;
using System.Collections;

public class MagnetTrackBehaviour : MonoBehaviour {


	bool[] magnetBoxEmpty;


	// Use this for initialization
	void Start () {
		magnetBoxEmpty = new bool[3];
		for(int i = 0;i < magnetBoxEmpty.Length;i++)
		{
			magnetBoxEmpty[i] = true;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

	public bool isEmptyBox()
	{
		foreach(bool p in magnetBoxEmpty)
		{
			if(p)
			{
				return true;
			}	
		}
		return false;
	}

	public GameObject GetEmptyBox()
	{
		
		for(int i = 0 ; i < magnetBoxEmpty.Length;i++)
		{
			if(magnetBoxEmpty[i])
			{
				magnetBoxEmpty[i] = false;
				int p = i +1;
				GameObject obj = transform.Find("magnet"+p.ToString ()).gameObject;
				return obj;
			
			}
			
		}	
	
		return transform.Find("magnet1").gameObject;		

	}
	
	public void SetMagnetPositionEmpty(string box)
	{
		if(box != "none")
		{
			char decimalMagnetName = box[6];
		
		
			
			int value;
			if(int.TryParse(decimalMagnetName.ToString(),out value))
			{
			
			}
			else
			{
			
			}
			
			magnetBoxEmpty[value-1] = true;
		}
	}


}
