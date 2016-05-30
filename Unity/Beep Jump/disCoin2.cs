using UnityEngine;
using System.Collections;

//Enable and disable renderer of the coin
public class disCoin2 : MonoBehaviour {

	void Update () {
		if (timer.renderTurnOnOff == true) {
			GetComponent<Renderer>().enabled = false;
		}
		else
		{
			GetComponent<Renderer>().enabled = true;
		}
	}
}
