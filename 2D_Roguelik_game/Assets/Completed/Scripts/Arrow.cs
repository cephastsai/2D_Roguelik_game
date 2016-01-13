using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	//arrow prefabs
	private GameObject arrow = null;

	//level
	private GameObject manager = null;
	private int level = 0;

	//Player move
	private int playerstepnum = 0;
		
	void Start () {
		init ();
	}

	void Update () {
		
	}

	void init(){
		//Set GameObject
		arrow = (GameObject)Resources.Load("Prefabs/Arrow",typeof(GameObject));
		manager = GameObject.Find("GameManager(Clone)");

		//Set Varible
		level = manager.GetComponent<Completed.GameManager>().getlevel();
	}

	public void PlayerMove(){
		playerstepnum++;
	}
}
