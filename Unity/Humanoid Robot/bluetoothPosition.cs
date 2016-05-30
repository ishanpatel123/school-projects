using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class bluetoothPosition : MonoBehaviour {

	public Text x,y,z;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update position received from Blue-tooth device per frame 
	
	void Update () {
	
		x.text = "X: " + COM.xAxis.ToString();
		y.text = "Y: " + COM.yAxis.ToString();
		z.text = "Z: " + COM.zAxis.ToString();
	}
}
