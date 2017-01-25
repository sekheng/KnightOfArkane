using UnityEngine;
using System.Collections;

/// <summary>
/// What it will do is sending a message to the toastbox to display it
/// Will add sound effects and music soon!
/// </summary>
public class ButtonFeedbackScript : MonoBehaviour {
    [Tooltip("The string that you want to display for your toastbox when click once!")]
    public string theToastBoxMessage = "";

    // Similar to the stuff on android studio
    private AndroidJavaObject currentActivity, currentContext;
    private AndroidJavaClass unityPlayer;

	// Use this for initialization
	void Start ()
    {
#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android)    // Checking is it running on android phone!
        {
                //unityPlayer = new AndroidJavaClass("com.NYP.KnightOfArkane");   // Using company's name to register the player!
                unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                currentContext = currentActivity.Call<AndroidJavaObject>("getApplicationContext");  // Getting the object through function call
        }
	}
#endif
	// Update is called once per frame
	void Update () {
	
	}
    public void showToastOnGUI()
    {
    #if UNITY_ANDROID
    currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
#endif
    }
    void showToast()
    {
        Debug.Log("Trying to show Toast!");
        if (theToastBoxMessage != "")
        {
            AndroidJavaClass zeToastClass = new AndroidJavaClass("android.widget.Toast");    // Getting the toast widget from android!
            AndroidJavaObject zeJavaString = new AndroidJavaObject("java.lang.String", theToastBoxMessage);   // Having a Java String Class!
            AndroidJavaObject zeToast = zeToastClass.CallStatic<AndroidJavaObject>("makeText", currentContext, zeJavaString, zeToastClass.GetStatic<int>("LENGTH_SHORT"));
            zeToast.Call("show");
        }
    }
}
