using UnityEngine;
using System.Collections;

//Spawn red and blue tile based on random value
public class tileSpawner : MonoBehaviour {

	public GameObject red;
	public GameObject blue;

	void Start () {
		int r = Random.Range (0,4);
		if (r == 0) {
			Vector3 temp = transform.position;
			temp.z += 5f;
			Instantiate (red, temp, Quaternion.Euler (0, 0, 0));

			Vector3 temp1 = transform.position;
			temp1.z -= 5f;
			Instantiate (blue, temp1, Quaternion.Euler (0, 0, 0));
		}
		else if (r == 1) {
			Vector3 temp = transform.position;
			temp.z += 5f;
			Instantiate (blue, temp, Quaternion.Euler (0, 0, 0));
			
			Vector3 temp1 = transform.position;
			temp1.z -= 5f;
			Instantiate (red, temp1, Quaternion.Euler (0, 0, 0));
		}
		else if (r == 2) {
			Vector3 temp = transform.position;
			temp.z += 5f;
			Instantiate (red, temp, Quaternion.Euler (0, 0, 0));
			
			Vector3 temp1 = transform.position;
			temp1.z -= 5f;
			Instantiate (red, temp1, Quaternion.Euler (0, 0, 0));
		}
		else if (r == 3) {
			Vector3 temp = transform.position;
			temp.z += 5f;
			Instantiate (blue, temp, Quaternion.Euler (0, 0, 0));
			
			Vector3 temp1 = transform.position;
			temp1.z -= 5f;
			Instantiate (blue, temp1, Quaternion.Euler (0, 0, 0));
		}
		Destroy (this.gameObject);
	}
}
