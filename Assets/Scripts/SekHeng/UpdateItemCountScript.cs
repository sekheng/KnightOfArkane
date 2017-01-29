using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// For now it will only update it's text according to the item counts!
/// </summary>
[RequireComponent(typeof(Text))]
public class UpdateItemCountScript : MonoBehaviour {
    private itemInformation theItemInform;
    private Text ownText;

	// Use this for initialization
	void Start () {
        ownText = GetComponent<Text>(); //Get the text
       // We shall get the grandparent! (the item)
        theItemInform = transform.parent.parent.gameObject.GetComponent<itemInformation>();
    }
	
	// I would use observer pattern here but I don't have time for it!
	void Update () {
        ownText.text = theItemInform.item_count.ToString();
	}
}
