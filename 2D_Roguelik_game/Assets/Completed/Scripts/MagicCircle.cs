using UnityEngine;
using System.Collections;

public class MagicCircle : MonoBehaviour {

	private int level;

	private GameObject player = null;

	private bool ToActivateFlag = false;

	private bool OverActivate = false;

	private Color MagicActivateColor = new Vector4(1,1,1,0);
	private float a = 0;

	private float timer = 0;
	private bool tempflag = true;

	void Start () {
		//get player
		player = GameObject.FindGameObjectWithTag("Player");


		level = GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().getlevel();
		//get Sprite Magic Circle
		SetSprite();

		if(LevelMagicCircle.MagicCircleDone[level] == 1){
			a = 1;
			OverActivate = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x >= 3 && player.transform.position.x <= 4 && player.transform.position.y >= 3 && player.transform.position.y <= 4){
			ToActivateFlag = true;
			//print("magic!!");		
		}else{
			ToActivateFlag = false;
			//print("NO");
		}

		MagicActivateColor = new Vector4(1,1,1,a);
		GetComponent<SpriteRenderer> ().color = MagicActivateColor;

		if(!OverActivate){
			if(ToActivateFlag){
				if(a <= 1){
					a += 0.5f/255f;
				}
			}else{
				if(a >=0){
					a -= 0.5f/255f;
				}
			}
		}
		
		if(a >= 1){
			OverActivate = true;
			LevelMagicCircle.MagicCircleDone[level] = 1;
		}


		if(ToActivateFlag && tempflag){
			timer = Time.time;
			tempflag = false;
		}

		if(Time.time - timer >= 1f && ToActivateFlag){
			print("go");
			//GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().enemymove();
			timer = Time.time;
		}
	}

	void SetSprite(){
		int level = GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().getlevel();
		gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Image/Magic Circle_activate " +InformationReaderCs.levelrune[level].ToString(),typeof(Sprite));
		//InformationReaderCs.levelrune[level].ToString()

		GameObject.Find("MagicCircle").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Image/Magic Circle " + InformationReaderCs.levelrune[level].ToString(),typeof(Sprite));
	}
	/*
	private void OnCollisionEnter2D (Collider2D other){

		print("123");
		if(other.tag == "Player"){
			print("magic!!");
		}
	}*/
}
