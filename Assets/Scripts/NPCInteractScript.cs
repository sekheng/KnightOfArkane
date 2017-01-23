using UnityEngine;
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
        MessageSystem.instance.setListener("PressedA", InteractWithNPC);
    }

    void OnDisable()    // remove itself from the MessageSystem
    {
        MessageSystem.instance.removeListener("PressedA", InteractWithNPC);
    }
	
    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))  // Check whether is it the player
        {
            canInteractWithPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))  // Check whether is it the player
        {
            // Player leaves it's interaction zone, then can't interact anymore!
            canInteractWithPlayer = false;
        }
    }

    void InteractWithNPC()
    {
        if (canInteractWithPlayer)
        {
            // Not only do we have to change the state, we have to change the chat text box!
            GameStateScript.ChangeState(GameStateScript.GAMESTATE.CHATTING);
            GameObject[] AllChatUI = GameObject.FindGameObjectsWithTag("ChattingUI");
            Text theSupposeChangedText = null;
            foreach (GameObject zeChatUI in AllChatUI)  // We will slowly iterate through the UI Chat Box and put in the stuff we see fit!
            {
                // Unfortunately, hardcoding will be the fastest way for now
                if (zeChatUI.name.Equals("Description Text"))
                {
                    theSupposeChangedText = zeChatUI.GetComponent<Text>();
                    theSupposeChangedText.text = Description;
                }
                else if (zeChatUI.name.Equals("NPC Name"))
                {
                    theSupposeChangedText = zeChatUI.GetComponent<Text>();
                    theSupposeChangedText.text = gameObject.name;
                }
            }
        }
    }
}
