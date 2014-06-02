using UnityEngine;
using System.Collections;

public class ChangeSceneOnPress : MonoBehaviour {
	public string sceneName;
	public GameObject leftButton;
	public GameObject rightButton;
	
	public bool isSelected = false;
	
	void OnClick()
	{
		changeScene();
	}
	
	// Use this for initialization
	void OnMouseDown()
	{

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
	}
	
	private void changeScene()
	{
		Time.timeScale = 1;
		if(sceneName != null)
		{
			Invoke("delayed", 0.1f);
		}
	}
	private void delayed()
	{
		AsyncOperation async = Application.LoadLevelAsync(sceneName);
	}
}
