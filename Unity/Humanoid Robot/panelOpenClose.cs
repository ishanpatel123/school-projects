using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class panelOpenClose : MonoBehaviour {

   public static bool colorPanelOpenClose = false;

    public void OnClicked(Button button)
    {
        if (button.name == "ClosePanel")
        {
            colorPanelOpenClose = false;
        }
        else if(button.name == "bgColor")
        {
            colorPanelOpenClose = true;
        }
	}
}
