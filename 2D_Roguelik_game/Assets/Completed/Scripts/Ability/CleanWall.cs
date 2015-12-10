using UnityEngine;
using System.Collections;

public class CleanWall : MonoBehaviour {

	private bool temp = true;


	void Start () {
		
	}
	

	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			cleanWall();
		}
	}
	
	void cleanWall(){

		temp = false;
	}
}
