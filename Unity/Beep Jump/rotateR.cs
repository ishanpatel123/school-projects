using UnityEngine;
using System.Collections;

//rotation class for any object in scene. Assign this script to object and select "num" variable to rotate on different direction
public class rotateR : MonoBehaviour {
	public float moveSpeed;
	public int num;
	void Start () {
	}

	void Update () {
		if (num == 1) 
		{
			transform.Rotate (moveSpeed * Vector3.up * Time.deltaTime);
		}
		else if (num == 2) 
		{
			transform.Rotate (moveSpeed * Vector3.down * Time.deltaTime);
		}
		else if (num == 3) 
		{
			transform.Rotate (moveSpeed * Vector3.forward * Time.deltaTime);
		}
		else if (num == 4) 
		{
			transform.Rotate (moveSpeed * Vector3.back * Time.deltaTime);
		}
		else if (num == 5) 
		{
			transform.Rotate (moveSpeed * Vector3.left * Time.deltaTime);
		}
		else if (num == 6) 
		{
			transform.Rotate (moveSpeed * Vector3.right * Time.deltaTime);
		}
	}


}
