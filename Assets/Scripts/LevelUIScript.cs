﻿using UnityEngine;
using System.Collections;

public class LevelUIScript : MonoBehaviour {
    [Tooltip("Set the level of the character!")]
    public int m_Level = 20;

    //[Tooltip("Set the Width and Height of the Level UI. The Position doesn't matter since it will be attach on top of the character")]
    //public Rect PosOfText = new Rect(0, 0, 50, 50);

    //private Texture2D m_Background, m_TextColor;

    [Tooltip("The Level UI to display")]
    public GameObject theLevelUI;

    void Start()
    {
        //m_Background = new Texture2D(1, 1);
        //m_TextColor = new Texture2D(1, 1);
        //Color32[] allTheColor = new Color32[1];
        //allTheColor[0] = new Color32(244, 160, 4, 255);
        //m_TextColor.SetPixels32(allTheColor);   // Setting the text color

        //allTheColor[0] = new Color32(0, 1, 143, 255);
        //m_Background.SetPixels32(allTheColor);  // Setting the background color

        GameObject zeCreatedLevelUI = Instantiate(theLevelUI);  //  Creating the Level UI
        zeCreatedLevelUI.transform.parent = transform;      // Making the UI's transform parent to be this
        TextMesh zeUIText = zeCreatedLevelUI.GetComponent<TextMesh>();
        zeUIText.text = "LVL:" + m_Level;
        float offsetOfWord = zeUIText.text.Length * zeUIText.fontSize * 0.5f; // In order to make the words look centered to the character
        Debug.Log("the word offset:" + offsetOfWord);
        zeCreatedLevelUI.transform.position = new Vector3(transform.position.x - offsetOfWord, transform.position.y + (transform.localScale.y * 0.5f), transform.position.z); // Making the UI to display above the character
    }
	
    //void OnGUI()
    //{
    //    PosOfText.x = transform.position.x;
    //    PosOfText.y = transform.position.y + transform.localScale.y;
    //    GUI.DrawTexture(PosOfText, m_Background);   // Trying to render out the background first!
    //}
}
