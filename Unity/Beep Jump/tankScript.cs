using UnityEngine;
using System.Collections;

//Tank shoots one of four different coloured ring and also play sound and animation
public class tankScript : MonoBehaviour {
	public GameObject r1, r2, r3,r4;
	Vector3 childPos;
	float timeLeft = 3.0f;
	public AudioClip shootSound;
	public Animation animation;

	void Start () {
		animation = GetComponent<Animation>();

		childPos = transform.position;
	}
	
	void Update () {
		timeLeft -= Time.deltaTime;
		int rr = Random.Range (0,4);

		if (timeLeft < 0) {
			GetComponent<Animation>().Play ("tank");
			if(rr == 0){
				Instantiate (r1, childPos, transform.rotation);
				GetComponent<AudioSource>().PlayOneShot(shootSound,1f);
			}
			else if(rr == 1){
				Instantiate (r2, childPos, transform.rotation);
				GetComponent<AudioSource>().PlayOneShot(shootSound,1f);
			}
			else if(rr == 2){
				Instantiate (r3, childPos, transform.rotation);
				GetComponent<AudioSource>().PlayOneShot(shootSound,1f);
			}
			else if(rr == 3){
				Instantiate (r4, childPos, transform.rotation);
				GetComponent<AudioSource>().PlayOneShot(shootSound,1f);
			}
			timeLeft = 3.0f;

		}
	}
}
