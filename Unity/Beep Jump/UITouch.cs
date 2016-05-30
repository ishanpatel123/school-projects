using UnityEngine;
using System.Collections;
using System.Text;

//After Fading effect done, change the scene
public class UITouch : MonoBehaviour {
	public GameObject other;
	public void LoadStage(){
		StartCoroutine (cc ());
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
