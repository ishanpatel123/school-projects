using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class changeColor : MonoBehaviour {
    public static string red = "", green = "", blue = "";
    float r = 0 , g = 0, b = 0;
    public InputField iFiled, iFiled1, iFiled2;

    public void applyColor () {

        if (iFiled.text != "")
            changeColor.red = iFiled.text;
        else
            changeColor.red = "0";

        if (iFiled1.text != "")
            changeColor.green = iFiled1.text;
        else
            changeColor.green = "0";

        if (iFiled2.text != "")
            changeColor.blue = iFiled2.text;
        else
            changeColor.blue = "0";

        r = Convert.ToInt32(red);
        g = Convert.ToInt32(green);
        b = Convert.ToInt32(blue);

        if (r >= 0 && r <= 255 && g >= 0 && g <= 255 && b >= 0 && b <= 255)
        {
            Camera.main.backgroundColor = new Color(r / 255.0f, g / 255.0f, b / 255.0f, 1);
        }
        else
        {
            Camera.main.backgroundColor = Color.black;
        }
    }
}
