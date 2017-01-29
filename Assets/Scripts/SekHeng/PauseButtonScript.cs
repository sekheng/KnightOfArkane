using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour {
    [Tooltip("This will lead to the Pause menu scene when pressed")]
    public string SceneName = "ZhaoyuanScene";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
