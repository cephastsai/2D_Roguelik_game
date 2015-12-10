using UnityEngine;
using System.Collections;

public class AddFoodPercentage : MonoBehaviour {

	private bool temp = true;
	GameObject player = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			AbilityAddFoodPercentage();
		}
	}

	void AbilityAddFoodPercentage(){
		player = GameObject.FindGameObjectWithTag ("Player"); 
		player.GetComponent<Completed.Player>().addfood(1,1.2f);
		temp = false;
	}
}
