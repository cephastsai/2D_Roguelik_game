using UnityEngine;
using System.Collections;

public class MagicCircle : MonoBehaviour {

	private GameObject player = null;

	void Start () {
		//get player
		player = GameObject.FindGameObjectWithTag("Player");

		//get Sprite Magic Circle
		SetSprite();
	}
	
	// Update is called once per frame
	void Update () {

		if((player.transform.position.x >= 3 && player.transform.position.x <= 4) || (player.transform.position.y <= 3 && player.transform.position.y >= 4)){		
			print("magic!!");			
		}else{
			print("NO");
		}
	}

	void SetSprite(){
		int level = GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().getlevel();
		gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Image/Magic Circle",typeof(Sprite));
		//InformationReaderCs.levelrune[level].ToString()
	}
	/*
	private void OnCollisionEnter2D (Collider2D other){

		print("123");
		if(other.tag == "Player"){
			print("magic!!");
		}
	}*/
}
