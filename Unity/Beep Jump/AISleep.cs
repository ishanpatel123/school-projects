using UnityEngine;
using System.Collections;

//Sleeping AI. Check if player collide on AI. If yes, destroy player. Destroy enemy when player jumps on AI.
public class AISleep : MonoBehaviour {

	public Transform fpsTarget;
	public Animation anim;
	Vector3 pos;
	public Transform sd;
	public AudioClip shootSound;
	bool truth = false;

	void Start() {
		pos = transform.position + new Vector3 (0,2.8f,0);
	}

	void Update(){
		if (truth == false) {
			anim.CrossFade ("EnemySleep");
		}
	}
	void Example() {
		Instantiate (fpsTarget, pos, transform.rotation);
	}

	IEnumerator wq(){
		yield return new WaitForSeconds (0.40f);
		fpsTarget.GetComponent<Renderer> ().enabled = false;
		Instantiate(sd, transform.position, transform.rotation);
		globalVariable.AIcollision = false;
		globalVariable.coin = globalVariable.coin + 2;
		Destroy(gameObject);
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player" && col.gameObject.transform.position.y > (transform.position.y +2.0f)) {
			truth = true;
			anim.Play ("EnemyDeath");
			globalVariable.AIcollision = true;
			GetComponent<AudioSource>().PlayOneShot(shootSound,1f);

			StartCoroutine (wq ());
		}

		if (col.tag == "ball") {
			anim.Play ("EnemyDeath");
			StartCoroutine (wq ());
		}
	}
}
	