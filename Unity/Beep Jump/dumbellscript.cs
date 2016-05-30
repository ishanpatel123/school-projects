using UnityEngine;
using System.Collections;

//Dumbbell shaped object, which move and rotate back and forth 
public class dumbellscript : MonoBehaviour {
	public Vector3 pos1, pos2;
	public Vector3 from = new Vector3(0f, 0f, -600f);
	public Vector3 to   = new Vector3(0f, 0f, 600f);
	public float speed = 1.0f; 
	void Start()
	{
		pos1 = transform.position;
		pos2 = transform.position + new Vector3 (-8.0f,0,0);
	}

	void Update ()
	{
		transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time -500, 1.0f));
		transform.eulerAngles = Vector3.Lerp (from, to, Mathf.PingPong(Time.time -500, 1.0f));
	}
}
