using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameStateScript : MonoBehaviour {
    public enum GAMESTATE
    {
        PLAYING = 0,
        CHATTING,
        LOSE,
        WIN,
        SHOPPING,
        TOTAL_STATE,
    };

    static private GAMESTATE currentGameState = GAMESTATE.PLAYING;
    static private Dictionary<GAMESTATE, GameObject[]> StateAndUI_Dictionary;

    [Tooltip("Setting the number of presses to load the scene!")]
    public int m_ButtonPressesTimes = 4;
    private int m_CountPress = 0;   // To Count the number of presses
    private float timeCounter = 0;  // To count the timer then resets the count press!
    [Tooltip("Which scene to load!")]
    public string SceneName = "WinScene";

    void Start()
    {
        StateAndUI_Dictionary = new Dictionary<GAMESTATE, GameObject[]>();
        GameObject[] PlayingUI = GameObject.FindGameObjectsWithTag("GameplayUI");
        StateAndUI_Dictionary.Add(GAMESTATE.PLAYING, PlayingUI);
        GameObject[] ChatingUI = GameObject.FindGameObjectsWithTag("ChattingUI");
        StateAndUI_Dictionary.Add(GAMESTATE.CHATTING, ChatingUI);
        foreach (GameObject zeUI in ChatingUI)
            zeUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    // TODO: This is just keyboard input so that i can change UI elements at will only!
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeState(GAMESTATE.PLAYING);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeState(GAMESTATE.CHATTING);
        // TODO: This is just keyboard input so that i can change UI elements at will only!

        if (Input.GetKeyUp(KeyCode.Escape) && Application.platform == RuntimePlatform.Android)  // Check whether the player has pressed the back button and is it on android phone!
        {
            SceneManager.LoadScene("ZhaoyuanScene");    // Go to pause menu which is ZY's Scene!
        }

        if (m_CountPress > 0)   // Checks whether there has been any button pressed
        {
            timeCounter += Time.deltaTime;
            if (timeCounter > 0.5f) // If the user pressed too slowly, reset everything!!!
            {
                m_CountPress = 0;
                timeCounter = 0;    
            }
        }
    }

    void OnEnable() // Subscribe to the Message System
    {
        if (MessageSystem.instance)
            MessageSystem.instance.setListener("PressedB", PressedB);
    }
    void OnDisable()    // Unsubscribe from the Message System
    {
        if (MessageSystem.instance)
            MessageSystem.instance.removeListener("PressedB", PressedB);
    }

    static public void ChangeState(GAMESTATE zeState)   // Changing the state then turning on the UI elements in that state
    {
        GameObject[] allUIElement = null;
        if (zeState != currentGameState && StateAndUI_Dictionary.TryGetValue(zeState, out allUIElement))   // If can find the states and current state isn't the changed state, then do it!
        {
            turnOffUI_ElementInThatState(currentGameState); // Turn off the UI Element of current game state
            currentGameState = zeState; // Switch current game state
            foreach (GameObject zeUI in allUIElement)   // Turning the UI Element on
                zeUI.SetActive(true);
        }
  }

    static private void turnOffUI_ElementInThatState(GAMESTATE zeState) // Turning off the UI elements in that state
    {
        GameObject[] allUIElement = null;
        if (StateAndUI_Dictionary.TryGetValue(zeState, out allUIElement))   // If can find the state, then turn the UIs!
        {
            foreach (GameObject zeUI in allUIElement)   // Looping through the UI Element and set them to inactive
            {
                zeUI.SetActive(false);
            }
        }
    }
    public void ChangeScriptState(int zeState)
    {
        ChangeState((GAMESTATE)zeState);
    }

    void PressedB()
    {
        ++m_CountPress;
        timeCounter = 0;
        if (m_CountPress >= m_ButtonPressesTimes)   // If reached the count press, load the scene!
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
