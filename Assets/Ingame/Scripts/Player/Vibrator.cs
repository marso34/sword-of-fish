using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Vibrator : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityplayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityplayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "Vibrator");

#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void vibrate(long millisecond = 1000)
    {
        if (Isandroid())
            vibrator.Call("vibrate", millisecond);
        
        
    }
    public static void cancle()
    {
        if (Isandroid())
            vibrator.Call("cancle");
    }
    public static bool Isandroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
    return true;
#else 
        return false;
#endif
    }
}
*/