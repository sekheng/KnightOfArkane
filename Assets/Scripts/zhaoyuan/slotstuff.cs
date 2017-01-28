using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class slotstuff : MonoBehaviour, IDropHandler {
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
        if(!item)//only accept the item if the slot isnt holding to any
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
            DragHandler.itemBeingDragged.transform.localPosition = Vector3.zero;
            DragHandler.itemBeingDragged.transform.localScale = transform.localScale;
        }
    }
}
