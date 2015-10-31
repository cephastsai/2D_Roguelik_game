using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class RuneManagerCs : MonoBehaviour {

	public Texture2D ButtonImage = null;
	public GUISkin RamdomSkin = null;

	private GameObject canvas = null;
	private GameObject grid = null;

    private FileInfo theSourceFile = null;
    private StreamReader StreamReader = null;
    private string text = " ";
    private int i = 0;
	private int[] ListNo = new int[50];
	private int j = 0;
	private int CheckPoint = 0;
    //private String[] RuneList = new String[50];
	private String RuneList;

	void OnGUI() {
		GUI.skin = RamdomSkin;
		if (GUI.Button(new Rect(520, 160,ButtonImage.width,ButtonImage.height),ButtonImage)&&CheckPoint==0)
		{
			for(int temp=0;temp<grid.transform.childCount;temp++){
				print(RuneList[temp]);
				if (RuneList [temp] == '1'){
					ListNo[j] = temp;
					j++;
					Debug.Log(j); 
					CheckPoint ++;
				}
				else if (RuneList [temp] == '0'){
				
				}
			}

		}
		
	}
    // Use this for initialization
    void Start () {
		ButtonImage = (Texture2D)Resources.Load("Image/Ramdom");
		RamdomSkin =  (GUISkin)Resources.Load("GUISkin/RamdomButton");
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
        theSourceFile = new FileInfo("Assets/Completed/Resources/rune.txt");
        StreamReader = theSourceFile.OpenText();
        if (text != null)
        {
            text = StreamReader.ReadToEnd();
            RuneList = text;
            Debug.Log("test:" + RuneList);
        }

		// add component "SetRuneMaterial" ,all child
		for(int temp=0;temp<grid.transform.childCount;temp++){
			print(RuneList[temp]);
			if (RuneList [temp] == '1'){
				grid.transform.GetChild(temp).gameObject.AddComponent<SetRuneMaterial>().init(temp);
			}
			else if (RuneList [temp] == '0'){
				grid.transform.GetChild(temp).gameObject.AddComponent<SetNullRuneMaterial>().init(temp);
			}
		}
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
