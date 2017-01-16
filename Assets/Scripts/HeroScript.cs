using UnityEngine;
using System.Collections;

/// <summary>
/// This script is for the hero to use only
/// All of it's movement logic and movement animation is here
/// </summary>
public class HeroScript : MonoBehaviour {
    private Animator HeroAnimation;
    private Rigidbody2D HeroRB; // We will be using the velocity of the character instead!
    [Tooltip("This will be the consistent movement for up down left right!")]
    public float movementSpeed = 5.0f; 

	// Use this for initialization
	void Start () {
        // Getting the components from the hero
        HeroAnimation = GetComponent<Animator>();
        HeroRB = GetComponent<Rigidbody2D>();
        HeroAnimation.Play("HeroDown"); // We will default the animation to play hero down!
	}
	
    void Update()
    {
        // TODO: This is just keyboard inputs to test out how the Hero should be moving. The real implementation for tablet will be coming soon!
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    //HeroRB.velocity.Set(0, movementSpeed);
        //    HeroRB.velocity = new Vector2(0, movementSpeed);
        //    HeroAnimation.Play("HeroUp");
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    //HeroRB.velocity.Set(0, -movementSpeed);
        //    HeroRB.velocity = new Vector2(0, -movementSpeed);
        //    HeroAnimation.Play("HeroDown");
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    //HeroRB.velocity.Set(movementSpeed, 0);
        //    HeroRB.velocity = new Vector2(movementSpeed, 0);
        //    HeroAnimation.Play("HeroRight");
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    //HeroRB.velocity.Set(-movementSpeed, 0);
        //    HeroRB.velocity = new Vector2(-movementSpeed, 0);
        //    HeroAnimation.Play("HeroLeft");
        //}
        //else
        //    HeroRB.velocity = new Vector2(0, 0);
        // TODO: This is just keyboard inputs to test out how the Hero should be moving. The real implementation for tablet will be coming soon!
    }

    public void moveUp()
    {
        // "new" can be very expensive thus using to check if the player is moving in the right direction or no
        if (!Mathf.Approximately(HeroRB.velocity.y, movementSpeed))
        {
            HeroRB.velocity = new Vector2(0, movementSpeed);
            HeroAnimation.Play("HeroUp");
        }
    }
    public void moveDown()
    {
        if (!Mathf.Approximately(HeroRB.velocity.y, -movementSpeed))
        {
            HeroRB.velocity = new Vector2(0, -movementSpeed);
            HeroAnimation.Play("HeroDown");
        }
    }
    public void moveRight()
    {
        if (!Mathf.Approximately(HeroRB.velocity.x, movementSpeed))
        {
            HeroRB.velocity = new Vector2(movementSpeed, 0);
            HeroAnimation.Play("HeroRight");
        }
    }
    public void moveLeft()
    {
        if (!Mathf.Approximately(HeroRB.velocity.x, -movementSpeed))
        {
            HeroRB.velocity = new Vector2(-movementSpeed, 0);
            HeroAnimation.Play("HeroLeft");
        }
    }
    public void stopMoving()
    {
        // Using the magnitude of the velocity can help check whether is the character moving or not
        if (!Mathf.Approximately(HeroRB.velocity.sqrMagnitude, 0))    // This is for precision error check!
        {
            HeroRB.velocity = new Vector2(0, 0);
            //Debug.Log("Player has stopped moving");
        }
    }
}
