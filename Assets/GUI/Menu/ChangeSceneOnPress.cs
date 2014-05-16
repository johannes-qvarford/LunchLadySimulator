using UnityEngine;
using System.Collections;

public class ChangeSceneOnPress : MonoBehaviour {
	public string sceneName;
	// Use this for initialization
	void OnMouseDown()
	{
		Time.timeScale = 1;
		changeScene ();
	}
	private void changeScene()
	{
		if(sceneName != null)
		{
			AsyncOperation async = Application.LoadLevelAsync(sceneName);
		}
	}
}
