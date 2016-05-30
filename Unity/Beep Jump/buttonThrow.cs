using UnityEngine;
using System.Collections;

//Button "Y" and count the objects player is holding
public class buttonThrow : MonoBehaviour {
	public void example () {
		if (globalVariable.countEggs > 0) {
			globalVariable.throwBUttonDown = true;
		} 
		if (globalVariable.countEggs == 0) {
			globalVariable.tBD1 = true;
			StartCoroutine(WaitAndPrint(0.2F));
		}
	}
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds (waitTime);
		globalVariable.tBD1 = false;

	}
}
