using UnityEngine;
using System.Collections;

/// <summary>
/// What it will do is sending a message to the toastbox to display it
/// Will add sound effects and music soon!
/// </summary>
public class ButtonFeedbackScript : MonoBehaviour {
    [Tooltip("The string that you want to display for your toastbox when click once!")]
    public string theToastBoxMessage = "";

    [Tooltip("How many time do u want it to count down")]
    public int m_countdown = 1;

    [Tooltip("To Allow gestures, you will need to specify the string name")]
    public string theGestureToastMessage = "";
    [Tooltip("Adjust the distance of how far the finger should move to activate the gesture message!")]
    public float m_distance = 0;

    // Similar to the stuff on android studio
    private static AndroidJavaObject currentActivity, currentContext;
    private static AndroidJavaClass unityPlayer;
    private string theIntentedMessage;  // so that we can have multiple different messages displayed 

    private Touch theFingerPressed; // Need to keep track of the 1st finger that has pressed the button for the gesture movement
    private RectTransform theUITransform;   // This is the UI transformation component!

	// Use this for initialization
	void Start ()
    {
        theIntentedMessage = theToastBoxMessage;    // The first message will definitely be the click message!
        theUITransform = GetComponent<RectTransform>();
#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android)    // Checking is it running on android phone!
        {
                //unityPlayer = new AndroidJavaClass("com.NYP.KnightOfArkane");   // Using company's name to register the player!
                unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                currentContext = currentActivity.Call<AndroidJavaObject>("getApplicationContext");  // Getting the object through function call
        }
#endif
	}
	// Update is called once per frame
	void Update () {
	}

    public void showToastOnGUI()
    {
    #if UNITY_ANDROID   // Making sure the platform is Android!
        if (Application.platform == RuntimePlatform.Android)    // Checking is it running on android phone!
            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
#endif
    }

    void showToast()
    {
        Debug.Log("Trying to show Toast!");
        if (theIntentedMessage != "")
        {
            AndroidJavaClass zeToastClass = new AndroidJavaClass("android.widget.Toast");    // Getting the toast widget from android!
            AndroidJavaObject zeJavaString = new AndroidJavaObject("java.lang.String", theIntentedMessage);   // Having a Java String Class!
            AndroidJavaObject zeToast = zeToastClass.CallStatic<AndroidJavaObject>("makeText", currentContext, zeJavaString, zeToastClass.GetStatic<int>("LENGTH_SHORT"));
            zeToast.Call("show");
        }
    }

    public void PressedFingerOnButton() // For gestures
    {
        if (m_distance > Mathf.Epsilon) // If the distance is already less than equals to 0. dont bother about it!
        {
            // First need to know the exact distance!
            Touch[] allTheTouch = Input.touches;
            foreach (Touch zeTouch in allTheTouch)  // Iterate through all the loops and find which finger is the 1 pressed on it!
            {
                if (zeTouch.position.x < theUITransform.position.x + (theUITransform.sizeDelta.x * 0.5f) && zeTouch.position.x > theUITransform.position.x - (theUITransform.sizeDelta.x * 0.5f)
                        && zeTouch.position.y < theUITransform.position.y + (theUITransform.sizeDelta.y * 0.5f) && zeTouch.position.y > theUITransform.position.y - (theUITransform.sizeDelta.y * 0.5f))    // Check whether any of the touches are within the button
                    {
                        theFingerPressed = zeTouch; // Track down this finger!
                        break;
                    }
            }
        }
    }
    public void FingerLetGoOfButton()
    {
        if (m_distance > Mathf.Epsilon) // If the distance is already less than equals to 0. dont bother about it!
        {

        }
    }
}
