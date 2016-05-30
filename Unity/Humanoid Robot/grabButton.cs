using UnityEngine;
using System.Collections;

public class grabButton : MonoBehaviour {

    public static int grabObject = 0;
	
	public void grabObj1 () {
        grabObject = 1;
        StartCoroutine(asd());
    }

    IEnumerator asd()
    {
        yield return new WaitForSeconds(0.3f);
        if (grabObj.ObjectHolding == 0)
        {
            grabObject = 2;
        }
    }

}
