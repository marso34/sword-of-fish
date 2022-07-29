using UnityEngine;
using System.Collections;

public class Vibrate
{
    
#if UNITY_ANDROID && !UNITY_EDITOR
    public AndroidJavaClass unityPlayer = null;
    public AndroidJavaObject currentActivity = null;
    public AndroidJavaObject AndroidVibrator = null;
#endif



    //Functions from https://developer.android.com/reference/android/os/Vibrator.html
  

    public void vibrate(long milliseconds)
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
        unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidVibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidVibrator.Call("vibrate", milliseconds);
#else
        Handheld.Vibrate();
#endif
    }

    public void vibrate(long[] pattern, int repeat)
    {
        
#if UNITY_ANDROID && !UNITY_EDITOR    
        AndroidVibrator.Call("vibrate", pattern, repeat);
#else
		 Handheld.Vibrate();
#endif
    }


    public void cancel()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidVibrator.Call("cancel");
#endif
    }

    public bool hasVibrator()
    {
    	bool returnValue = false;
#if UNITY_ANDROID && !UNITY_EDITOR        
        returnValue = AndroidVibrator.Call<bool>("hasVibrator");
#endif
		return returnValue;
    }
}