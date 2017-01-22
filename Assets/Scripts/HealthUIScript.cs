using UnityEngine;
using System.Collections;

/// <summary>
/// This will scale the health bar of the UI according to player's health
/// </summary>
public class HealthUIScript : MonoBehaviour {
    private HealthScript playerHealth;  // Just get the player's health!
    float originalScaleX;
	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>(); // Getting the health of the player
        originalScaleX = transform.localScale.x;    // get the scale of x!
        BeginScalingOfHealthBar();
	}
	
    void OnEnable() // When it is turned on, subscribe itself to the MessageSystem
    {
        MessageSystem.instance.setListener("ScaleHealthBar", BeginScalingOfHealthBar);
    }
    void OnDisable()    // When turned off, unsubscribe itself to the MessageSystem
    {
        MessageSystem.instance.removeListener("ScaleHealthBar", BeginScalingOfHealthBar);
    }

    void BeginScalingOfHealthBar()  // scale the health bar automatically
    {
        // Get the original scale X then mulitply by the ratio of current health to max health. other values remains the same
        float percentageOfPlayerOverallHealth = playerHealth.getCurrentHealth() / playerHealth.max_health_;
        if (percentageOfPlayerOverallHealth <= 0.25f) // Checking whether is it below 25 percent, change to red colour!
        {

        }
        else if (percentageOfPlayerOverallHealth <= 0.5f)   // less than 50 percent, change to orange colour!
        {

        }
        else
        {
            // It shall always stay at green color!

        }
        float resultingScaleX = originalScaleX * percentageOfPlayerOverallHealth;
        //Debug.Log("Resulting Scale X:" + resultingScaleX);
        //Debug.Log("PlayerHealth" + playerHealth.getCurrentHealth());
        transform.localScale = new Vector3(resultingScaleX, transform.localScale.y, transform.localScale.z);
    }
}
