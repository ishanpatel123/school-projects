using UnityEngine;
using System.Collections;

//rotating Pigkart tire back and forth with ping pong function
public class pigKartTire : MonoBehaviour {

	public Vector3 from = new Vector3(0, 90f, 600f);
	public Vector3 to   = new Vector3(0f, 90f, -600f);

	
	void Update () {
		transform.eulerAngles = Vector3.Lerp (from, to, Mathf.SmoothStep(0f,1f,Mathf.PingPong(Time.time -500, 1.0f)));
	}
}
