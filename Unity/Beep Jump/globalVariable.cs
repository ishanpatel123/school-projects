using UnityEngine;
using System.Collections;

//contains global variables which are accessible from other classes
public class globalVariable : MonoBehaviour {
	public static int countEggs = 0, coin = 0, life = 0;
	public static bool throwBUttonDown = false;
	public static bool checkEggs = true;
	public static bool Eggs = false, tBD1 = false, tBD2 = false, AIcollision = false;
	public static bool pause = false, gameOver = false;
	
	void Update () {
		if(globalVariable.coin >= 100)
		{
			globalVariable.coin = 0;
			globalVariable.life++;
		}
	}
}
