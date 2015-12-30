using UnityEngine;
using System.Collections;

public class NotToDestroy : MonoBehaviour {

	public static GameObject UIobject;

	void Awake(){
		if(UIobject == null){
			
			UIobject = gameObject;
			DontDestroyOnLoad(gameObject);
			
		}else if(UIobject != gameObject){
			
			Destroy(gameObject);
		}
	}

}
