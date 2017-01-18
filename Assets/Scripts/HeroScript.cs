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

    private enum ANIMATION_PLAYED   // This is to keep track of what animation being played. Is hardcoded but unfortunately I don't have time to explore animation
    {
        NONE,   // whatAnimationPlayed probably won't encounter this. This is for bug tracking
        UP,
        DOWN,
        LEFT,
        RIGHT,
        TOTAL_ANIMATIONS,
    };
    private ANIMATION_PLAYED whatAnimationPlayed = ANIMATION_PLAYED.NONE;

	// Use this for initialization
	void Start () {
        // Getting the components from the hero
        HeroAnimation = GetComponent<Animator>();
        HeroRB = GetComponent<Rigidbody2D>();
        HeroAnimation.Play("HeroDown"); // We will default the animation to play hero down!
        whatAnimationPlayed = ANIMATION_PLAYED.DOWN;
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

    // Return true when current animation does not match up to what it is going to play.
    private bool playAnimation(ANIMATION_PLAYED zeAnimate)
    {
        if (whatAnimationPlayed != zeAnimate)
        {
            switch (zeAnimate)
            {
                case ANIMATION_PLAYED.UP:
                    HeroAnimation.Play("HeroUp");
                    break;
                case ANIMATION_PLAYED.DOWN:
                    HeroAnimation.Play("HeroDown");
                    break;
                case ANIMATION_PLAYED.RIGHT:
                    HeroAnimation.Play("HeroRight");
                    break;
                case ANIMATION_PLAYED.LEFT:
                    HeroAnimation.Play("HeroLeft");
                    break;
                default:
                    break;
            }
            whatAnimationPlayed = zeAnimate;
            return true;
        }
        return false;
    }

    public void moveUp()
    {
        // "new" can be very expensive thus using to check if the player is moving in the right direction or no
        if (!Mathf.Approximately(HeroRB.velocity.y, movementSpeed))
        {
            HeroRB.velocity = new Vector2(0, movementSpeed);
            playAnimation(ANIMATION_PLAYED.UP);
        }
    }
    public void moveDown()
    {
        if (!Mathf.Approximately(HeroRB.velocity.y, -movementSpeed))
        {
            HeroRB.velocity = new Vector2(0, -movementSpeed);
            playAnimation(ANIMATION_PLAYED.DOWN);
        }
    }
    public void moveRight()
    {
        if (!Mathf.Approximately(HeroRB.velocity.x, movementSpeed))
        {
            HeroRB.velocity = new Vector2(movementSpeed, 0);
            playAnimation(ANIMATION_PLAYED.RIGHT);
        }
    }
    public void moveLeft()
    {
        if (!Mathf.Approximately(HeroRB.velocity.x, -movementSpeed))
        {
            HeroRB.velocity = new Vector2(-movementSpeed, 0);
            playAnimation(ANIMATION_PLAYED.LEFT);
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
    public void moveUpRight()
    {
        // Using half of the velocity as estimation or else the hero will move diagonally twice the speed!
        if (!Mathf.Approximately(HeroRB.velocity.x, movementSpeed*0.5f) && !Mathf.Approximately(HeroRB.velocity.y, movementSpeed*0.5f))
        {
            HeroRB.velocity = new Vector2(movementSpeed * 0.5f, movementSpeed * 0.5f);
            if (whatAnimationPlayed == ANIMATION_PLAYED.DOWN)   // The following if else statements will make it so that it will move according to where is it moving
                playAnimation(ANIMATION_PLAYED.UP);
            else if (whatAnimationPlayed == ANIMATION_PLAYED.LEFT)
                playAnimation(ANIMATION_PLAYED.RIGHT);
        }
    }
    public void moveUpLeft()
    {
        // Using half of the velocity as estimation or else the hero will move diagonally twice the speed!
        if (!Mathf.Approximately(HeroRB.velocity.x, -movementSpeed * 0.5f) && !Mathf.Approximately(HeroRB.velocity.y, movementSpeed * 0.5f))
        {
            HeroRB.velocity = new Vector2(-movementSpeed * 0.5f, movementSpeed * 0.5f);
            if (whatAnimationPlayed == ANIMATION_PLAYED.DOWN)   // The following if else statements will make it so that it will move according to where is it moving
                playAnimation(ANIMATION_PLAYED.UP);
            else if (whatAnimationPlayed == ANIMATION_PLAYED.RIGHT)
                playAnimation(ANIMATION_PLAYED.LEFT);
        }
    }
    public void moveDownRight()
    {
        // Using half of the velocity as estimation or else the hero will move diagonally twice the speed!
        if (!Mathf.Approximately(HeroRB.velocity.x, movementSpeed * 0.5f) && !Mathf.Approximately(HeroRB.velocity.y, -movementSpeed * 0.5f))
        {
            HeroRB.velocity = new Vector2(movementSpeed * 0.5f, -movementSpeed * 0.5f);
            if (whatAnimationPlayed == ANIMATION_PLAYED.UP)   // The following if else statements will make it so that it will move according to where is it moving
                playAnimation(ANIMATION_PLAYED.DOWN);
            else if (whatAnimationPlayed == ANIMATION_PLAYED.LEFT)
                playAnimation(ANIMATION_PLAYED.RIGHT);
        }
    }
    public void moveDownLeft()
    {
        // Using half of the velocity as estimation or else the hero will move diagonally twice the speed!
        if (!Mathf.Approximately(HeroRB.velocity.x, -movementSpeed * 0.5f) && !Mathf.Approximately(HeroRB.velocity.y, -movementSpeed * 0.5f))
        {
            HeroRB.velocity = new Vector2(-movementSpeed * 0.5f, -movementSpeed * 0.5f);
            if (whatAnimationPlayed == ANIMATION_PLAYED.UP)   // The following if else statements will make it so that it will move according to where is it moving
                playAnimation(ANIMATION_PLAYED.DOWN);
            else if (whatAnimationPlayed == ANIMATION_PLAYED.RIGHT)
                playAnimation(ANIMATION_PLAYED.LEFT);
        }
    }
}
