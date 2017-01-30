using UnityEngine;
using System.Collections;

/// <summary>
/// For the buy button only!
/// </summary>
public class ActivateDialogScript : MonoBehaviour {
    [Tooltip("Link it to the dialog box!")]
    public CustomDialog dialogBox;
    [Tooltip("Link it to the cost and calculation logic!")]
    public GetCostAndQuantityScript costCalculatioLogic;

    private HeroResourcesScript thePlayerResource;  // We will need to to see if the player has enough money to even buy

    void Start()
    {
        thePlayerResource = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroResourcesScript>();
    }

    void doTransaction()
    {
        thePlayerResource.SendMessage("modifyCoins", -(costCalculatioLogic.GetCostPerProduct() * costCalculatioLogic.GetCount()));
    }

    public void ActivateDialog()
    {
        if (costCalculatioLogic != null && dialogBox != null && costCalculatioLogic.GetCount() > 0)
        {
            if ((costCalculatioLogic.GetCostPerProduct() * costCalculatioLogic.GetCount()) <= thePlayerResource.coinResources)  // If the player's coins is within the budget. then activate the dialog!!
            {
                //Debug.Log("Player's coins:" + thePlayerResource.coinResources);
                //Debug.Log("Total Cost of product:" + (costCalculatioLogic.GetCostPerProduct() * costCalculatioLogic.GetCount()));
                dialogBox.startDialog();
            }
        }
    }
}
