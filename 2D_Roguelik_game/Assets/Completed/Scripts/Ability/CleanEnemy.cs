using UnityEngine;
using System.Collections;

public class CleanEnemy : MonoBehaviour {

	private bool temp = true;
	private GameObject[] Enemy;
	private GameObject manager;

	private float timer = 0;
	private int enemynum = 0;
	private bool startclean = false;
	private bool cleamtemp = true;

	void Start () {
		Enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			cleanEnemy();
		}

		if(Time.time - timer > 1f && startclean && enemynum != Enemy.Length && cleamtemp){

			for(int i=0;i<Enemy.Length;i++){
				Destroy(Enemy[i]);
			}

			manager =  GameObject.Find("GameManager(Clone)");
			manager.GetComponent<Completed.GameManager>().enemies.Clear();

			cleamtemp = false;
		}
	}
	
	void cleanEnemy(){
		/*
		for(int i=0;i<Enemy.Length;i++){
			Destroy(Enemy[i]);
		}*/
		Instantiate(Resources.Load("Prefabs/Ability5FX",typeof(GameObject)),new Vector3(3.41f,0.13f,-7.13f) , Quaternion.Euler(-90, 0, 0));



		timer = Time.time;
		startclean = true;
		temp = false;
	}
}

/*
 void Start () {
		Enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	
	void Update () {
		if(SetupRuneAbility.startgame == true && temp == true){
			cleanEnemy();
		}

		if(Time.time - timer < 1f && startclean && enemynum != Enemy.Length){
			Destroy(Enemy[enemynum]);
			enemynum++;
			timer = Time.time;
		}
	}
	
	void cleanEnemy(){

Instantiate(Resources.Load("Prefabs/Ability5FX",typeof(GameObject)),new Vector3(3.41f,0.13f,-7.13f) , Quaternion.Euler(-90, 0, 0));

manager =  GameObject.Find("GameManager(Clone)");
manager.GetComponent<Completed.GameManager>().enemies.Clear();

timer = Time.time;
startclean = true;
temp = false;
}
*/