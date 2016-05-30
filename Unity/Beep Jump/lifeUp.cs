using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Display lives of the player on UI 
public class lifeUp : MonoBehaviour {

	public Text cT;

	void Update () {
		cT.text = globalVariable.life.ToString();

	}
}
