using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    //public string
    [Tooltip("This is just for switching between of scenes only!")]
    //public ArrayList allSceneNames = new ArrayList();
    public List<string> allSceneNames = new List<string>();

    // This is just mapping the numpads to each scene only
    //private ArrayList allTheButtons = new ArrayList();
    private List<KeyCode> allTheButtons = new List<KeyCode>();

	// Use this for initialization
	void Start () {
        int theNumberOfScene = 0;
        foreach (string zeSceneName in allSceneNames)   // This will help to automatically each scenes to the Numpad. So it means that there shouldnt be too many scene!
        {
            allTheButtons.Add(KeyCode.Keypad0 + theNumberOfScene);
            theNumberOfScene++;
        }
	}
	
    // Using Fixed Update so that it is being called once every frame!
    void FixedUpdate()
    {
        for (int number = 0; number < allTheButtons.Count; ++number)
        {
            if (Input.GetKeyDown(allTheButtons[number]))
            {
                SceneManager.LoadScene(allSceneNames[number].ToString());
            }
        }
    }
}
