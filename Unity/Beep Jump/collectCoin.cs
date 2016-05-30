using UnityEngine;
using System.Collections;

//destroy coin if collide with player
public class collectCoin : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
