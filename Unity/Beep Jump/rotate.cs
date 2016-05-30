using UnityEngine;
using System.Collections;

//coin rotation class. If player collide with coin; count coin, play sound then destroy itself
public class rotate : MonoBehaviour {

	public GameObject other;
	public float moveSpeed = 350.0f;
	bool fast = false, playT = false;
	float timeLeft = 0.3f;
	public AudioClip shootSound;
	private AudioSource source;
	
	void Start () 
	{
		source = GetComponent<AudioSource>();
		transform.rotation = Quaternion.Euler (270, 0, 0);
	}

	void Update () 
	{
		if(fast == false)
		{
			transform.Rotate(moveSpeed * Vector3.back * Time.deltaTime);
		}
		else
		{
			timeLeft -= Time.deltaTime;
			if(timeLeft <= 0.0f)
			{
				Destroy(gameObject);
			}
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			GetComponent<Renderer>().enabled = false;
			fast = true;
			source.PlayOneShot(shootSound,1f);
			if(playT == false)
			{
				globalVariable.coin++;
				playT = true;
			}
		}

		if (other.tag == "ball") {
			fast = true;
			source.PlayOneShot(shootSound,1f);
			GetComponent<Renderer>().enabled = false;
			if(playT == false)
			{
				globalVariable.coin++;
				playT = true;
			}
		}
	}
	
}
