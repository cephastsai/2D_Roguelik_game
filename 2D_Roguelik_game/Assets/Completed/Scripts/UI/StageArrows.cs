using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageArrows : MonoBehaviour {

	//level
	private int StageNum = 10;
	private int level;
	private int Curlevel = 1;
	//private GameManager manager = null;

	//top and buttom position
	private Vector3 TopPos = new Vector3(-5.4f,1.8f,0f);
	private Vector3 ButtomPos = new Vector3(-5.4f,-4.95f,0f);

	//level position
	private List<Vector3> StageArrowsPosition = new List<Vector3>();

	//move
	private bool startMove = false;
	public float Maxspeed = 5f;
	public float speed = 0f;
	public float a = 0.02f;

	// Use this for initialization
	void Start () {
		//GameManager
		//manager = GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>();

		//set level
		level = GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().getlevel();
		Curlevel = level;

		//init
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		level = GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().getlevel();

		if(level != Curlevel){
			LevelChange(level,Curlevel);
			Curlevel = level;
		}

		/*
		if(level - Curlevel >= 3 || Curlevel - level >= 3 ){
			Maxspeed = 3f;
		}*/

		if(speed < Maxspeed){
			speed += a;
		}

		if(transform.localPosition.y == StageArrowsPosition[level-1].y){
			speed = 0;
		}

		if(startMove){
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, StageArrowsPosition[level-1], speed*Time.deltaTime);
		}
	}

	void init(){
		//set position
		gameObject.transform.localPosition = ButtomPos;

		//set all stage position
		StageArrowsPosition.Add(ButtomPos);
		for(int i = 1;i < StageNum; i++){
			Vector3 temp = new Vector3(ButtomPos.x, ButtomPos.y +0.75f *(float)i, ButtomPos.z);
			//print(temp);
			StageArrowsPosition.Add(temp);
		}
	}

	void LevelChange(int level, int Curlevel){
		//print(level +","+ Curlevel);

		int i=0;
		startMove = true;	

	}
}
