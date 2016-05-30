using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Display coin count on UI
public class New : MonoBehaviour {
	
	public Text cT;

	void Update(){
		cT.text = globalVariable.coin.ToString();
	}
}