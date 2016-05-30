using UnityEngine;
using System.Collections;


//rotating coin. If collide with player or throwing ball, count it and destroy itself
public class coinScript : MonoBehaviour {

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
			transform.GetChild(0).GetComponent<Renderer>().enabled = false;

			fast = true;
			source.PlayOneShot(shootSound,1f);
			if(playT == false)
			{
				globalVariable.coin = globalVariable.coin + 3;
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
