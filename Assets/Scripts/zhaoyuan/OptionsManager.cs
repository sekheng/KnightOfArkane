using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {
    private GameObject ui;
    private RectTransform[] differentOptionsUIName;
    private RectTransform btn_rt;
    private string selectedOption;
    public string[] uiNames;
    // Use this for initialization
    void Start () {
        ui = GameObject.FindGameObjectWithTag("GameplayUI");
        differentOptionsUIName = ui.GetComponentsInChildren<RectTransform>(true);        
    }
	
	// Update is called once per frame
	void Update () {
	}

    void changeUIBasedOnSelectedSlot()
    {
        foreach (RectTransform rt in differentOptionsUIName)
        {
            bool toSetActive = false;
            foreach(string temp in uiNames)
            {
                if(rt.gameObject.transform.name == temp)
                {
                    toSetActive = true;
                }
            }
            if (toSetActive)
            {

                Debug.Log(rt.gameObject.transform.name);
                if (rt.gameObject.transform.name == selectedOption || rt.gameObject.transform.name == "UI")
                {
                    rt.gameObject.SetActive(true);
                } 
                else
                {
                    rt.gameObject.SetActive(false);
                }
            }
            
        }
    }

    void showCorrectUI(GameObject go)
    {
        string nameOftheOption = go.transform.name;
        
        if (nameOftheOption == "menu_inventory")
        {
            selectedOption = "Inventory";
           
        }
        else if (nameOftheOption == "menu_options")
        {
            selectedOption = "Options";
            
        }
        else if (nameOftheOption == "menu_items")
        {
            selectedOption = "Items";
         
        }
        else if (nameOftheOption == "menu_stats")
        {
            selectedOption = "Stats";
            
        }
        

        changeUIBasedOnSelectedSlot();
        
    }
}
