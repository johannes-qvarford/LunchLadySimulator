using UnityEngine;
using System.Collections;
using UnityExtensions;

/**
 * Change the scene when the button is clicked.
 **/
public class MenuChangeSceneOnClick : MonoBehaviour
{
	public string sceneName;
	public float loadLevelDelay = 0.1f;
	
	void OnClick()
	{
		Time.timeScale = 1;
		Invoke("LoadLevel", loadLevelDelay);
	}

	private void LoadLevel()
	{
		Application.LoadLevelAsync(sceneName != "" ? sceneName : Application.loadedLevelName);
	}
}
