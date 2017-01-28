using UnityEngine;
using System.Collections;

/// <summary>
/// What it will do is sending a message to the toastbox to display it
/// Will add sound effects and music soon!
/// </summary>
public class ButtonFeedbackScript : MonoBehaviour {
    [Tooltip("The string that you want to display for your toastbox when click once!")]
    public string theToastBoxMessage = "";

    [Tooltip("To Allow gestures, you will need to specify the string name")]
    public string theGestureToastMessage = "";
    [Tooltip("Adjust the distance of how far the finger should move to activate the gesture message!")]
    public float m_distance = 0;

    // Similar to the stuff on android studio
    private static AndroidJavaObject currentActivity, currentContext;
    private static AndroidJavaClass unityPlayer;
    private string theIntentedMessage;  // so that we can have multiple different messages displayed 

    // For gesture use Only!
    private Touch theFingerPressed; // Need to keep track of the 1st finger that has pressed the button for the gesture movement
    private RectTransform theUITransform;   // This is the UI transformation component!
    private bool hasFingerPressedIt = false;    // For gesture use only! Because waiting for event trigger will be too slow!
    private Vector2 initialFingerPos;   // For gesture use only! To get the initial position of the finger!
    private float swipeStartTime = 0;   // The Time when it starts to swipe
    private float maxSwipeTime = 1;    // How long the finger should stay there until it being decided that it isn't a swipe!
    // For gesture use Only!

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
        if (hasFingerPressedIt) // Need to check whether the finger has pressed it through the button!
        {
            float currentTimeSinceStartSwipe = 0;
            switch (theFingerPressed.phase)
            {
                case TouchPhase.Stationary: // if it is stationary, then no swipe!
                    currentTimeSinceStartSwipe = Time.time - swipeStartTime;  // Checking the total time!
                    if (currentTimeSinceStartSwipe > maxSwipeTime)  // Checking whether the finger has been stationary for too long!
                    {
                        hasFingerPressedIt = false;
                        theIntentedMessage = theToastBoxMessage;
                        showToastOnGUI();
                    }
                    break;
                case TouchPhase.Ended:
                    currentTimeSinceStartSwipe = Time.time - swipeStartTime;// Checking the total time!
                    float zeDistance = (theFingerPressed.position - initialFingerPos).magnitude; // Get the distance between the button and finger
                    float theRequiredDistance =  m_distance + (theUITransform.rect.width * 0.5f);   // We need to take the size of the button into account!
                    // For debugging purpose only!
                    //TextMesh zeDebugText = GameObject.Find("DebugMessage").GetComponent<TextMesh>();
                    //zeDebugText.text = "SwipeTime:" + currentTimeSinceStartSwipe + "\n" + "Distance:" + zeDistance + "\n Required Distance:" + theRequiredDistance;
                    // For debugging purpose only!
                    if (currentTimeSinceStartSwipe > maxSwipeTime // Checking whether the finger has been moving for too long!
                        || zeDistance <= theRequiredDistance)   // Or it is not up to the required swiping distance.
                    {
                        theIntentedMessage = theToastBoxMessage;
                    }
                    else
                    {
                        theIntentedMessage = theGestureToastMessage;
                    }
                    showToastOnGUI();
                    hasFingerPressedIt = false;                   
                    break;
                case TouchPhase.Began:
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Canceled:
                    //hasFingerPressedIt = false;
                    break;
            }
        }
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
                        initialFingerPos = new Vector2(theFingerPressed.position.x, theFingerPressed.position.y);
                        swipeStartTime = Time.time; // Begin Tracking down the time!
                        break;
                    }
            }
            hasFingerPressedIt = true;
        }
    }
    public void FingerLetGoOfButton()
    {
        if (m_distance > Mathf.Epsilon) // If the distance is already less than equals to 0. dont bother about it!
        {
            // Then we need to measure the distance and see if it is appropriate! And taking account of the width and height of the button
            Vector2 zeUIPos2D = new Vector2(theUITransform.position.x, theUITransform.position.y);
            float zeDistanceSqr = (theFingerPressed.position - zeUIPos2D).sqrMagnitude; // Get the distance between the button and finger
            float theRequiredDistanceSqr = (m_distance * m_distance) + theUITransform.sizeDelta.magnitude;   // We need to take the size of the button into account!
            //Debug.Log("Distance between Button and Finger:" + zeDistanceSqr);
            //Debug.Log("The Required Distance:" + theRequiredDistanceSqr);
            if (zeDistanceSqr >= theRequiredDistanceSqr)   // If the distance happens to be more than or equals to what we wanted, the message shall be the gesture message
            {
                theIntentedMessage = theGestureToastMessage;
            }
            else
            {   // If the swipping distance isn't ideal, then we will use the Pointer Click Message!
                theIntentedMessage = theToastBoxMessage;
            }
            showToastOnGUI();
        }
    }
}
