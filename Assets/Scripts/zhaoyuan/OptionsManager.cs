using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {
    private GameObject[] menuoptions;
    private GameObject ui;
    private GameObject[] differentOptionsUIName;
    private RectTransform btn_rt;
    private string selectedOption;
    private bool changeUI;
    // Use this for initialization
    void Start () {
        menuoptions = GameObject.FindGameObjectsWithTag("MenuButtons");
        ui = GameObject.FindGameObjectWithTag("GameplayUI");
        //differentOptionsUIName = ui.transform.;
        changeUI = false;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(changeUI)
        {
            
        }
	}

    void showCorrectUI(GameObject go)
    {
        string nameOftheOption = go.transform.name;
        
        if(nameOftheOption == "menu_inventory")
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


        changeUI = true;
    }
}
