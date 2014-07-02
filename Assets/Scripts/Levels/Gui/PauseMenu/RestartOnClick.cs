using UnityEngine;

public class RestartOnClick : MonoBehaviour
{
	private void OnClick()
	{
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevelName);
	}
}