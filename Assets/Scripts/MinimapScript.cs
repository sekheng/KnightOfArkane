using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// How minimap should respond when pressed!
/// </summary>
public class MinimapScript : MonoBehaviour {
    // we need to get the minimap transform stuff from the UI!
    //private static float OriginalPosX, OriginalPosY, OriginalWidth, OriginalHeigh;   // We need this so that we can go back in size!
    private static Rect OriginalSizeRect = new Rect();// We need this so that we can go back in size!
    private RectTransform positionOfMinimap;
    private bool toggleMinimapSize; // for toggling between the expanded minimap and normal minimap.

    // TODO: will remove the debugging stuff soon!
    //private Text zeDebugText;

	// Use this for initialization
	void Start () {
        positionOfMinimap = GetComponent<RectTransform>();
        // We will have to do it the hardcoding way because it is faster
        OriginalSizeRect = new Rect(positionOfMinimap.rect);
        OriginalSizeRect.x = positionOfMinimap.position.x;
        OriginalSizeRect.y = positionOfMinimap.position.y;
        //Debug.Log("Original Rect Stuff:" + OriginalSizeRect.x + "," + OriginalSizeRect.y + "," + OriginalSizeRect.width + "," + OriginalSizeRect.height);
        toggleMinimapSize = false;
        //zeDebugText = GameObject.Find("REMOVING SOON").GetComponent<Text>();
	}
	
    public void MinimapResponse()
    {
        toggleMinimapSize = !toggleMinimapSize;
        if (toggleMinimapSize)  // this is meant to be expanded!
        {
            // Get the screen height and width since it is landscape.
            // We shall use Screen height to expand the Minimap!
            positionOfMinimap.sizeDelta = new Vector2(Screen.height, Screen.height);
            positionOfMinimap.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, positionOfMinimap.position.z);
            //Debug.Log("Expanding the map" + positionOfMinimap.rect.x + "," + positionOfMinimap.rect.y + "," + positionOfMinimap.rect.width + "," + positionOfMinimap.rect.height);
            //Debug.Log("Screen Height:" + Screen.height);
              // TODO: will remove the debugging stuff soon!
  //zeDebugText.text = positionOfMinimap.rect.x + "," + positionOfMinimap.rect.y + "," + positionOfMinimap.rect.width + "," + positionOfMinimap.rect.height;
        }
        else
        {
            // If User wants it to return to it's normal size!
            positionOfMinimap.position = new Vector3(OriginalSizeRect.xMin, OriginalSizeRect.yMin, positionOfMinimap.position.z);
            positionOfMinimap.sizeDelta = new Vector2(OriginalSizeRect.width, OriginalSizeRect.height);
               // TODO: will remove the debugging stuff soon!
         //zeDebugText.text = positionOfMinimap.rect.x + "," + positionOfMinimap.rect.y + "," + positionOfMinimap.rect.width + "," + positionOfMinimap.rect.height;
    //Debug.Log("Shrinking the map!" + positionOfMinimap.rect.x + "," + positionOfMinimap.rect.y + "," + positionOfMinimap.rect.width + "," + positionOfMinimap.rect.height);
        }
    }
}
