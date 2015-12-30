using UnityEngine;
using System.Collections;

public class AddFood : MonoBehaviour {
	
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
			Ability2FX1 = Instantiate (Resources.Load("Prefabs/Ability3FX 1",typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject ;
			peritemp = false;
		}
		
		if(Ability2FX1.GetComponent<ParticleSystem>().IsAlive() == false && temp == true){
			AbilityAddFoodPercentage();
		}
	}
	
	void AbilityAddFoodPercentage(){
		player.GetComponent<Completed.Player>().addfood(2,30f);
		
		
		
		temp = false;
	}
}
