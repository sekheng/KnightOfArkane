using UnityEngine;
using System.Collections;

/// <summary>
/// For the buy button only!
/// </summary>
public class ActivateDialogScript : MonoBehaviour {
    [Tooltip("Link it to the dialog box!")]
    public CustomDialog dialogBox;
    [Tooltip("Link it to the cost and calculation logic!")]
    public GetCostAndQuantityScript costCalculatioLogic;

    public void ActivateDialog()
    {
        if (costCalculatioLogic != null && dialogBox != null)
        {
            dialogBox.startDialog();
        }
    }
}
