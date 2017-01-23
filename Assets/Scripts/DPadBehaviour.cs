using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;

/// <summary>
///  This script is to ensure that nothing abnormal will happen to the player
/// </summary>

public class DPadBehaviour : MonoBehaviour {
    private const float offsetOfButtonSize = 0.5f;
    private HeroScript ToControlThePlayer;  // Getting the component which controls the player
    //private List<Image> allOfItsChild;
    private bool playerHasPressedTheButton = false;

	// Use this for initialization
	void Start () {
        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");  // Getting the plaer first
        ToControlThePlayer = thePlayer.GetComponent<HeroScript>();
    }

    void Update()   // Need to check whether is there any fingers touching any of the buttons by checking it's children!
    {
        playerHasPressedTheButton = false;
        if (Input.touchCount > 0)   // Check is there any touches, if so check whether any of them are touching the movement!
        {
            Touch[] getArrayOfTouches = Input.touches;
            RectTransform[] AllOfChildrenTransform = GetComponentsInChildren<RectTransform>();
            foreach (Touch zeFingerTouch in getArrayOfTouches)  // We will check through every single fingers and see if any of them has touched the D-pad or not!
            {
                foreach (RectTransform eachMoveButton in AllOfChildrenTransform)
                {
                    // First part will be checking whether the finger's X position is inside the X-boundary of the buttons
                    // Second part is checking whether the finger's Y position is inside the Y-boundary of the buttons
                    if (zeFingerTouch.position.x < eachMoveButton.position.x + (eachMoveButton.rect.width * offsetOfButtonSize) && zeFingerTouch.position.x > eachMoveButton.position.x - (eachMoveButton.rect.width * offsetOfButtonSize)
                        && zeFingerTouch.position.y < eachMoveButton.position.y + (eachMoveButton.rect.height * offsetOfButtonSize) && zeFingerTouch.position.y > eachMoveButton.position.y - (eachMoveButton.rect.height * offsetOfButtonSize))    // Check whether any of the touches are within the button
                    {
                        playerHasPressedTheButton = true;
                        eachMoveButton.gameObject.BroadcastMessage("MovePlayer");
                        break;
                    }
                }
                if (playerHasPressedTheButton)  // If either of the finger touches the D-Pad. just break the loop!
                    break;
            }
        }

        // TODO: This is for mouse Input only!
        //RectTransform[] zeChildren = GetComponentsInChildren<RectTransform>();
        //foreach (RectTransform eachMoveButton in zeChildren)
        //{
        //    // First part will be checking whether the finger's X position is inside the X-boundary of the buttons
        //    // Second part is checking whether the finger's Y position is inside the Y-boundary of the buttons
        //    if (Input.mousePosition.x < eachMoveButton.position.x + (eachMoveButton.rect.width * 0.25f) && Input.mousePosition.x > eachMoveButton.position.x - (eachMoveButton.rect.width * 0.25f)
        //        && Input.mousePosition.y < eachMoveButton.position.y + (eachMoveButton.rect.height * 0.25f) && Input.mousePosition.y > eachMoveButton.position.y - (eachMoveButton.rect.height * 0.25f))    // Check whether any of the touches are within the button
        //    {
        //        playerHasPressedTheButton = true;
        //        eachMoveButton.gameObject.BroadcastMessage("MovePlayer");
        //        break;
        //    }
        //}
        // TODO: This is for mouse Input only!
    }

    // This is used because need to check whether the player has pressed any button during update. If not, stop moving the character
	void LateUpdate () {
        if (!playerHasPressedTheButton)
            ToControlThePlayer.stopMoving();
	}

    public void LetGoOfButton()
    {
        playerHasPressedTheButton = false;
    }

    public void moveUp()
    {
        ToControlThePlayer.moveUp();
        playerHasPressedTheButton = true;
    }
    public void moveDown()
    {
        ToControlThePlayer.moveDown();
        playerHasPressedTheButton = true;
    }
    public void moveRight()
    {
        ToControlThePlayer.moveRight();
        playerHasPressedTheButton = true;
    }
    public void moveLeft()
    {
        ToControlThePlayer.moveLeft();
        playerHasPressedTheButton = true;
    }
    public void moveUpRight()
    {
        ToControlThePlayer.moveUpRight();
        playerHasPressedTheButton = true;
    }
    public void moveUpLeft()
    {
        ToControlThePlayer.moveUpLeft();
        playerHasPressedTheButton = true;
    }
    public void moveDownRight()
    {
        ToControlThePlayer.moveDownRight();
        playerHasPressedTheButton = true;
    }
    public void moveDownLeft()
    {
        ToControlThePlayer.moveDownLeft();
        playerHasPressedTheButton = true;
    }
}
