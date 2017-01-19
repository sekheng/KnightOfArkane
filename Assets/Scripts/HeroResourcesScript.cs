using UnityEngine;
using System.Collections;

public class HeroResourcesScript : MonoBehaviour {
    [Tooltip("Adjust the values of how much coins player has")]
    public int coinResources = 1000;
    [Tooltip("Adjust the values of how much rare resource player has")]
    public int rareResources = 10;

    void modifyCoins(int zeValue)
    {
        coinResources += zeValue;
        MessageSystem.instance.triggerEventCall("ModifyCoin");
    }
    void modifyResource(int zeValue)
    {
        rareResources += zeValue;
        MessageSystem.instance.triggerEventCall("ModifyResource");
    }
}
