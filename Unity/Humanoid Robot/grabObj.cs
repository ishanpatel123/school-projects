using UnityEngine;
using System.Collections;

public class grabObj : MonoBehaviour {

	public Transform playerHand;
	public float positionOfCubeFromHand = -5.0f;
	public static int ObjectHolding = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (grabButton.grabObject == 2 && ObjectHolding > 0) 
		{
			playerHand.GetChild(0).transform.GetComponent<Rigidbody>().isKinematic = false;
			playerHand.transform.DetachChildren ();
			ObjectHolding = 0;
			grabButton.grabObject = 0;
		}
	
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag != "ground" && grabButton.grabObject == 1 && ObjectHolding == 0)
		{
		other.transform.SetParent(playerHand.transform);

			//other.transform.parent = playerHand.transform; 
			other.transform.localPosition = new Vector3(0, -other.transform.localScale.y/2, 0);
			
			other.attachedRigidbody.isKinematic = true;
			ObjectHolding++;
		}
		
	}
}
