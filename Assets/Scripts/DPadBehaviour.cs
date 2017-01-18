using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;

/// <summary>
///  This script is to ensure that nothing abnormal will happen to the player
/// </summary>
public class DPadBehaviour : MonoBehaviour {
    private HeroScript ToControlThePlayer;  // Getting the component which controls the player
    //private List<Image> allOfItsChild;
    private bool playerHasPressedTheButton = false;

	// Use this for initialization
	void Start () {
        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");  // Getting the plaer first
        ToControlThePlayer = thePlayer.GetComponent<HeroScript>();
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
