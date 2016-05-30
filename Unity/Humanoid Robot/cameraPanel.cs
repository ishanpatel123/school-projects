using UnityEngine;
using System.Collections;

public class cameraPanel : MonoBehaviour {

    public GameObject Panel;

    void Update () {
	    if(panelOpenClose.colorPanelOpenClose == false)
        {
            Panel.SetActive(false);
        }
        else
        {
            Panel.SetActive(true);
        }
    }
}
