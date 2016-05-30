using UnityEngine;
using System.Collections;

//objects won't destroy while changing scene
public class DontDestroy : MonoBehaviour {
		
		private static DontDestroy _instance ;
		
		void Awake()
		{
			if(!_instance)
				_instance = this ;
			else
				Destroy(this.gameObject) ;
			
			DontDestroyOnLoad(this.gameObject) ;
		}

}
