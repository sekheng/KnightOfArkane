using UnityEngine;
using System.Collections;

/// <summary>
/// Just a simple damaging script actually.
/// </summary>
public class EnemyScript : MonoBehaviour {
    [Tooltip("Set the damage per second!")]
    public float DPS = 10.0f;

    //void OnTriggerEnter2D(Collider2D otherCollider)
    //{

    //}
    void OnTriggerStay2D(Collider2D otherCollider)  // Check and see if the other collider are staying within the trigger area. If so, deal damage!!!
    {

    }
}
