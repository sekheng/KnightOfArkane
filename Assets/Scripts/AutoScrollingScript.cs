using UnityEngine;
using System.Collections;

/// <summary>
/// For automated scrolling of text and UI stuff. So it is only for UI!
/// It will only scroll through Y-axis from top to down for now!
/// </summary>
public class AutoScrollingScript : MonoBehaviour {
    [Tooltip("Determine how long the scrolling should last! When the time is up, it will restart everything!")]
    public float m_MaxScrollingTime = 5.0f;
    private float m_Timer = 0;
    [Tooltip("How far should the scrolling based on Y-axis be going so as to put a limit to it")]
    public float howFarToScrollY = 100.0f;
    [Tooltip("How fast the scrolling should be!")]
    public float m_speed = 10.0f;
    private RectTransform UITransform;  // All UI will have RectTransform!
    private Vector3 originalPosition;   // We will need this for it to reset to it's original position!

	// Use this for initialization
	void Start () {
        UITransform = GetComponent<RectTransform>();
        originalPosition = new Vector3(UITransform.position.x, UITransform.position.y, UITransform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	    if (m_MaxScrollingTime > Mathf.Epsilon) // Need to make sure that it is more than 0. Otherwise no scrolling!
        {
            m_Timer += Time.deltaTime;
            if (m_Timer > m_MaxScrollingTime)   // If reaches more than the Max Scrolling Time, Reset Everything!
            {
                m_Timer = 0;
                UITransform.position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
            }
            else
            {
                UITransform.position = new Vector3(UITransform.position.x
                    , Mathf.Min(UITransform.position.y + (Time.deltaTime * m_speed), originalPosition.y + howFarToScrollY)  // We will also need to clamp it to the 
                    , UITransform.position.z);
            }
        }
	}
}
