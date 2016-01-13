using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextIInfoOutput : MonoBehaviour {

	private class SetTextTime{
		public float ExistenceTime;
		public float ColdDownTime;
		public float PerAlphaLose;
		
		public SetTextTime(int num){
			
			switch(num){
			case 1:
				ExistenceTime = 5f;
				ColdDownTime = 1.5f;
				PerAlphaLose = 2f;
				break;
			case 2:
				ExistenceTime = 1.5f;
				ColdDownTime = 0.3f;
				PerAlphaLose = 4f;
				break;
			case 3:
				ExistenceTime = 3f;
				ColdDownTime = 0.3f;
				PerAlphaLose = 4f;
				break;
			}
		}
	}

	//text info string list
	private	Queue<string> TextInfoList = new Queue<string>();
	//text time que
	private Queue<SetTextTime> InfoTime = new Queue<SetTextTime>();
	//queue count 0 
	public bool InfoListClean = true;

	//text
	private Text storytext = null;
	private float TextTime = 0f;
	private bool Textflag = false;
	public float TextExistenceTime = 5f;
	private float TextColdDown;
	public float TextColdDownTime = 1.5f;
	private bool ColdTimeflag = false;
	public float TextPerAlphaLose = 2f;

	//color a
	private Material BGMat = null;
	private SpriteRenderer BGsprite = null;
	private Color color;
	private bool SetColor = false;


	void Start () {
		storytext = GameObject.Find ("storytext").GetComponent<Text> ();
		//BGMat = (Material)Resources.Load("Material/StoryInfoBgMat",typeof(Material));
		BGsprite = GetComponent<SpriteRenderer>();

		//set value
		color.a = 0/255;
		color.r = 1;
		color.g = 1;
		color.b = 1;

		//text string
		/*
		AddStringToQue("霍伊特",1);
		AddStringToQue("這是我的名字",2);
		AddStringToQue("霍伊特，這是我的名字嗎?",1);
		*/

		//init
		storytext.color = color;
	}
	

	void Update () {
		//BGMat.color = color;
		BGsprite.color = color;
		storytext.color = color;

		if(TextInfoList.Count != 0 && !Textflag){
			ShowOutput();
		}

		if(Time.time - TextTime >= TextExistenceTime && Textflag && !ColdTimeflag){
			if(color.a >0.05f){
				color.a -= TextPerAlphaLose/255f;
			}else{
				ColdTimeflag = true;
				TextColdDown = Time.time;
				color.a = 0/255;
			}
		}

		if(Time.time - TextColdDown >= TextColdDownTime && ColdTimeflag){
			ColdTimeflag = false;
			Textflag = false;
		}

		//Queue Count null
		if(TextInfoList.Count == 0){
			InfoListClean = true;
		}else{
			InfoListClean = false;
		}

	}

	void OutputString(){
		storytext.text = TextInfoList.Dequeue();
		SetTextTime temp = InfoTime.Dequeue();
		TextExistenceTime = temp.ExistenceTime;
		TextColdDownTime = temp.ColdDownTime;
		TextPerAlphaLose = temp.PerAlphaLose;
	}

	void ShowOutput(){
		Textflag = true;
		TextTime = Time.time;
		OutputString();
		gameObject.transform.localScale = new Vector3(31.5f*(float)(storytext.text.Length + 2)/450,transform.localScale.y,0);
		color.a = 255/255;		
	}

	public void AddStringToQue(string info, int TimeType){
		SetTextTime tempTime = new SetTextTime(TimeType);
		InfoTime.Enqueue(tempTime);
		TextInfoList.Enqueue(info);
	}

	public void ClearQue(){
		TextInfoList.Clear();
	}
}
