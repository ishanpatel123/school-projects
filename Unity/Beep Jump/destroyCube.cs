using UnityEngine;
using System.Collections;

//Destroy object if it is out of the sight of camera
public class destroyCube : MonoBehaviour {
	float asd = 8.0f;

	void Update(){
		asd -= Time.deltaTime;
		if (asd < 0 && transform.position.x < (Camera.main.transform.position.x - 8f))
		{
			Destroy(gameObject);
		}
		else if (asd < 0) {
			asd = 5.0f;
		}
	}

}
