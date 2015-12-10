using UnityEngine;
using System.Collections;

public class CleanWall : MonoBehaviour {

	private bool temp = true;
	private GameObject[] Wall;

	void Start () {
		
	}
	

	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			cleanWall();
		}
	}
	
	void cleanWall(){
		Wall = GameObject.FindGameObjectsWithTag("Wall");
		for(int i=0;i<Wall.Length;i++){
			Destroy(Wall[i]);
		}
		temp = false;
	}
}
