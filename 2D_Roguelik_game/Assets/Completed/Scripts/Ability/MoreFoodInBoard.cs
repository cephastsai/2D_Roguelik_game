using UnityEngine;
using System.Collections;

public class MoreFoodInBoard : MonoBehaviour {

	private bool temp = true;
	private GameObject manager = null;
	private float timer = 0;
	private int addfoodnum = 3;
	private int addnum = 0;
	private bool startaddfood = false;

	void Start () {
		manager =  GameObject.Find("GameManager(Clone)");
	}
	
	
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			moreFoodInBoard();
		}

		if(Time.time - timer > 0.5f && addfoodnum != addnum && startaddfood){

			manager.GetComponent<Completed.BoardManager>().LayoutObjectAtRandom (manager.GetComponent<Completed.BoardManager>().foodTiles, 1, 1, false,true);

			timer = Time.time;
			addnum++;
		}

	}
	
	public void moreFoodInBoard(){
		
		timer = Time.time;
		/*
		for(int i=0; i<3; i++){
			manager.GetComponent<Completed.BoardManager>().LayoutObjectAtRandom (manager.GetComponent<Completed.BoardManager>().foodTiles, 1, 1, false,true);
		}*/


		startaddfood = true;
		temp = false;
	}
}
