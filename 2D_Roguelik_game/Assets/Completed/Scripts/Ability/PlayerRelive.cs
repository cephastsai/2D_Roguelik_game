using UnityEngine;
using System.Collections;

public class PlayerRelive : MonoBehaviour {

	private bool temp = true;
	
	void Start () {
		
	}
	
	
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			playerRelive();
		}
	}
	
	void playerRelive(){
		
		temp = false;
	}
}
