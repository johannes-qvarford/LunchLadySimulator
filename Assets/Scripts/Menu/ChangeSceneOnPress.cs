using UnityEngine;
using System.Collections;

public class ChangeSceneOnPress : MonoBehaviour {
	public string sceneName;
	public GameObject leftButton;
	public GameObject rightButton;
	
	public bool isSelected = false;
	// Use this for initialization
	void OnMouseDown()
	{
		changeScene ();
	}
	
	void Update()
	{
		if(isSelected && ArmInputManager.IsDown(ArmInputManager.Action.CONFIRM))
		{
			changeScene();
		}
	}
	
	private void SelectedChanged(bool on)
	{
		isSelected = on;
		Debug.Log("got selected " + on);
	}
	
	private void changeScene()
	{
		Time.timeScale = 1;
		if(sceneName != null)
		{
			AsyncOperation async = Application.LoadLevelAsync(sceneName);
			Debug.Log("this scene");
		}
	}
}
