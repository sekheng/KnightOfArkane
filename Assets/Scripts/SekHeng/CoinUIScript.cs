using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinUIScript : MonoBehaviour {
    private HeroResourcesScript HeroCoins;
    private Text theTextToChange;
	// Use this for initialization
	void Start () {
        HeroCoins = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroResourcesScript>();
        theTextToChange = GetComponent<Text>();
        ChangeCoinValue();
	}
	
    void OnEnable()     // Registering to the MessageSystem
    {
        MessageSystem.instance.setListener("ModifyCoin", ChangeCoinValue);
    }

    void OnDisable()    // remove itself from the MessageSystem
    {
        MessageSystem.instance.removeListener("ModifyCoin", ChangeCoinValue);
    }

    void ChangeCoinValue()
    {
        theTextToChange.text = HeroCoins.coinResources.ToString();
    }
}
