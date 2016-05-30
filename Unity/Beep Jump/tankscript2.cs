using UnityEngine;
using System.Collections;

//Tank shoots rings. If ring collide with player it plays death animation. If not, it destroy itself after 1.5 seconds.
public class tankscript2 : MonoBehaviour {

	float timeLeft = 1.5f;
	public float moveSpeed = 350.0f;
	public Transform destroyAnim;

	void Start () {

	}
	
	void Update () {
		transform.Translate (transform.forward * Time.deltaTime * -15.0f);
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {

			StartCoroutine(ds ());
			timeLeft = 1.0f;
		}
	}

	IEnumerator ds()
	{
		Instantiate(destroyAnim, transform.position, Quaternion.identity);
		GetComponent<Renderer>().enabled = false;

		GetComponent<Collider>().enabled = false;
		yield return new WaitForSeconds (0.1f);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			Instantiate(destroyAnim, transform.position, Quaternion.identity);
			StartCoroutine(ds ());
		}
	}
}
