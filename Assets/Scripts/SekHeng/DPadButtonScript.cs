using UnityEngine;
using System.Collections;

public class DPadButtonScript : MonoBehaviour {
    [Tooltip("Don't touch this unless you have seen the specific movement function in DPadBehaviour")]
    public string theButtonScript = "moveLeft";
    private DPadBehaviour parentDPAD;
	// Use this for initialization
	void Start () {
        parentDPAD = GetComponentInParent<DPadBehaviour>();
	}
	
    void MovePlayer()   // when the player pressed the button, DPadBehaviour will activate the specific button's function which will be this. Based on the string, the player will then be move accordingly in DPadBehaviour
    {
        // Sending a message instead so that I won't have to code out a function based on string Event!
        parentDPAD.SendMessage(theButtonScript);
    }
}
