using UnityEngine;
using System.Collections;

//Enable and disable renderer of the object
public class disReObj1 : MonoBehaviour {

	void Update () {
		if (timer.renderTurnOnOff == false) {
			GetComponent<Renderer>().enabled = false;
			transform.GetComponent<Collider>().isTrigger = true;		
		}
		else
		{
			GetComponent<Renderer>().enabled = true;

			transform.GetComponent<Collider>().isTrigger = false;
		}
	}
}
