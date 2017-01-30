using UnityEngine;
using System.Collections;

public class CustomDialog : MonoBehaviour {
    public GameObject theMainDialog;

    public void startDialog()
    {
        theMainDialog.SetActive(true);
    }

    public void closeDialog()
    {
        theMainDialog.SetActive(false);
    }
	
}
