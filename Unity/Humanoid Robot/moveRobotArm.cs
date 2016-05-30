using UnityEngine;
using System.Collections;

public class moveRobotArm : MonoBehaviour {
	public float smooth = 2.0F;
	public Transform arm;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Quaternion target = Quaternion.Euler(COM.xAxis, COM.yAxis, COM.zAxis);
		arm.transform.rotation = Quaternion.Euler(COM.xAxis, COM.yAxis, COM.zAxis);
	}
}
