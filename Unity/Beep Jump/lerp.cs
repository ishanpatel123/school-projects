using UnityEngine;
using System.Collections;

//Spike flying object. If player is closer(in distance), it drop down and destroy player
public class lerp : MonoBehaviour {
	GameObject target;
	Vector3 startPos, endPos;
	public Animation animation;
	float lerpTime = 0.5f;
	float currentLerpTime;
	bool upDown;

	void Start () {
		target = GameObject.FindWithTag("Player");
		animation = GetComponent<Animation>();
		startPos = transform.position;
		endPos = transform.position + new Vector3 (0, -11f, 0);
	}
	

	void Update () {
			if (Vector3.Distance (transform.position, new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z)) < 5f) { 
				upDown = true;
			}

		if (upDown == true) {
			currentLerpTime += Time.deltaTime;
			float perc = currentLerpTime / lerpTime;		
			transform.position = Vector3.Lerp (startPos, endPos, perc);
		} 
	}
}
