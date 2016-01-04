using UnityEngine;
using System.Collections;

public class LevelRuneLight : MonoBehaviour {

	void Start(){
		for(int i =0; i<transform.childCount; i++){
			transform.GetChild(i).GetComponent<Light>().enabled = false; 
		}
	}

	public void ToActivateRuneLight(int level){

		transform.GetChild(level-1).GetComponent<Light>().enabled = true;
	}
}
