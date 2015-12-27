using UnityEngine;
using System.Collections;

public class AddFood : MonoBehaviour {

	private bool temp = true;
	GameObject player = null;

	void Start () {
		
	}

	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			AbilityAddFood();
		}
	}
	
	void AbilityAddFood(){
		player = GameObject.FindGameObjectWithTag ("Player"); 
		player.GetComponent<Completed.Player>().addfood(2,30f);
		temp = false;
	}
}
