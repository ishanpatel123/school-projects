using UnityEngine;
using System.Collections;

//Enable and disable renderer of the object
public class disReObj2 : MonoBehaviour {

	void Update () {
		if (timer.renderTurnOnOff == true) {
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
