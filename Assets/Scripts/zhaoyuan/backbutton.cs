using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backbutton : MonoBehaviour {
    //this is like SekHeng's pause menu script
    public string SceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
