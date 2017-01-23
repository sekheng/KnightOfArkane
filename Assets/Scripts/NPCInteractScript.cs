using UnityEngine;
using System.Collections;

public class NPCInteractScript : MonoBehaviour {
    // This is to check for whether the player is within it's interaction/trigger zone!
    private bool canInteractWithPlayer = false;

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
            GameStateScript.ChangeState(GameStateScript.GAMESTATE.CHATTING);
    }
}
