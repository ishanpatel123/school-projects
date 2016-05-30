using UnityEngine;
using System.Collections;

public class tankScript3 : MonoBehaviour {

	void Update () {
		transform.Rotate (650.0f * Vector3.up * Time.deltaTime);

	}
}
