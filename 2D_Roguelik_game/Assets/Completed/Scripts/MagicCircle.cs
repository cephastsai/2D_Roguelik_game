using UnityEngine;
using System.Collections;

public class MagicCircle : MonoBehaviour {

	private int level;

	private GameObject player = null;
	private GameObject Exit = null;

	public bool ToActivateFlag = false;

	public bool OverActivate = false;

	private Color MagicActivateColor = new Vector4(1,1,1,0);
	private float a = 0;

	private float timer = 0;
	private bool tempflag = true;

	//ParticleSystem
	private GameObject AlureFX = null;
	private GameObject MagicCircleFX = null;
	private float PlayTime = 0f;

	void Start () {
		//get player
		player = GameObject.FindGameObjectWithTag("Player");

		// get GameObject
		AlureFX = (GameObject)Resources.Load("Prefabs/AlureFX",typeof(GameObject));
		Exit = GameObject.Find("Exit(Clone)");
		Exit.SetActive(false);

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

		if(GameObject.Find("Text_BG").GetComponent<Newhand>().MagicCircleOn || !Newhand.Newhandflag){
			if(player.transform.position.x >= 3 && player.transform.position.x <= 4 && player.transform.position.y >= 3 && player.transform.position.y <= 4){
				ToActivateFlag = true;
				
				if(MagicCircleFX == null){
					MagicCircleFX = Instantiate(AlureFX,transform.position,Quaternion.Euler(90, 0, 0)) as GameObject;
					MagicCircleFX.GetComponent<ParticleSystem>().Simulate(PlayTime,true,true);
					MagicCircleFX.GetComponent<ParticleSystem>().Play();
				}
				//print("magic!!");		
			}else{
				ToActivateFlag = false;
				if(MagicCircleFX != null && !OverActivate){
					Destroy(MagicCircleFX);
				}
				//print("NO");
			}
		}


		MagicActivateColor = new Vector4(1,1,1,a);
		GetComponent<SpriteRenderer> ().color = MagicActivateColor;

		if(!OverActivate){
			if(ToActivateFlag){
				if(a <= 1){
					a += 1f/255f;
				}
			}else{
				if(a >=0){
					a -= 1f/255f;
				}
			}
		}

		PlayTime = a*5f;

		if(a >= 1){
			OverActivate = true;		
			LevelMagicCircle.MagicCircleDone[level] = 1;
			GameObject.Find("InterFace").transform.GetChild(5).GetComponent<LevelRuneLight>().ToActivateRuneLight(level);
			Exit.SetActive(true);
		}


		if(ToActivateFlag && tempflag){
			timer = Time.time;

			tempflag = false;
		}

		if(Time.time - timer >= 1f && ToActivateFlag){

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
