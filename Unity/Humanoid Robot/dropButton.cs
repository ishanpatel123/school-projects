using UnityEngine;
using System.Collections;

public class dropButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void drop () {
        grabButton.grabObject = 2;
    }
}
