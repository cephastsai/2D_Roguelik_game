using UnityEngine;
using System.Collections;

public class CleanWall : MonoBehaviour {

	private bool temp = true;
	private GameObject[] Wall;

	private float timer = 0f;
	private bool startclean = false;
	private int cleannum = 0;

	void Start () {
		Wall = GameObject.FindGameObjectsWithTag("Wall");
	}
	

	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			cleanWall();
		}

		if(Time.time - timer > 0.3f && startclean && cleannum < Wall.Length){
			Destroy(Wall[cleannum]);
			cleannum++;
			timer = Time.time;
		}
	}
	
	void cleanWall(){

		Instantiate(Resources.Load("Prefabs/Ability4FX",typeof(GameObject)),new Vector3(3.47f,3.53f,-4.37f) , Quaternion.identity);
		/*
		for(int i=0;i<Wall.Length;i++){
			Destroy(Wall[i]);
		}*/
		timer = Time.time;
		startclean = true;
		temp = false;
	}
}
