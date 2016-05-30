using UnityEngine;
using System.Collections;

//Spawn coins on the appearing/disappearing blocks
public class instCoins : MonoBehaviour {

	public Transform coin;
	Vector3 temp;
	void Start () {
		int r = Random.Range(0,10);
		if(r == 1){
			temp = transform.position;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
		}
		else if(r == 3){
			temp = transform.position;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
			
			temp = transform.position;
			temp.x += 3f;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
			
			temp = transform.position;
			temp.x -= 3f;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
		}
		else if(r == 4){
			temp = transform.position;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
			
			temp = transform.position;
			temp.z += 3f;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
			
			temp = transform.position;
			temp.z -= 3f;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
		}
		
		else if(r == 5){
			temp = transform.position;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
			
			temp = transform.position;
			temp.x += 3f;
			temp.z += 3f;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
			
			temp = transform.position;
			temp.x -= 3f;
			temp.z += 3f;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
			
			temp = transform.position;
			temp.x += 3f;
			temp.z -= 3f;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
			
			temp = transform.position;
			temp.x -= 3f;
			temp.z -= 3f;
			temp.y += 6f;
			Instantiate(coin, temp, Quaternion.Euler (0, 0, 0));
		}
	}
}
