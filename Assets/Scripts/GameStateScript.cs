using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour {
    public enum GAMESTATE
    {
        PLAYING,
        CHATTING,
        LOSE,
        WIN,
        TOTAL_STATE,
    };

    static private GAMESTATE currentGameState = GAMESTATE.PLAYING;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    // TODO: This is just keyboard input so that i can change UI elements at will only!
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeState(GAMESTATE.PLAYING);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeState(GAMESTATE.CHATTING);
        // TODO: This is just keyboard input so that i can change UI elements at will only!
    }

    static public void ChangeState(GAMESTATE zeState)   // Changing the state then turning on the UI elements in that state
    {
        GameObject[] allUIElement = null;
        switch (zeState)
        {
            case GAMESTATE.PLAYING:
                allUIElement = GameObject.FindGameObjectsWithTag("GameplayUI");
                turnOffUI_ElementInThatState(currentGameState);
                currentGameState = zeState;
             break;
            case GAMESTATE.CHATTING:
                allUIElement = GameObject.FindGameObjectsWithTag("ChattingUI");
                turnOffUI_ElementInThatState(currentGameState);
                currentGameState = zeState;
                break;
            default:
                break;
        }
        if (allUIElement != null)
            foreach (GameObject zeUI in allUIElement)   // Turning the UI Element on
                zeUI.SetActive(true);
  }
    static private void turnOffUI_ElementInThatState(GAMESTATE zeState) // Turning off the UI elements in that state
    {
        GameObject[] allUIElement = null;
        switch (zeState)
        {
            case GAMESTATE.PLAYING:
                allUIElement = GameObject.FindGameObjectsWithTag("GameplayUI");
                break;
            case GAMESTATE.CHATTING:
                allUIElement = GameObject.FindGameObjectsWithTag("ChattingUI");
                break;
            default:
                break;
        }
        if (allUIElement != null)   // Need to check if the array is not null. then turn off the UI elements in that array
            foreach (GameObject zeUI in allUIElement)   // Looping through the UI Element and set them to inactive
            {
                zeUI.SetActive(false);
            }
    }
}
