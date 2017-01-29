using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//public GameObject DataPanel;
	public Canvas DataPanel2;
	public bool DataOpen;

	public Canvas OptionsPanel;
	public bool OptionOpen;

	// Use this for initialization
	void Start () 
	{
		DataOpen = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void ClickStart()
	{
		Application.LoadLevel("SekhengScene");
	}

	public void ClickOptions()
	{
		if (OptionOpen == false) 
		{
			OptionOpen = true;
			OptionsPanel.enabled = true;
		}
	}
	public void ClickCloseOptions()
	{
		if (OptionOpen == true) 
		{
			OptionOpen = false;
			OptionsPanel.enabled = false;
		}
	}
	public void ClickData()
	{
		if (DataOpen == false) 
		{
			DataOpen = true;
			DataPanel2.enabled = true;
		}
	}
	public void ClickCloseData()
	{
		if (DataOpen == true) 
		{
			DataOpen = false;
			DataPanel2.enabled = false;
		}
	}
}
