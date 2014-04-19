using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public string fileName;
	public MeshFilter meshFilter;
	// Use this for initialization
	void Start () 
	{
		ObjExporter.MeshToFile(meshFilter, fileName);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
