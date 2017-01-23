using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
    [Tooltip("This is to set the maximum health of the player only!")]
    public float max_health_ = 100.0f;
    private float health_;
    [Tooltip("This is the regeneration of health per second!")]
    public float Regeneration = 10;
    private float timeToRegenerate = 0;

    void Start()
    {
        health_ = max_health_;
        MessageSystem.instance.triggerEventCall("ScaleHealthBar");  // Calling the event. Otherwise the healthbar will be gone!
    }

    void Update()
    {
        timeToRegenerate += Time.deltaTime;
        if (!Mathf.Approximately(max_health_, health_) && timeToRegenerate > 2)   // If it is more than 2 second and health is not the same as max health
        {
            modifyHealth(Regeneration * Time.deltaTime);
            //Debug.Log("Regenerating!");
        }
    }
	
    // Modify the health value! Returns true if health is more than 0 and return false if the health is equal or lesser than 0
    public bool modifyHealth(float zeValue)
    {
        if (zeValue < Mathf.Epsilon)    // This means the player is taking damage!
        {
            timeToRegenerate = 0;   // Reset the regeneration counter!
        }
        health_ += zeValue;
        bool whatToReturn = true;
        if (health_ <= Mathf.Epsilon)
        {
            health_ = 0;
            whatToReturn = false;
        }
        else if (health_ >= max_health_)
            health_ = max_health_;
        MessageSystem.instance.triggerEventCall("ScaleHealthBar");  // Calling the event
        return whatToReturn;
    }

    public float getCurrentHealth()
    {
        return health_;
    }
}
