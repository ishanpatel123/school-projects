using UnityEngine;
using System.Collections;

//Player throw the ball like object if Y-Button is pressed
public class throwBall : MonoBehaviour {

	bool setPos, sameDirection = false;
	bool collisionCheck;
	GameObject player;
	Rigidbody rb;
	float timeLeft = 1.5f;
	public float moveSpeed = 150f;
	public Transform obj;
	public AudioClip shootSound;
	private AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		rb.useGravity = false;
	}

	void Update()
	{
		if (globalVariable.Eggs == true) {
			transform.GetComponent<Collider> ().isTrigger = false;
		} else {
			transform.GetComponent<Collider> ().isTrigger = true;
		}

		if (setPos == true) {
			if (globalVariable.throwBUttonDown == true) {
				rb.useGravity = true;
				if(sameDirection == false)
				{
					transform.Translate (player.transform.forward * Time.deltaTime * 25.0f, Space.World);
					sameDirection = true;
				}else{
					transform.Translate (transform.forward * Time.deltaTime * 25.0f, Space.World);
					transform.GetComponent<Collider> ().isTrigger = true;
				}
				transform.position = transform.position - new Vector3 (0, 0.2f, 0);
				timeLeft -= Time.deltaTime;
				if (timeLeft <= 0.0f) {
					globalVariable.throwBUttonDown = false;
					setPos = false;
					globalVariable.countEggs = 0;
					globalVariable.Eggs = false;
					source.PlayOneShot(shootSound,1f);
					foreach (Renderer r in GetComponentsInChildren<Renderer>())
					{
						r.enabled = false;
					}
					Instantiate(obj, transform.position, Quaternion.identity);
					StartCoroutine(ds ());
				}
				transform.GetComponent<Collider> ().isTrigger = false;
			} else {
				transform.position = player.transform.position + new Vector3 (0, 3, 0);
				transform.rotation = player.transform.rotation;
			} 
		} else {
			transform.Rotate (moveSpeed * Vector3.up * Time.deltaTime);

		}
	}

	IEnumerator ds(){
		yield return new WaitForSeconds (0.5f);
		GetComponent<Collider>().enabled = false;
		yield return new WaitForSeconds (0.5f);
		globalVariable.countEggs = 0;
		globalVariable.Eggs = false;
		Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player" && globalVariable.countEggs == 0) 
		{
			setPos = true;
			globalVariable.Eggs = true;
			globalVariable.countEggs++;
		}

		if (other.gameObject.tag != "Player" && globalVariable.countEggs > 0) {
			Debug.Log(other.gameObject.tag);
			setPos = false;
			globalVariable.countEggs = 0;
			globalVariable.Eggs = false;
			globalVariable.throwBUttonDown = false;
			source.PlayOneShot(shootSound,1f);
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
			{
				r.enabled = false;
			}
			Instantiate(obj, transform.position, Quaternion.identity);
			StartCoroutine(ds ());

		}
	}
}
