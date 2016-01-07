using UnityEngine;
using System.Collections;

public class ChangeLevel_Food : MonoBehaviour {

	private GameObject player = null;
	
	private int food;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		food = player.GetComponent<Completed.Player>().food;		
		GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().changelevel((food/20)-1);
		SetupRuneAbility.startgame = false;
		Application.LoadLevel("Main");
	}
}
