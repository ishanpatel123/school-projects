using UnityEngine;
using System.Collections;

//camera follow player only on X and Z direction
public class rotateCamera : MonoBehaviour {
	public GameObject player;
	public float x,y,z,e,f,g;
	
	void LateUpdate () {
		if (player != null) {
			Quaternion rotation = Quaternion.Euler (33, 45, 0);

			Vector3 playerPos = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

			Vector3 position = new Vector3 (-50, 50, -50) + playerPos;

			transform.position = position;
			transform.rotation = rotation;
		} else {
			transform.position = transform.position;
			transform.rotation = transform.rotation;
		}
	}
}
