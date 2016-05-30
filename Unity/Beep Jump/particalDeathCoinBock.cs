using UnityEngine;
using System.Collections;

//play particle system and sound for half second then destroy itself
public class particalDeathCoinBock : MonoBehaviour {

	public AudioClip shootSound;

	void Start () {
		GetComponent<AudioSource>().PlayOneShot(shootSound,1f);
		StartCoroutine (ds ());
	}
	
	IEnumerator ds(){
		yield return new WaitForSeconds(0.5f);
		Destroy (gameObject);
	}
}
