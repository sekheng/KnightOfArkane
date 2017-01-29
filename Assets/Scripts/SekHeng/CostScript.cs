using UnityEngine;
using System.Collections;

/// <summary>
///  This is for item's cost!
///  This will also send it straight to the calculating logic
/// </summary>
public class CostScript : MonoBehaviour {
    [Tooltip("Set the item's cost!")]
    public int m_cost = 100;
    [Tooltip("To send the cost and value to this gameobject!")]
    public string m_objectName = "CountingCost";

    private itemInformation ownItemStuff;
    private GameObject calculateCostAndValue;   // To send it to the Buying UI!

    void Start()
    {
        ownItemStuff = GetComponent<itemInformation>();
        calculateCostAndValue = GameObject.Find(m_objectName);
    }

    public void sendCostAndAmount()
    {
        //Debug.Log("Sending Cost and Stuff");
        calculateCostAndValue.BroadcastMessage("SetCost", m_cost);
        calculateCostAndValue.BroadcastMessage("setMaxProducts", ownItemStuff.item_count);
        calculateCostAndValue.BroadcastMessage("UpdateDisplay");
    }
}
