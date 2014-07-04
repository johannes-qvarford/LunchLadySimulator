using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	private CameraFade fade;
	
	public float FadeInTime = 1.0f;
	public float FadeOutTime = 1.0f;
	
	public GameObject MagnusChair;
	
	public float EndGameTimer = 3.0f;
	public string NextScene = "logo";
	
	public Color FullFadeColor;
	public Color EmptyFadeColor;
	
	private float endTime;
	private bool ending = false;
	private bool trueEnding = false;
	private bool restarting = false;
	private Vector3 lunchGravity = Physics.gravity;
	
	void Start () {
		Physics.gravity = new Vector3(0.0f,-9.81f,0.0f);
		
		fade = GetComponent<CameraFade>(); 
		
		fade.SetScreenOverlayColor(FullFadeColor); //setup start fade color
		fade.StartFade(EmptyFadeColor, FadeInTime);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("MagnusRestart"))
		{
			restarting = true;
			
			fade.StartFade(FullFadeColor, FadeOutTime);
		}
		
		if(restarting && fade.m_CurrentScreenOverlayColor == fade.m_TargetScreenOverlayColor)
			Application.LoadLevel(Application.loadedLevel);
			
		if(trueEnding && fade.m_CurrentScreenOverlayColor == fade.m_TargetScreenOverlayColor)
		{
			Physics.gravity = lunchGravity;
			Application.LoadLevel(NextScene);
		}
		if(trueEnding == false)
		{
			if(ending == false && MagnusChair.rigidbody.velocity.magnitude < 0.1)
			{
				endTime = Time.time + EndGameTimer;
				ending = true;
			}
			else if(ending == true && MagnusChair.rigidbody.velocity.magnitude > 0.1)
			{
				ending = false;
			}
			
			if((ending == true && Time.time > endTime) || Input.GetButtonDown ("MagnusQuit"))
			{
				trueEnding = true;
				fade.StartFade(FullFadeColor, FadeOutTime);
			}
		}
	}
}
