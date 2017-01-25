using UnityEngine;
using System.Collections;

public class ButtonMovenment : MonoBehaviour {
    private RectTransform btn_rt;
	// Use this for initialization
	void Start () {
        btn_rt = GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void moveUP()
    {
        Vector2 temp = btn_rt.rect.position;
        float coordY = temp.y + 216.5f;
        btn_rt.transform.position += new Vector3(0,coordY,0);
        //Debug.Log(coordY);
        //temp.y += 216.5;
    }

    public void moveDown()
    {
        Vector2 temp = btn_rt.rect.position;
        float coordY = temp.y - 216.5f;
        btn_rt.transform.position -= new Vector3(0, coordY, 0);
    }
}
