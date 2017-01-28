using UnityEngine;
using System.Collections;

public class MenuButtonBehaviour : MonoBehaviour {
    private GameObject[] menuoptions;
    private ButtonMovenment btn_move;
    //public string scrollDir;
	// Use this for initialization
	void Start () {
        menuoptions = GameObject.FindGameObjectsWithTag("MenuButtons");
        //Debug.Log(menuoptions.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void pressUp()
    {//logic is this->buttonmovenment->menuslot
        foreach(GameObject go in menuoptions)
        {
            go.BroadcastMessage("moveUP");
        }
    }

    public void pressDown()
    {
        foreach (GameObject go in menuoptions)
        {
            go.BroadcastMessage("moveDown");
        }
    }

    //void moveUP()
    //{

    //}

    //void moveDown()
    //{

    //}
}
