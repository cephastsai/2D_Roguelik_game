using UnityEngine;
using System.Collections;

public class MoreFoodInBoard : MonoBehaviour {

	private bool temp = true;
	private GameObject manager = null;

	void Start () {
		
	}
	
	
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			moreFoodInBoard();
		}
	}
	
	void moreFoodInBoard(){
		manager =  GameObject.Find("GameManager(Clone)");

		for(int i=0; i<3; i++){
			manager.GetComponent<Completed.BoardManager>().LayoutObjectAtRandom (manager.GetComponent<Completed.BoardManager>().foodTiles, 1, 1, false);;
		}


		
		temp = false;
	}
}
