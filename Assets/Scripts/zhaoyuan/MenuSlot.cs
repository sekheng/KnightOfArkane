using UnityEngine;
using System.Collections;

public class MenuSlot : MonoBehaviour {
    public int slotNumber;
    private GameObject[] menuoptions;
    private GameObject selectedOption;
    //private GameObject selectedOption;

    // Use this for initialization
    void Start () {
        menuoptions = GameObject.FindGameObjectsWithTag("MenuButtons");
        selectedOption = GameObject.FindGameObjectWithTag("OptionsManager");
        foreach (GameObject go in menuoptions)
        {
            if (slotNumber == go.GetComponent<ButtonMovenment>().getButtonNumber())
            {
                go.GetComponent<RectTransform>().SetParent(transform);
                go.transform.localPosition = Vector3.zero;
                if (slotNumber == 2)
                {
                    //selectedOption = GameObject.FindGameObjectWithTag("OptionsManager");
                    selectedOption.BroadcastMessage("showCorrectUI", go);
                    
                }
            }
        }
        

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void updatePosition(GameObject button)
    {
        //Debug.Log(button.GetComponent<ButtonMovenment>().getButtonNumber());
        if(slotNumber == button.GetComponent<ButtonMovenment>().getButtonNumber())
        {
            button.GetComponent<RectTransform>().SetParent(transform);
            button.transform.localPosition = Vector3.zero;
        }

        if(slotNumber == 2 && slotNumber == button.GetComponent<ButtonMovenment>().getButtonNumber())
        {
            //selectedOption = GameObject.FindGameObjectWithTag("OptionsManager");
            selectedOption.BroadcastMessage("showCorrectUI", button);
            //Debug.Log(button);
        }
        
    }

    public GameObject getSelectedOptions()
    {
        return selectedOption;
    }
}
