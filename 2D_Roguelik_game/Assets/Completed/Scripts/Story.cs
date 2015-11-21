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
	//private bool storylist[10];

	private Text storytext = null;
	private bool storyon = true;

	private FileInfo theSourceFile = null;
	//private StreamReader streamReader = null;
	private string storystring = " ";


	// Use this for initialization
	void Start () {
		storycondition = new int[6,4]
		{
			{1,-1,-1,6},
			{1,-1,1,1},
			{1,-1,2,2},
			{1,-1,3,3},
			{1,-1,4,4},
			{1,-1,5,5}
		};

		//theSourceFile = new FileInfo("story.txt");
		StreamReader streamReader  = new StreamReader("story.txt", System.Text.Encoding.Default);
		//streamReader = theSourceFile.OpenText();
		
		if(storystring != null){
			storystring = streamReader.ReadToEnd();
			//print(storystring);
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

		if(Time.time > 4f)
			storyon = false;


		if(storyon == false){
			for(int i=0;i<6;i++){			
				if(Level == storycondition[i,0] || storycondition[i,0] == -1)
					if(food == storycondition[i,1] || storycondition[i,1] == -1)
						if(rune == storycondition[i,2] || storycondition[i,2] == -1){							
							infooutput(storycondition[i,3]-1);
							//print(storyinfo[storycondition[i,3]-1]);														
						}
			}
		}

	}

	public void infooutput(int infoID){
		storyon = true;
		storytext = GameObject.Find ("storytext").GetComponent<Text> ();
		storytext.text = storyinfo[infoID];

	}
}
