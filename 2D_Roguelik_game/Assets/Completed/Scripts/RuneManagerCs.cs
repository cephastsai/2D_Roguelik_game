﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class RuneManagerCs : MonoBehaviour {
	private Animator plane;
	private Texture2D ButtonImage = null;
	private GUISkin RandomSkin = null;

	private GameObject canvas = null;
	private GameObject grid = null;

    private FileInfo theSourceFile = null;
    private StreamReader StreamReader = null;
    private string text = " ";
    private int i = 0;
	private int[] ListNo = new int[50];//總共的符文數量(預設50個)
	private int j = 0;//玩家擁有幾個符文
	private int CheckPoint = 0;//作為點選隨機按鈕的區隔數
    //private String[] RuneList = new String[50];
	private String RuneList;
	public static int K = 0;

	void Awake(){
		ButtonImage = (Texture2D)Resources.Load("Image/Random");
		//plane = GameObject.Find("plane").GetComponent<Animator>();
		RandomSkin =  (GUISkin)Resources.Load("GUISkin/RandomButton");

	}

    void OnGUI() {
		GUI.skin = RandomSkin;
		if (GUI.Button(new Rect(520, 160,ButtonImage.width,ButtonImage.height),ButtonImage)&&CheckPoint==0)
		{
			CheckPoint +=1;
			//plane.SetBool("Idle", false);
			for(int temp=0;temp<grid.transform.childCount;temp++){
				if (RuneList [temp] == '1'){
					ListNo[j] = temp;
					j++;
					//K = new int(Random.Range(1,j));
				}
			}
            K = UnityEngine.Random.Range(1, j);

            GameObject RuneRandom = new GameObject("RuneRandom");
            RuneRandom.AddComponent<MeshRenderer>();
            RuneRandom.AddComponent<MeshFilter>();
            RuneRandom.AddComponent<SetRuneMaterial>().init(K); //test

            print("RandomNum:" + ListNo[K]); //隨機產生數字

			SceneManager.CurrentRuneID = K;

			Application.LoadLevel("Main");
        }
		
	}

    // Use this for initialization
    void Start () {


		//find gameobject "gird"
		canvas = GameObject.Find("Canvas");
		grid = canvas.transform.GetChild(1).GetChild(0).gameObject;

		grid.transform.position = new Vector3(0,45,0);

		// add component "SetRuneMaterial" ,all child
		/*
		for(int temp=0;temp<grid.transform.childCount;temp++){
			print(RuneList[temp]);
			if (RuneList [temp] == "1"){
				grid.transform.GetChild(temp).gameObject.AddComponent<SetRuneMaterial>().init(temp);
			}
			else if (RuneList [temp] == "0"){
				grid.transform.GetChild(temp).gameObject.AddComponent<SetNullRuneMaterial>().init(temp);
			}
        }*/

        //讀取檔案
        theSourceFile = new FileInfo("rune.txt");
        StreamReader = theSourceFile.OpenText();
        if (text != null)
        {
            text = StreamReader.ReadToEnd();
            RuneList = text;
            //Debug.Log("test:" + RuneList);
        }

		// add component "SetRuneMaterial" ,all child
		for(int temp=0;temp<grid.transform.childCount;temp++){
			//print(RuneList[temp]);
			if (RuneList [temp] == '1'){
				grid.transform.GetChild(temp).gameObject.AddComponent<SetRuneMaterial>().init(temp+1);
			}
			else if (RuneList [temp] == '0'){
				grid.transform.GetChild(temp).gameObject.AddComponent<SetNullRuneMaterial>().init(temp+1);
			}
		}
    }
}
