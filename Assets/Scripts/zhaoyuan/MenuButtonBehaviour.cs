using UnityEngine;
using System.Collections;

public class MenuButtonBehaviour : MonoBehaviour {
    private GameObject[] menuoptions;
    private ButtonMovenment btn_move;
    public StatChanger sceneIsChanged;
    //public string scrollDir;
	// Use this for initialization
	void Start () {
        menuoptions = GameObject.FindGameObjectsWithTag("MenuButtons");
        //Debug.Log(menuoptions.Length);
	}
	

    public void pressUp()
    {//logic is this->buttonmovenment->menuslot
        foreach(GameObject go in menuoptions)
        {
            go.BroadcastMessage("moveUP");
        }
        if(sceneIsChanged != null)
        {
            sceneIsChanged.resetStatPointUses();
        }
    }

    public void pressDown()
    {
        foreach (GameObject go in menuoptions)
        {
            go.BroadcastMessage("moveDown");
        }
        if (sceneIsChanged != null)
        {
            sceneIsChanged.resetStatPointUses();
        }
    }

   
}
