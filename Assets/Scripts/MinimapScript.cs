using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// How minimap should respond when pressed!
/// </summary>
public class MinimapScript : MonoBehaviour {
    // we need to get the minimap transform stuff from the UI!
    private static float OriginalPosX, OriginalPosY, OriginalWidth, OriginalHeigh;   // We need this so that we can go back in size!
    private RectTransform positionOfMinimap;
    private bool toggleMinimapSize; // for toggling between the expanded minimap and normal minimap.
	// Use this for initialization
	void Start () {
        positionOfMinimap = GetComponent<RectTransform>();
        // We will have to do it the hardcoding way because it is faster
        OriginalPosX = positionOfMinimap.rect.position.x;
        OriginalPosY = positionOfMinimap.rect.position.y;
        OriginalWidth = positionOfMinimap.rect.width;
        OriginalHeigh = positionOfMinimap.rect.height;
        toggleMinimapSize = false;
	}
	
    public void MinimapResponse()
    {
        toggleMinimapSize = !toggleMinimapSize;
        if (toggleMinimapSize)  // this is meant to be expanded!
        {

        }
        else
        {
            // If User wants it to return to it's normal size!
        }
    }
}
