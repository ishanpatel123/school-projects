using UnityEngine;
using System.Collections;

//Its 3d letter "Z" displays on top of Sleeping AI and change size to show AI is currently sleeping
public class ThreeDtext : MonoBehaviour {
	Vector3 targetScale, originalScale;

	void Start () {
		transform.LookAt (Camera.main.transform);
		transform.Rotate(0,180,0);
		originalScale = transform.localScale - new Vector3(0.4f, 0.4f, 0.4f);
		targetScale = originalScale + new Vector3(0.3f, 0.3f, 0.3f);
	}
	
	void Update () {
		transform.localScale = Vector3.Lerp(targetScale, originalScale, Mathf.PingPong(Time.time -500, 1.0f));
	}


}
