using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This will scale the health bar of the UI according to player's health
/// </summary>
public class HealthUIScript : MonoBehaviour {
    private HealthScript playerHealth;  // Just get the player's health!
    private Image backgroundColorOfHealth;  // For changing of the color!

    private float originalScaleX;
    private GameObject DangerUIStuff;  // Get the danger UI related stuff!
    private Image DangerUIImage;    // Need to change the alpha of the Image

    [Tooltip("For the animation time of the alpha of highlighting low health! We will be using exponent for more realism")]
    public float m_timeToggle = 1.0f;
    [Tooltip("The maximum alpha of the highlight Danger can reached")]
    public float max_alphaForDanger = 1;
    [Tooltip("The minimum alpha of the highlight Danger can reached")]
    public float min_alphaForDanger = 0.3f;
    private float m_Timer_Danger = 0;
    private int toggleDangerAlpha = 1;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>(); // Getting the health of the player
        DangerUIStuff = GameObject.FindGameObjectWithTag("HealthUI");
        DangerUIImage = DangerUIStuff.GetComponent<Image>();
        //Debug.Log("First Alpha:" + DangerUIImage.color.a);
        backgroundColorOfHealth = GetComponent<Image>();
        originalScaleX = transform.localScale.x;    // get the scale of x!
        BeginScalingOfHealthBar();
	}

    void Update()
    {
        // Update the animation of danger with just the use of alpha!
        if (DangerUIStuff.activeSelf)
        {
            //Debug.Log("showing danger");
            m_Timer_Danger += Time.deltaTime;
            float resultAlpha = Mathf.Clamp(DangerUIImage.color.a - (Time.deltaTime * toggleDangerAlpha), min_alphaForDanger, max_alphaForDanger);
            //Debug.Log("Result Alpha:" + resultAlpha);
            DangerUIImage.color = new Color(DangerUIImage.color.r, DangerUIImage.color.g, DangerUIImage.color.b, resultAlpha);
            if (m_Timer_Danger >= m_timeToggle) // We will increase / decrease alpha whenever we reached the time!
            {
                m_Timer_Danger = 0;
                toggleDangerAlpha *= -1;
            }
        }
    }
	
    void OnEnable() // When it is turned on, subscribe itself to the MessageSystem
    {
        if (MessageSystem.instance)
            MessageSystem.instance.setListener("ScaleHealthBar", BeginScalingOfHealthBar);
    }
    void OnDisable()    // When turned off, unsubscribe itself to the MessageSystem
    {
        if (MessageSystem.instance)
            MessageSystem.instance.removeListener("ScaleHealthBar", BeginScalingOfHealthBar);
    }

    void BeginScalingOfHealthBar()  // scale the health bar automatically
    {
        // Get the original scale X then mulitply by the ratio of current health to max health. other values remains the same
        float percentageOfPlayerOverallHealth = playerHealth.getCurrentHealth() / playerHealth.max_health_;
        //Debug.Log("Current Percentage Of Health=" + percentageOfPlayerOverallHealth);
        if (percentageOfPlayerOverallHealth <= 0.25f) // Checking whether is it below 25 percent, change to red colour!
        {
            backgroundColorOfHealth.color = new Color32(237, 7, 7, 255);
            // Here we will have to highlight how low the player's health is!
            if (!DangerUIStuff.activeSelf)
                DangerUIStuff.SetActive(true);
            //Debug.Log("Changed To Red");
        }
        else if (percentageOfPlayerOverallHealth <= 0.5f)   // less than 50 percent, change to orange colour!
        {
            backgroundColorOfHealth.color = new Color32(226, 145, 4, 255);
            if (DangerUIStuff.activeSelf)
            {
                DangerUIStuff.SetActive(false);
            }
            //Debug.Log("Changed To Orange!");
        }
        else
        {
            // It shall always stay at green color!
            backgroundColorOfHealth.color = new Color32(30, 255, 0, 255);
            if (DangerUIStuff.activeSelf)
            {
                DangerUIStuff.SetActive(false);
            }
            //Debug.Log("Changed To Green!");
        }
        float resultingScaleX = originalScaleX * percentageOfPlayerOverallHealth;
        //Debug.Log("Resulting Scale X:" + resultingScaleX);
        //Debug.Log("PlayerHealth" + playerHealth.getCurrentHealth());
        transform.localScale = new Vector3(resultingScaleX, transform.localScale.y, transform.localScale.z);
    }
}
