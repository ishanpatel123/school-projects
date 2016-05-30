using UnityEngine;
using System.Collections;

//basic AI. Calculate distance between player and itself. If player is in distance, look at player, and attack 
public class EnemyAI : MonoBehaviour {
	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public GameObject fpsTarget;
	Vector3 rot;

	void Start () 
	{
		fpsTarget = GameObject.FindWithTag ("Player");
	}
	
	void Update () 
	{
		fpsTargetDistance = Vector3.Distance (fpsTarget.transform.position, transform.position);
		if (fpsTargetDistance < enemyLookDistance) 
		{
			lookAtPlayer ();
		}
		if (fpsTargetDistance < attackDistance) 
		{
			attackPlease ();
		} 
	}
	
	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation(fpsTarget.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*damping);
	}
	
	void attackPlease()
	{
		transform.Translate (Vector3.forward * enemyMovementSpeed * Time.deltaTime);		
	}
	
	

}﻿
