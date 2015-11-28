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
	public static int[] storybranch = new int[10];

	private int[,] storycondition ;
	private string[] storyinfo;
	private bool[] storylist = new bool[30];

	private Text storytext = null;
	public static Color textcolor ;
	public static float time;
	private float texttime;

	public static bool storyon = true;
	public static bool info_on = true;
	public static bool level_story = false;

	private string storystring = " ";


	// Use this for initialization
	void Start () {
		//init
		info_on = true;
		for(int j=0;j<storylist.Length;j++){
			storylist[j] = true;
			//storybranch[j] = 0;
		}
			

		//set condition
		storycondition = new int[15,6]
		{
			//{level,food,runeID,branchID,brancknum,infoID}
			{1,-1,-1,0,0,6},
			{1,-1,-1,0,1,7},
			{1,-1,-1,0,2,8},
			{1,-1,-1,0,2,9},
			{1,-1,-1,0,2,10},
			{2,-1,1,-1,-1,1},
			{2,-1,2,-1,-1,2},
			{2,-1,3,-1,-1,3},
			{2,-1,4,-1,-1,4},
			{2,-1,5,-1,-1,5},
			{3,-1,1,-1,-1,11},
			{3,-1,2,-1,-1,12},
			{3,-1,3,-1,-1,13},
			{3,-1,4,-1,-1,14},
			{3,-1,5,-1,-1,15},

		};
		
		StreamReader streamReader  = new StreamReader("story.txt", System.Text.Encoding.Default);
		
		if(storystring != null){
			storystring = streamReader.ReadToEnd();
		}

		storyinfo = new string[30];
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
		//print(storyon + "," + (Time.time- time));
		if(Time.time - time > 4f && info_on == true){
			storyon = false;
			info_on = false;
		}
			


		if(storyon == false && level_story == false){
			for(int i=0;i<15;i++){			
				if(Level == storycondition[i,0] || storycondition[i,0] == -1){
					if(food == storycondition[i,1] || storycondition[i,1] == -1){
						if(rune == storycondition[i,2] || storycondition[i,2] == -1){	

							if(storyon == false && storylist[i] == true){
								storylist[i] = false;
								infooutput(storycondition[i,5]);
								
								print(storycondition[i,5]);														
							}							
						}
					}
				}
			}
		}

		// info start
		if(storyon == true && storytext != null){

			//text set

			if(Time.time - texttime >=2){
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
		print(infoID);
		storytext = GameObject.Find ("storytext").GetComponent<Text> ();
		storytext.text = storyinfo[infoID];
		textcolor = storytext.color;
		storytext.color = textcolor;
		storyon = true;
		level_story = true;
		texttime= Time.time;
		
	}

	public void setcolor(){
		textcolor.a = 1f;
	}

}
