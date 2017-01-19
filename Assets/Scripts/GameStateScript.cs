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

    static public GAMESTATE currentGameState = GAMESTATE.PLAYING;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
