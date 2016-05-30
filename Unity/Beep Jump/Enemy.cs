using UnityEngine;
using System.Collections;

//patrol behaviour of enemy
public class Enemy : MonoBehaviour {
	GameObject pathGO;

	Transform targetPathNode;
	int pathNodeIndex = 0;

	float speed = 3f;

	public float health = 1f;

	public int moneyValue = 1;

	void Start () {
		pathGO = GameObject.Find("Path");
	}

	void GetNextPathNode() {
		if(pathNodeIndex < pathGO.transform.childCount) {
			targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
			pathNodeIndex++;
		}
		else {
			targetPathNode = null;
			ReachedGoal();
		}
	}
	
	void Update () {
		if(targetPathNode == null) {
			GetNextPathNode();
			if(targetPathNode == null) {
				ReachedGoal();
				return;
			}
		}
		Vector3 dir = targetPathNode.position - this.transform.localPosition;
		float distThisFrame = speed * Time.deltaTime;
		
		if(dir.magnitude <= distThisFrame) {
			targetPathNode = null;
		}
		else {
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}
	}

	void ReachedGoal() {
		pathNodeIndex = 0;
	}
	
	
}
