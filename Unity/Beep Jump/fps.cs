using UnityEngine;
using System.Collections;

//Display frame rate per second for performance. Only used for implementation.
public class fps : MonoBehaviour {
	
	Rect sd, sd1;
	GUIStyle asd;

	void Start(){
		sd = new Rect (100, 100, 400, 100);

		asd = new GUIStyle ();
		asd.fontSize = 30;
	}

	void OnGUI(){
		float fps = 1 / Time.deltaTime;
		GUI.Label (sd, "FPS:" + fps);
	}
}