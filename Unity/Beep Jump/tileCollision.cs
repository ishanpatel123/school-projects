using UnityEngine;
using System.Collections;

//Invoke tiles() method based on the player collide with tiles
public class tileCollision : MonoBehaviour {

	public static int tileSpawned = 0;
	bool spawnOnce = false;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && spawnOnce == false) {	
			tileSpawned++;
			tileManager.Instance.tiles();
			spawnOnce = true;
		}
	}
}
