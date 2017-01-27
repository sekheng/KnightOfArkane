using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceUIScript : MonoBehaviour {
    private HeroResourcesScript HeroResource;
    private Text theTextToChange;
    // Use this for initialization
	void Start () {
        HeroResource = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroResourcesScript>();
        theTextToChange = GetComponent<Text>();
        ChangeResourceValue();
    }
	
    void OnEnable()     // Registering to the MessageSystem
    {
        MessageSystem.instance.setListener("ModifyResource", ChangeResourceValue);
    }

    void OnDisable()    // Registering to the MessageSystem
    {
        MessageSystem.instance.removeListener("ModifyResource", ChangeResourceValue);
    }

    void ChangeResourceValue()
    {
        theTextToChange.text = HeroResource.rareResources.ToString();
    }
}
