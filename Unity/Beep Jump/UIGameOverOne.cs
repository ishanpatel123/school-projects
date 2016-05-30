using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

//Rewarded Ads instantiation and play the ads depends on the random value
public class UIGameOverOne : MonoBehaviour {

	public GameObject other;

	public void LoadStage(){
		int i = Random.Range (0,3);
		if (i == 0) {
			if (Advertisement.IsReady ()) {
				Advertisement.Show ();
			}
			StartCoroutine (cc ());
		} else {
			StartCoroutine (cc ());
		}
	}
	
	IEnumerator cc(){
		tileCollision.r = 0;
		globalVariable.countEggs = 0;
		globalVariable.coin = 0;
		globalVariable.life = 0;
		timer.f1 = 4;
		globalVariable.Eggs = false;
		other.GetComponent<AudioSource>().Play();
		GameObject.Find ("_GM").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (0.8f);
		Application.LoadLevel ("gamePlay");
	}
}
