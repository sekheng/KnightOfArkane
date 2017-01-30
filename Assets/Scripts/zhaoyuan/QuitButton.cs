using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour {

    public string SceneName;


    public void loadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
