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
		player = GameObject.Find("Player");
	}
	
	
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			Instantiate (Resources.Load("Prefabs/Ablilty6FX",typeof(GameObject)), new Vector3(3.49f,3.37f,0f), Quaternion.identity);
			getAllBoardFood();
		}
	}
	
	void getAllBoardFood(){
		Food = GameObject.FindGameObjectsWithTag("Food");
		Soda = GameObject.FindGameObjectsWithTag("Soda");


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
