using UnityEngine;
using System.Collections;

//Player pick up throwing object
public class collectObj : MonoBehaviour {

	Rigidbody rb;
	void Start(){
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") 
		{
			globalVariable.countEggs++;
			Destroy(gameObject);
		}
	}	
}
