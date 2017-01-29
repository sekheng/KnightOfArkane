using UnityEngine;
using System.Collections;

/// <summary>
/// This is only meant for the camera to be follow the player in 2D axis!
/// There should only be 1 character until this script has been modified
/// </summary>
public class FollowHeroScript : MonoBehaviour {
    private GameObject theHero; // we will use this to track the position of the hero
	// Use this for initialization
	void Start () {
        theHero = GameObject.FindGameObjectWithTag("Player");
	}
	
    // This is used so that after the player has moved, then the camera shall move
    void LateUpdate()
    {
        // check whether the position of x and z of that camera and hero is it the same.
        // If not, change them!
        if (!Mathf.Approximately(transform.position.x, theHero.transform.position.x) || !Mathf.Approximately(transform.position.y, theHero.transform.position.y))
        {
            transform.position = new Vector3(theHero.transform.position.x, theHero.transform.position.y, transform.position.z);// z position can be retained
            //Debug.Log("Moving camera!");
        }
    }
}
