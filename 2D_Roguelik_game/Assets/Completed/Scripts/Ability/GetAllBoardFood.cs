using UnityEngine;
using System.Collections;

public class GetAllBoardFood : MonoBehaviour {

	private bool temp = true;
	private GameObject[] Food;
	private GameObject[] Soda;
	private GameObject manager = null;
	private GameObject player = null;
	private int addfood;
	
	void Start () {
		
	}
	
	
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			getAllBoardFood();
		}
	}
	
	void getAllBoardFood(){
		Food = GameObject.FindGameObjectsWithTag("Food");
		Soda = GameObject.FindGameObjectsWithTag("Soda");
		player = GameObject.Find("Player");

		for(int i=0;i<Food.Length;i++){
			Destroy(Food[i]);
			addfood += 10;
		}

		for(int i=0;i<Soda.Length;i++){
			Destroy(Soda[i]);
			addfood +=20;
		}

		player.GetComponent<Completed.Player>().addfood(2,(float)addfood);
		/*
		manager =  GameObject.Find("GameManager(Clone)");
		manager.GetComponent<Completed.BoardManager>().enemies.Clear();
		*/
		temp = false;
	}
}
