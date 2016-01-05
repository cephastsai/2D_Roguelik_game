using UnityEngine;
using System.Collections;

public class AddFoodPercentage : MonoBehaviour {

	private bool temp = true;
	private bool peritemp = true;
	GameObject player = null;
	GameObject Ability2FX1 = null;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player"); 
	}
	
	// Update is called once per frame
	void Update () {
		if(SetupRuneAbility.startgame == true && peritemp == true){
			Ability2FX1 = Instantiate (Resources.Load("Prefabs/Ability2FX 1",typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject ;
			peritemp = false;
		}
		//Ability2FX1.GetComponent<ParticleSystem>().IsAlive() == false 
		if(Ability2FX1 != null  && temp == true){
			AbilityAddFoodPercentage();
			Ability2FX1 = null;
		}
	}

	void AbilityAddFoodPercentage(){
		player.GetComponent<Completed.Player>().addfood(1,1.2f);



		temp = false;
	}
}
