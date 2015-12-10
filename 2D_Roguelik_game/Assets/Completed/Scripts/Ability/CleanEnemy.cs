using UnityEngine;
using System.Collections;

public class CleanEnemy : MonoBehaviour {

	private bool temp = true;
	private GameObject[] Enemy;
	private GameObject manager;

	void Start () {
		
	}
	
	
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			cleanEnemy();
		}
	}
	
	void cleanEnemy(){
		Enemy = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i=0;i<Enemy.Length;i++){
			Destroy(Enemy[i]);
		}

		manager =  GameObject.Find("GameManager(Clone)");
		manager.GetComponent<Completed.GameManager>().enemies.Clear();

		temp = false;
	}
}
