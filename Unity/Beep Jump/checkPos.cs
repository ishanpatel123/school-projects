using UnityEngine;
using System.Collections;

//check position of object every second. If it runs out of the sight of camera, make itself dis-active.
//If it in the sight of camera, make itself reactive.
public class checkPos : MonoBehaviour {

	bool checkPos1 = false;
	void Start(){
		if (checkPos1 == false) {
			InvokeRepeating ("dd", 1, 1);
		}
	}
	void dd(){
		if (transform.position.x > (Camera.main.transform.position.x + 135f))
		{
			transform.gameObject.SetActive(false);
		}
		else if (transform.position.x <= (Camera.main.transform.position.x + 135f)) {
			transform.gameObject.SetActive(true);
			checkPos1 = true;
		}
	}
}
