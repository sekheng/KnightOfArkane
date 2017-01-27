using UnityEngine;
using System.Collections;

public class LevelUIScript : MonoBehaviour {
    [Tooltip("Set the level of the character!")]
    public int m_Level = 20;

    [Tooltip("The Level UI to display")]
    public GameObject theLevelUI;

    private SpriteRenderer characterSprite; // Because scale doesn't match up with Sprit'e width and height. This will be used for offset!

    void Start()
    {
        //characterSprite = GetComponent<SpriteRenderer>();
        //GameObject zeCreatedLevelUI = Instantiate(theLevelUI);  //  Creating the Level UI
        //TextMesh zeUIText = zeCreatedLevelUI.GetComponent<TextMesh>();
        //zeUIText.text = "LVL:" + m_Level;

        //float ToConvertToWorldY = Camera.main.orthographicSize * 2;
        //float ToConvertToWorldX = ToConvertToWorldY * Screen.width / Screen.height; // using ToConvertToWorldY * aspect ratio
        //Debug.Log("ToConvertToWorldY:" + ToConvertToWorldY);
        //Debug.Log("ToConvertToWorldX:" + ToConvertToWorldX);

        //float unitWidthOfSprite = characterSprite.sprite.textureRect.width / characterSprite.sprite.pixelsPerUnit;
        //float unitHeightOfSprite = characterSprite.sprite.textureRect.height / characterSprite.sprite.pixelsPerUnit;

        //Vector2 EstimatedScaleOfCharacterForSprite = new Vector2(characterSprite.sprite.textureRect.width / unitWidthOfSprite, characterSprite.sprite.textureRect.height / unitHeightOfSprite);
        //Debug.Log("Just the scale of sprite without it being scaled!:" + EstimatedScaleOfCharacterForSprite);

        ////float offsetOfWord = zeUIText.text.Length * zeUIText.fontSize * 0.5f; // In order to make the words look centered to the character
        //float OffSetForCharacterY = (transform.localScale.y * 0.5f) + (characterSprite.sprite.textureRect.height * 0.5f);   // This isn't accurate. So need to convert again.
        
        //Debug.Log("Offset for position from y:" + OffSetForCharacterY + ".Name:" + gameObject.name);
        //Debug.Log("Size Of Sprite:" + characterSprite.sprite.textureRect.size + ".Name:" + gameObject.name);
        //float totalPixel_height = characterSprite.sprite.textureRect.size.y * transform.localScale.y * 0.5f;   // Find out half of the total pixelheight
        //Debug.Log("TotalPixel height:" + totalPixel_height);
        //zeCreatedLevelUI.transform.position = new Vector3(transform.position.x, transform.position.y + ((totalPixel_height / (transform.localScale.y * transform.localScale.y)) * 0.5f), transform.position.z); // Making the UI to display above the character
        //zeCreatedLevelUI.transform.SetParent(transform);      // Making the UI's transform parent to be this
        //Debug.Log("Position of Level UI:" + zeCreatedLevelUI.transform.position);

        // Solution #2
        TextMesh zeChildMesh = transform.GetComponentInChildren<TextMesh>();
        zeChildMesh.text = "LVL:" + m_Level;
    }
	
    //void OnGUI()
    //{
    //    PosOfText.x = transform.position.x;
    //    PosOfText.y = transform.position.y + transform.localScale.y;
    //    GUI.DrawTexture(PosOfText, m_Background);   // Trying to render out the background first!
    //}
}
