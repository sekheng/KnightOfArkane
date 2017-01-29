using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class slotstuff : MonoBehaviour, IDropHandler {
    public string slot_type;
    public int slot_number;
    public GameObject item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!item && (slot_type == "Inventory" || slot_type == DragHandler.itemBeingDragged.GetComponent<itemInformation>().item_type))//only accept the item if the slot isnt holding to any
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
            DragHandler.itemBeingDragged.transform.localPosition = Vector3.zero;
        }
        else if(item && (slot_type == "Inventory" || slot_type == DragHandler.itemBeingDragged.GetComponent<itemInformation>().item_type)
            && item.GetComponent<itemInformation>().item_name == DragHandler.itemBeingDragged.GetComponent<itemInformation>().item_name)
        {

        }
    }
}
