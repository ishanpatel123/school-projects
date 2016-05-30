using UnityEngine;
using System.Collections;

//If player collide with coin block, it spawn either coin, throwing object or nothing. After it spawn object, 
//shoot itself up and play death particle system then destroy itself
public class coinBlockScript : MonoBehaviour {

	GameObject fpsTarget;
	Vector3 target, cunnret;
	bool check = false, check1 = false, spawnT = false, spawnR = false;
	float timeLeft = 0.3f;
	public Vector3 pos1, pos2;
	public Transform brick, brick1, brick2;
	int r;
	Transform ab;
	public Transform sd;
	public AudioClip shootSound;

	void Update()
	{
		if (check1 == true) {
			if (check == false && timeLeft >= 0) {
				if(spawnT == false)
				{
					r = Random.Range(0,3);
					if(r == 0)
					{
					Instantiate(brick, transform.position, Quaternion.Euler (90, 0, 0));
					}
					else if(r == 1)
					{
					Instantiate(brick1, transform.position, transform.rotation);
					}
					spawnT = true;
				}
				if(spawnR == false)
				{
					Instantiate(brick2, transform.position + new Vector3(0, -1.21f, 0), Quaternion.Euler (90, 0, 0));
					spawnR = true;
				}
				transform.Translate (Vector3.up * 35.0f * Time.deltaTime);
				timeLeft -= Time.deltaTime;
				if (timeLeft <= 0) {
					Instantiate(sd, transform.position, Quaternion.identity);
					Destroy (gameObject);
				}
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player" && globalVariable.tBD1 == true) 
		{
			check1 = true;
			globalVariable.tBD1 = false;
			GetComponent<AudioSource>().PlayOneShot(shootSound,1f);
		}

		if (other.tag == "ball") {
			check1 = true;
			globalVariable.tBD1 = false;
		}
	}
}
