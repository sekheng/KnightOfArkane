using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Text debugtxt;
	// Use this for initialization
	void Start () {
		debugtxt.text = "Started";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
		{
				if (Application.platform == RuntimePlatform.Android)
				{
					Application.Quit();
				}
		}
	}

	public void ClickedStart() {
		debugtxt.text = "Start Up";

	}

	public void ClickedOptions() {
		debugtxt.text = "Options";
	}
	
	public void ClickedData() {
		debugtxt.text = "Data";
	}
}
