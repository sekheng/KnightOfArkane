﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NPCInteractScript : MonoBehaviour {
    // This is to check for whether the player is within it's interaction/trigger zone!
    private bool canInteractWithPlayer = false;

    [Tooltip("This is what the player will see in the description box!")]
    public string Description = "Welcome to my shop!";

    void OnEnable()     // Registering to the MessageSystem
    {
        if (MessageSystem.instance != null)
            MessageSystem.instance.setListener("PressedA", InteractWithNPC);
    }

    void OnDisable()    // remove itself from the MessageSystem
    {
        if (MessageSystem.instance != null)
            MessageSystem.instance.removeListener("PressedA", InteractWithNPC);
    }
	
    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))  // Check whether is it the player
        {
            canInteractWithPlayer = true;
            //Debug.Log("Player can Interact");
        }
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))  // Check whether is it the player
        {
            // Player leaves it's interaction zone, then can't interact anymore!
            canInteractWithPlayer = false;
            //Debug.Log("Player cannot Interact");
        }
    }

    void InteractWithNPC()
    {
        //Debug.Log("Pressed A");
        if (canInteractWithPlayer)
        {
            //Debug.Log("Interacting With Player");
            // Not only do we have to change the state, we have to change the chat text box!
            GameStateScript.ChangeState(GameStateScript.GAMESTATE.CHATTING);
            GameObject[] AllChatUI = GameObject.FindGameObjectsWithTag("ChattingUI");
            Text theSupposeChangedText = null;
            foreach (GameObject zeChatUI in AllChatUI)  // We will slowly iterate through the UI Chat Box and put in the stuff we see fit!
            {
                // Unfortunately, hardcoding will be the fastest way for now
                if (zeChatUI.name.Equals("Description Text"))   // Change the text for Description box
                {
                    theSupposeChangedText = zeChatUI.GetComponent<Text>();
                    theSupposeChangedText.text = Description;
                }
                else if (zeChatUI.name.Equals("NPC Name"))  // We change the NPC Name box
                {
                    theSupposeChangedText = zeChatUI.GetComponent<Text>();
                    theSupposeChangedText.text = gameObject.name;
                }
                else if (zeChatUI.name.Equals("NPC Image")) // Insert an image for the display of NPC Image!
                {
                    SpriteRenderer zeOwnSprite = GetComponent<SpriteRenderer>();
                    Image zeNPCImage = zeChatUI.GetComponent<Image>();
                    zeNPCImage.sprite = zeOwnSprite.sprite; // Change the sprite!
                }
            }
        }
    }
}
