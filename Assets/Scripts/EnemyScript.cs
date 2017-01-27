using UnityEngine;
using System.Collections;

/// <summary>
/// Just a simple damaging script actually.
/// </summary>
public class EnemyScript : MonoBehaviour {
    [Tooltip("Set the damage per second!")]
    public float DPS = 10.0f;

    private bool PlayerColliding;
    private HealthScript playerHealth;

    void Start()
    {
        playerHealth = null;
        PlayerColliding = false;
    }

    void Update()
    {
        if (playerHealth && PlayerColliding)    // Check whether Playerhealth is not a null and PlayerColliding is true
        {
            playerHealth.modifyHealth(-DPS * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("Enter Collision");
    }
    void OnTriggerStay2D(Collider2D otherCollider)  // Check and see if the other collider are staying within the trigger area. If so, deal damage!!!
    {
        if (otherCollider.CompareTag("Player")) // Check whether is it the player
        {
            //Debug.Log("Staying in Collision!");
            // Using Broadcast Message so that I dont have to get component.
            PlayerColliding = true;
            playerHealth = otherCollider.GetComponent<HealthScript>();
        }
    }
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player")) // Check is it the player
        {
            //Debug.Log("Exit Collision");
            playerHealth = null;
            PlayerColliding = false;
        }
    }
}
