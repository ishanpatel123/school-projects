using UnityEngine;
using System.Collections;

//destroy particle system after half second
public class particalDeath : MonoBehaviour {

	void Start () {
		StartCoroutine (ds ());
	}
	
	IEnumerator ds(){
		yield return new WaitForSeconds(0.5f);
		Destroy (gameObject);
	}
}
