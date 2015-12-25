using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Story : MonoBehaviour {

	public class Stories{
		public int Level;
		public int RuneID;
		public string StoryInfo;
	}

	//story list
	private List<Stories> StoryList = new List<Stories>();

	//read in story info array 
	private string[] storyinfo;
	private string storystring = " ";

	//static var
	public static int Level;
	public static int rune;

	//GameObject
	private GameObject Player = null;

	//To determine story 
	private int LestLevel = 0;
	private bool ToDetermineFlag = false;
	private string CurrentText;
	private bool LevelStoryflag = false;

	public void init(){


	}

	void Start () {
		
		//read txt
		StreamReader streamReader  = new StreamReader("story.txt", System.Text.Encoding.Default);
		
		if(storystring != null){
			storystring = streamReader.ReadToEnd();
		}

		//split txt
		storyinfo = new string[50];
		storyinfo = storystring.Split(new char[] { '|' });



		for(int i =0; i < storyinfo.Length-1; i++){
			string[] temp = new string[5];
			temp = storyinfo[i].Split(new char[] { ',' });

			Stories storytemp = new Stories();
			storytemp.Level = Convert.ToInt32(temp[0]);
			storytemp.RuneID = Convert.ToInt32(temp[1]);
			storytemp.StoryInfo = temp[2];
			StoryList.Add(storytemp);
		}

		//print(Level +","+rune);
		/*
		for(int j =0;j<StoryList.Count;j++){
			print(StoryList[j].Level+","+StoryList[j].RuneID+","+StoryList[j].StoryInfo);
		}*/

	}
	

	void Update () {

		if(Level != LestLevel){
			ToDetermineFlag = true;
			LevelStoryflag = false;
		}

		//Determine story
		if(ToDetermineFlag){
			for(int i =0;i<StoryList.Count; i++){
				if(StoryList[i].Level == Level){
					if(StoryList[i].RuneID == rune || StoryList[i].RuneID == -1){
						CurrentText = StoryList[i].StoryInfo;
						LestLevel = Level;
						ToDetermineFlag = false;
					}
				}
			}
		}

		//set gameobject
		Player = GameObject.Find("Player");

		if(Player.transform.position.x + Player.transform.position.y > 7 && !LevelStoryflag){
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue(CurrentText,1);
			LevelStoryflag = true;
		}





	}
}
