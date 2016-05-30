using UnityEngine;
using System.Collections;

//Wait for 4 seconds, blink light and play beep sound 3 times than the blocks changes.
public class timer : MonoBehaviour {

	public Light lt;
	public static bool renderTurnOnOff = true, switchCondition = true, checkGrounded = false;
	public GameObject AudioBeep;
	public GameObject AudioBoom;
	public static int as12 = 0;
	public static float wait = 4;
	
	void Start () {
		StartCoroutine(routine1());
	}

	IEnumerator routine1()
	{
		while (true) {
				if (switchCondition == true) {
				lt.intensity = 1.0f;
				yield return new WaitForSeconds (wait);
				AudioBeep.GetComponent<AudioSource>().Play();
				lt.intensity = 0.5f;
				yield return new WaitForSeconds (0.25f);
				lt.intensity = 1.0f;
				yield return new WaitForSeconds (0.25f);
				AudioBeep.GetComponent<AudioSource>().Play();
				lt.intensity = 0.5f;
				yield return new WaitForSeconds (0.25f);
				lt.intensity = 1.0f;
				yield return new WaitForSeconds (0.25f);
				AudioBeep.GetComponent<AudioSource>().Play();
				lt.intensity = 0.5f;
				yield return new WaitForSeconds (0.25f);
				lt.intensity = 1.0f;
				yield return new WaitForSeconds (0.25f);
				lt.intensity = 0.5f;
				AudioBoom.GetComponent<AudioSource>().Play();
				renderTurnOnOff = false;
				switchCondition = false;
			} else if (switchCondition == false) {
				lt.intensity = 1.0f;
				yield return new WaitForSeconds (wait);
				AudioBeep.GetComponent<AudioSource>().Play();
				lt.intensity = 0.5f;
				yield return new WaitForSeconds (0.25f);
				lt.intensity = 1.0f;
				yield return new WaitForSeconds (0.25f);
				AudioBeep.GetComponent<AudioSource>().Play();
				lt.intensity = 0.5f;
				yield return new WaitForSeconds (0.25f);
				lt.intensity = 1.0f;
				yield return new WaitForSeconds (0.25f);
				AudioBeep.GetComponent<AudioSource>().Play();
				lt.intensity = 0.5f;
				yield return new WaitForSeconds (0.25f);
				lt.intensity = 1.0f;
				yield return new WaitForSeconds (0.25f);
				lt.intensity = 0.5f;
				AudioBoom.GetComponent<AudioSource>().Play();
				renderTurnOnOff = true;
				switchCondition = true;
			}
		}
	}
}
