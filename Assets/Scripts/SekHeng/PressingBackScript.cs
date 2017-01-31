using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This is just to deal with pressing the back button of the phone
/// For now it will just be loading to another scene!
/// </summary>
public class PressingBackScript : MonoBehaviour {
    public string sceneName = "SekHengScene";

	// Update is called once per frame
	void Update () {
	    if (Application.platform == RuntimePlatform.Android && Input.GetKeyUp(KeyCode.Escape))  // if the player pressed the back button on the android phone, load the next scene!
        {
            SceneManager.LoadScene(sceneName);
        }
	}
}
