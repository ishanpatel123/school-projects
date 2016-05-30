using UnityEngine;
using System.Collections;

//Enable and disable renderer of the coin
public class disCoin1 : MonoBehaviour {

	void Update () {
		if (timer.renderTurnOnOff == false) {
			GetComponent<Renderer>().enabled = false;
		}
		else
		{
			GetComponent<Renderer>().enabled = true;
		}
	}
}
