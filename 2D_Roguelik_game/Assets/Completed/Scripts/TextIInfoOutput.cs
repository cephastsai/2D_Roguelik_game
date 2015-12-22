using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextIInfoOutput : MonoBehaviour {

	//text info string list
	private	 Queue<string> TextInfoList = new Queue<string>();

	//text
	private Text storytext = null;
	private float TextTime = 0f;
	private bool Textflag = false;
	private float TextExistenceTime = 5f;
	private float TextColdDown;
	private float TextColdDownTime = 3f;
	private bool ColdTimeflag = false;

	//color a
	private Material BGMat = null;
	private Color color;
	private bool SetColor = false;

	void Start () {
		storytext = GameObject.Find ("storytext").GetComponent<Text> ();
		BGMat = (Material)Resources.Load("Material/StoryInfoBgMat",typeof(Material));

		//set value
		color.a = 0/255;
		color.r = 1;
		color.g = 1;
		color.b = 1;
		AddStringToQue("1234");
		AddStringToQue("5678");
		AddStringToQue("9012");

		//init
		storytext.color = color;
	}
	

	void Update () {
		BGMat.color = color;
		storytext.color = color;


		if(TextInfoList.Count != 0 && !Textflag){
			ShowOutput();
		}

		if(Time.time - TextTime >= TextExistenceTime && Textflag && !ColdTimeflag){
			if(color.a >0.05f){
				color.a -= 1.5f/255f;
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

	}

	void OutputString(){
		storytext.text = TextInfoList.Dequeue();
	}

	void ShowOutput(){
		Textflag = true;
		TextTime = Time.time;
		OutputString();
		//gameObject.transform.scale.y = 24f*storytext.text.
		color.a = 255/255;


	}

	public void AddStringToQue(string info){
		TextInfoList.Enqueue(info);
	}

	public void ClearQue(){
		TextInfoList.Clear();
	}
}
