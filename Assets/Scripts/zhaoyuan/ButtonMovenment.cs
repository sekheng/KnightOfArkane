using UnityEngine;
using System.Collections;

public class ButtonMovenment : MonoBehaviour {
    public int buttonNumber;
    public string buttonName;
    private GameObject[] slots;
    private GameObject[] choices;
    // Use this for initialization
    void Start () {
        slots = GameObject.FindGameObjectsWithTag("MenuSlot");
        choices = GameObject.FindGameObjectsWithTag("MenuButtons");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void moveUP()
    {
        buttonNumber += 1;
        if(buttonNumber > 3)
        {
            buttonNumber -= choices.Length;
        }
        if(buttonNumber < 1 || buttonNumber > 3)
        {
            GetComponent<RectTransform>().SetParent(null);
            transform.localPosition.Set(0,1000,0);
            return;
        }
        foreach (GameObject temp in slots)
        {
            temp.BroadcastMessage("updatePosition", gameObject);
        }
        //Debug.Log(buttonNumber);
        //Debug.Log(transform.parent);
        //Vector2 temp = btn_rt.rect.position;
        //float coordY = temp.y + 216.5f;
        //btn_rt.transform.position += new Vector3(0,coordY,0);
        //Debug.Log(coordY);
        //temp.y += 216.5;
    }

    public void moveDown()
    {
        buttonNumber -= 1;
        if (buttonNumber < 1)
        {
            buttonNumber += choices.Length;
        }
        if (buttonNumber < 1 || buttonNumber > 3)
        {
            GetComponent<RectTransform>().SetParent(null);
            transform.localPosition.Set(0, 1000, 0);
            return;
        }
        foreach (GameObject temp in slots)
        {
            temp.BroadcastMessage("updatePosition",gameObject);
        }
        //Vector2 temp = btn_rt.rect.position;
        //float coordY = temp.y - 216.5f;
        //btn_rt.transform.position -= new Vector3(0, coordY, 0);
    }
    public int getButtonNumber()
    {
        return buttonNumber;
    }
}
