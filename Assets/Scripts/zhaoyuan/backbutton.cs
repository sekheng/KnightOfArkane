using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backbutton : MonoBehaviour {
    //this is like SekHeng's pause menu script
    public string SceneName;
	

    public void loadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
