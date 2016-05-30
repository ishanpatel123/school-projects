using UnityEngine;
using System.Collections;

//Camera smoothly follow player
public class smothfollow : MonoBehaviour {

	public Transform target;
	public float distance = 15;
	public float height = 5;
	public float heightDamping = 3;
	public float rotationDamping = 3;
	
	void Start () {
		
	}
	
	void Update () {
		if (target){
			float wantedRotationAngle = target.eulerAngles.y;
			float wantedHeight = target.position.y + height;
			
			float currentRotationAngle = transform.eulerAngles.y;
			float currentHeight = transform.position.y;
			
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
			currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
			Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
			
			Vector3 pos = target.position;
			pos -= currentRotation * Vector3.forward * distance;
			pos.y = currentHeight;
			transform.position = pos;
			
			transform.LookAt (target);
		}
	}

}
