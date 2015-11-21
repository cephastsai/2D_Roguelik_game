using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class Story : MonoBehaviour {

	//private GameManeger manager;
	public static int Level;
	public static int food;
	public static int rune;

	private int[,] storycondition ;
	private string[] storyinfo;
	private bool[] storylist = new bool[10];

	private Text storytext = null;
	public static Color textcolor ;
	private float time;

	public static bool storyon = true;
	public static bool info_on = true;

	private string storystring = " ";


	// Use this for initialization
	void Start () {
		//init
		info_on = true;
		for(int j=0;j<storylist.Length;j++)
			storylist[j] = true;

		//set condition
		storycondition = new int[7,4]
		{
			{1,-1,-1,6},
			{1,-1,-1,7},
			{2,-1,1,1},
			{2,-1,2,2},
			{2,-1,3,3},
			{2,-1,4,4},
			{2,-1,5,5}
		};
		
		StreamReader streamReader  = new StreamReader("story.txt", System.Text.Encoding.Default);
		
		if(storystring != null){
			storystring = streamReader.ReadToEnd();
		}

		storyinfo = new string[10];
		storyinfo = storystring.Split(new char[] { '^' });
		/*
		for(int a=0;a<storyinfo.Length;a++)
			print(storyinfo[a]);
		*/	

		/*
		storyinfo = new string[6]
		{
			"1.",		//1
			"2.",
			"3.",
			"4.",
			"5.",		//5
			""
		};*/
		
	}
	
	// Update is called once per frame
	void Update () {
		//print(storyon);
		
		if(Time.time > 4f && info_on == true){
			storyon = false;
			info_on = false;
		}
			


		if(storyon == false){
			for(int i=0;i<7;i++){			
				if(Level == storycondition[i,0] || storycondition[i,0] == -1)
					if(food == storycondition[i,1] || storycondition[i,1] == -1)
						if(rune == storycondition[i,2] || storycondition[i,2] == -1){							
							if(storyon == false && storylist[i] == true){
								storylist[i] = false;
								infooutput(storycondition[i,3]-1);
								
								//print(storyinfo[storycondition[i,3]-1]);														
							}
						}	
			}
		}

		// info start
		if(storyon == true && storytext != null){

			//text set

			if(Time.time - time >=2){
				if(textcolor.a > 0.3f){
					textcolor.a -= 0.005f;
					storytext.color = textcolor;
				}
			}

			if(textcolor.a <= 0.3f){
				storytext.text ="";
				textcolor.a = 1f;
				storytext.color = textcolor;
				storyon = false;
			}

		}

	}

	public void infooutput(int infoID){

		storytext = GameObject.Find ("storytext").GetComponent<Text> ();
		storytext.text = storyinfo[infoID];
		textcolor = storytext.color;
		storytext.color = textcolor;
		storyon = true;
		time= Time.time;
		
	}

	public void setcolor(){
		textcolor.a = 1f;
	}

}
