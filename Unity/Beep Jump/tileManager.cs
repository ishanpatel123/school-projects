using UnityEngine;
using System.Collections;

//Spawn blocks of different tiles(prefab) based on how player collide with tile spawner
public class tileManager : MonoBehaviour {
	public GameObject currentTile;
	public GameObject Prefab1, Prefab2, Prefab3, Prefab4, Prefab5, Prefab6, Prefab7, Prefab8, Prefab9, Prefab10, Prefab11, Prefab12, Prefab13, Prefab14, Prefab15, Prefab16, Prefab17, Prefab18, Prefab19, Prefab20, Prefab21, Prefab22, Prefab23, Prefab24, Prefab25, Prefab26, Prefab27, Prefab28, Prefab29, Prefab30, Prefab31, Prefab32, Prefab33, Prefab34, Prefab35, Prefab36, Prefab37, Prefab38, Prefab39, Prefab40;
	public GameObject tile1, tile2;
	int t1 = 55;
	Vector3 temp;
	int j = 2;
	public static tileManager instance;
	public static tileManager Instance{
		get{
			if(instance == null){
				instance = GameObject.FindObjectOfType<tileManager>();
			}
			return instance;
		}
	}

	public void tiles(){
		temp.y -= 0.5f;
		if (tileCollision.tileSpawned == 1) {
			j = 3;
		}
		if (tileCollision.tileSpawned == 4) {
			j = 4;
			timer.f1 = 3;
		}
		if (tileCollision.tileSpawned == 6) {
			j = 5;
			timer.f1 = 2;
		}
		if (tileCollision.tileSpawned == 9) {
			j = 7;
			timer.f1 = 1.5f;	
		}


		for (int i = 0; i < j; i++) {
			temp = currentTile.transform.GetChild (0).transform.GetChild (0).position;
			
			int r = Random.Range (0, 2);
			if (r == 0) {
				currentTile = (GameObject)Instantiate (tile1, temp, Quaternion.identity);	
			} else if (r == 1) {
				currentTile = (GameObject)Instantiate (tile2, temp, Quaternion.identity);	
			}
		}

		if (tileCollision.r < 4) {
			temp = currentTile.transform.GetChild (0).transform.GetChild (0).position;
			temp.y += 0.5f;
			int t = Random.Range(0,4);
			if(t1 == t)
			{
				t = Random.Range(0,4);
			}
			if(t == 0)
			{
				currentTile = (GameObject)Instantiate (Prefab1, temp, Quaternion.identity);
			}else if(t == 1)
			{
				currentTile = (GameObject)Instantiate (Prefab2, temp, Quaternion.identity);
			}else if(t == 2)
			{
				currentTile = (GameObject)Instantiate (Prefab3, temp, Quaternion.identity);
			}else if(t == 3)
			{
				currentTile = (GameObject)Instantiate (Prefab4, temp, Quaternion.identity);
			}
			t1 = t;
		}
		else if (tileCollision.r >= 4 && tileCollision.r < 8) {
			temp = currentTile.transform.GetChild (0).transform.GetChild (0).position;
			temp.y += 0.5f;
			int t = Random.Range(0,10);
			if(t1 == t)
			{
				t = Random.Range(0,10);
			}
			if(t == 0)
			{
				currentTile = (GameObject)Instantiate (Prefab11, temp, Quaternion.identity);
			}else if(t == 1)
			{
				currentTile = (GameObject)Instantiate (Prefab12, temp, Quaternion.identity);
			}else if(t == 2)
			{
				currentTile = (GameObject)Instantiate (Prefab13, temp, Quaternion.identity);
			}else if(t == 3)
			{
				currentTile = (GameObject)Instantiate (Prefab14, temp, Quaternion.identity);
			}else if(t == 4)
			{
				currentTile = (GameObject)Instantiate (Prefab5, temp, Quaternion.identity);
			}else if(t == 5)
			{
				currentTile = (GameObject)Instantiate (Prefab6, temp, Quaternion.identity);
			}else if(t == 6)
			{
				currentTile = (GameObject)Instantiate (Prefab7, temp, Quaternion.identity);
			}else if(t == 7)
			{
				currentTile = (GameObject)Instantiate (Prefab8, temp, Quaternion.identity);
			}else if(t == 8)
			{
				currentTile = (GameObject)Instantiate (Prefab9, temp, Quaternion.identity);
			}else if(t == 9)
			{
				currentTile = (GameObject)Instantiate (Prefab10, temp, Quaternion.identity);
			}
			t1 = t;

		}
		else if (tileCollision.r >= 8) {
			temp = currentTile.transform.GetChild (0).transform.GetChild (0).position;
			temp.y += 0.5f;
			int t = Random.Range(0,36);
			if(t1 == t){
				t = Random.Range(0,36);
			}
			if(t == 0)
			{
				currentTile = (GameObject)Instantiate (Prefab19, temp, Quaternion.identity);
			}else if(t == 1)
			{
				currentTile = (GameObject)Instantiate (Prefab20, temp, Quaternion.identity);
			}else if(t == 2)
			{
				currentTile = (GameObject)Instantiate (Prefab21, temp, Quaternion.identity);
			}else if(t == 3)
			{
				currentTile = (GameObject)Instantiate (Prefab22, temp, Quaternion.identity);
			}else if(t == 4)
			{
				currentTile = (GameObject)Instantiate (Prefab5, temp, Quaternion.identity);
			}else if(t == 5)
			{
				currentTile = (GameObject)Instantiate (Prefab6, temp, Quaternion.identity);
			}else if(t == 6)
			{
				currentTile = (GameObject)Instantiate (Prefab7, temp, Quaternion.identity);
			}else if(t == 7)
			{
				currentTile = (GameObject)Instantiate (Prefab8, temp, Quaternion.identity);
			}else if(t == 8)
			{
				currentTile = (GameObject)Instantiate (Prefab9, temp, Quaternion.identity);
			}else if(t == 9)
			{
				currentTile = (GameObject)Instantiate (Prefab10, temp, Quaternion.identity);
			}else if(t == 10)
			{
				currentTile = (GameObject)Instantiate (Prefab11, temp, Quaternion.identity);
			}else if(t == 11)
			{
				currentTile = (GameObject)Instantiate (Prefab12, temp, Quaternion.identity);
			}else if(t == 12)
			{
				currentTile = (GameObject)Instantiate (Prefab13, temp, Quaternion.identity);
			}else if(t == 13)
			{
				currentTile = (GameObject)Instantiate (Prefab14, temp, Quaternion.identity);
			}else if(t == 14)
			{
				currentTile = (GameObject)Instantiate (Prefab15, temp, Quaternion.identity);
			}else if(t == 15)
			{
				currentTile = (GameObject)Instantiate (Prefab16, temp, Quaternion.identity);
			}else if(t == 16)
			{
				currentTile = (GameObject)Instantiate (Prefab17, temp, Quaternion.identity);
			}else if(t == 17)
			{
				currentTile = (GameObject)Instantiate (Prefab18, temp, Quaternion.identity);
			}else if(t == 18)
			{
				currentTile = (GameObject)Instantiate (Prefab23, temp, Quaternion.identity);
			}else if(t == 19)
			{
				currentTile = (GameObject)Instantiate (Prefab24, temp, Quaternion.identity);
			}else if(t == 20)
			{
				currentTile = (GameObject)Instantiate (Prefab25, temp, Quaternion.identity);
			}else if(t == 21)
			{
				currentTile = (GameObject)Instantiate (Prefab26, temp, Quaternion.identity);
			}else if(t == 22)
			{
				currentTile = (GameObject)Instantiate (Prefab27, temp, Quaternion.identity);
			}else if(t == 23)
			{
				currentTile = (GameObject)Instantiate (Prefab28, temp, Quaternion.identity);
			}else if(t == 24)
			{
				currentTile = (GameObject)Instantiate (Prefab29, temp, Quaternion.identity);
			}else if(t == 25)
			{
				currentTile = (GameObject)Instantiate (Prefab30, temp, Quaternion.identity);
			}else if(t == 26)
			{
				currentTile = (GameObject)Instantiate (Prefab31, temp, Quaternion.identity);
			}else if(t == 27)
			{
				currentTile = (GameObject)Instantiate (Prefab32, temp, Quaternion.identity);
			}else if(t == 28)
			{
				currentTile = (GameObject)Instantiate (Prefab33, temp, Quaternion.identity);
			}else if(t == 29)
			{
				currentTile = (GameObject)Instantiate (Prefab34, temp, Quaternion.identity);
			}else if(t == 30)
			{
				currentTile = (GameObject)Instantiate (Prefab35, temp, Quaternion.identity);
			}else if(t == 31)
			{
				currentTile = (GameObject)Instantiate (Prefab36, temp, Quaternion.identity);
			}else if(t == 32)
			{
				currentTile = (GameObject)Instantiate (Prefab37, temp, Quaternion.identity);
			}else if(t == 33)
			{
				currentTile = (GameObject)Instantiate (Prefab38, temp, Quaternion.identity);
			}else if(t == 34)
			{
				currentTile = (GameObject)Instantiate (Prefab39, temp, Quaternion.identity);
			}else if(t == 35)
			{
				currentTile = (GameObject)Instantiate (Prefab40, temp, Quaternion.identity);
			}
			t1 = t;
		}
	}
}