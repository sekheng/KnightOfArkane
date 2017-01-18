using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
    [Tooltip("This is to set the maximum health of the player only!")]
    public float max_health_ = 100.0f;
    private float health_;
	// I have to use Awake as HealthUIScript is dependent on this!
    void Awake()
    {
        health_ = max_health_;
    }
	
    // Modify the health value! Returns true if health is more than 0 and return false if the health is equal or lesser than 0
    public bool modifyHealth(float zeValue)
    {
        health_ += zeValue;
        if (health_ <= Mathf.Epsilon)   
            return false;
        else if (health_ >= max_health_)
            health_ = max_health_;
        return true;
    }

    public float getCurrentHealth()
    {
        return health_;
    }
}
