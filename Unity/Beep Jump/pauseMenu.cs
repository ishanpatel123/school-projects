using UnityEngine;
using System.Collections;

//Pause and resume the game. Also open/close the pause  menu panel
public class pauseMenu : MonoBehaviour {

	public GameObject panel;

	void Update () {
		if (globalVariable.pause == true) 
		{
			Time.timeScale =0;
			panel.gameObject.SetActive(true);
		}
		else if (globalVariable.pause == false) 
		{
			Time.timeScale =1;
			panel.gameObject.SetActive(false);
		}



	}
}
