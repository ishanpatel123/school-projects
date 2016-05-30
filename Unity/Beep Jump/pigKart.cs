using UnityEngine;
using System.Collections;

//adding functionality so Pigkart can move back and forth smoothly
public class pigKart : MonoBehaviour {

	public Vector3 pos1, pos2;
	public float x,y,z;

	void Start () {
		pos1 = transform.position;
		pos2 = transform.position + new Vector3 (x,y,z);
	}
	
	void Update () {
		transform.position = Vector3.Lerp (pos1, pos2,  Mathf.SmoothStep(0f,1f,Mathf.PingPong (Time.time - 500, 1.0f)));
	}
}
