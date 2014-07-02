using UnityEngine;

/**
  * Utility class for functionality shared by several other FMOD classes.
  **/
public static class FMODUtility 
{
	public static FMOD.Studio.EventInstance GetEvent(FMODAsset eventPath)
	{
		var ev = FMOD_StudioSystem.instance.GetEvent(eventPath);
		if(ev == null)
		{
			Debug.LogError(string.Format("Could not load FMOD event at path '{0}'", ev));
			Debug.DebugBreak();
		}
		return ev;
	}
	
	public static FMOD.Studio.ParameterInstance GetParameter(FMOD.Studio.EventInstance ev, string parameterName)
	{
		FMOD.Studio.ParameterInstance param;
		if(ev.getParameter(parameterName, out param) != FMOD.RESULT.OK)
		{
			Debug.LogWarning(string.Format("Could not find parameter '{0}' in sound bank", parameterName));
		}
		return param;
	}
}
