using UnityEngine;
using System.Collections;

//Instantiate one of two blocks based on random value
public class tileSpawner3 : MonoBehaviour {

	public GameObject red;
	public GameObject blue;

	void Start () {
		int r = Random.Range (0,2);
		if (r == 0) {
			Vector3 temp = transform.position;
			Instantiate (red, temp, Quaternion.Euler (0, 0, 0));
		}
		else if (r == 1) {
			Vector3 temp = transform.position;
			Instantiate (blue, temp, Quaternion.Euler (0, 0, 0));
		}
		Destroy (this.gameObject);
	}
}
