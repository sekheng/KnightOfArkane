using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// this is just a bypass to display the item image on the UI Image box!
/// Do not forget to use event trigger for this!
/// </summary>
[RequireComponent(typeof(Image))]
public class DisplayImageScript : MonoBehaviour {
    [Tooltip("The Image box to display the item's image!")]
    public Image theUIImageBox;

    private Sprite theOwnImage; // Need to get the Image of the item

	// Use this for initialization
	void Start () {
	    Image zeOwnImage = GetComponent<Image>();   // Need to know what image the item has!
        theOwnImage = zeOwnImage.sprite;
	}
    
	public void updateStatDisplay()
    {
        theUIImageBox.color = new Color(1,1,1,1);   // Need to make sure all of it's color is the same!
        theUIImageBox.sprite = theOwnImage; // Change the image!
    }
}
