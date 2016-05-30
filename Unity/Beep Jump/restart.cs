using UnityEngine;
using System.Collections;

//restart game class
public class restart : MonoBehaviour {

	public void restart1 () {
		globalVariable.pause = false;
		globalVariable.gameOver = false;

		Application.LoadLevel ("main");
	}
	

}
