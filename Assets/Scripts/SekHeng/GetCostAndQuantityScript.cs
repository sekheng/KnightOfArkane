using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// To set the UI cost for it!
/// </summary>
public class GetCostAndQuantityScript : MonoBehaviour {

    private int theCostPerProduct = 0;
    //private int Max_Products = 0;
    private int m_count = 0;
    private Text ownText;   // To change the text!
    private itemInformation itemStuff;

    void setItemInformation(itemInformation zeItemInform)
    {
        itemStuff = zeItemInform;
    }

    void doTransaction()
    {
        itemStuff.item_count -= m_count;    // minus the amount!
    }

    public int GetCostPerProduct()
    {
        return theCostPerProduct;
    }
    public int GetCount()
    {
        return m_count;
    }

    void Start()
    {
        ownText = GetComponentInChildren<Text>();
    }
    	
    void SetCost(int zeCost)    // cost per product
    {
        //Debug.Log("Receiving Cost:" + zeCost);
        theCostPerProduct = zeCost;
    }
    //void setMaxProducts(int zeAmount)   // Amount of items to buy
    //{
    //    //Debug.Log("Receiving Amount:" + zeAmount);
    //    Max_Products = zeAmount;
    //}

    void Increment()    // Increment the amount of items which the player want to buy!
    {
        m_count = Mathf.Min(m_count + 1, itemStuff.item_count);
        UpdateDisplay();
    }
    void Decrement()    // Decrement the amount of items which the player want to buy!
    {
        m_count = Mathf.Max(m_count - 1, 0);
        UpdateDisplay();
    }
    void UpdateDisplay()    // Change the text!
    {
        ownText.text = m_count + "\n" + (m_count * theCostPerProduct) + " gold";
    }
}
