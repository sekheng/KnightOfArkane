using UnityEngine;
using System.Collections;

public class InvokeMessageScript : MonoBehaviour {
    [Tooltip("This is for invoking the methods of certain Message when called. Combined with MessageSystem!")]
    public string theMessage = "";
    public void InvokeMessageCall()
    {
        MessageSystem.instance.triggerEventCall(theMessage);
    }
}
