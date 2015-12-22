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

	public void init(){


	}

	void Start () {

		//read txt
		StreamReader streamReader  = new StreamReader("story.txt", System.Text.Encoding.Default);
		
		if(storystring != null){
			storystring = streamReader.ReadToEnd();
		}

		//split txt
		storyinfo = new string[30];
		storyinfo = storystring.Split(new char[] { '|' });

		for(int i =0; i < storyinfo.Length; i++){
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
	
	}
}
