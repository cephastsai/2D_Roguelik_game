using UnityEngine;
using System.Collections;

public class changeday : MonoBehaviour {

	private GameObject player;

	void Start () {
	
	}
	

	void Update () {
	
	}

	void OnMouseDown(){
		player = GameObject.Find("Player");
		player.transform.position = new Vector3(7f,7f,0f);
	}
}
