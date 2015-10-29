using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class RuneManagerCs : MonoBehaviour {

	private GameObject canvas = null;
	private GameObject grid = null;

    private FileInfo theSourceFile = null;
    private StreamReader StreamReader = null;
    private string text = " ";
    private int i = 0;
    private String[] RuneList = new String[50];


    // Use this for initialization
    void Start () {

		//find gameobject "gird"
		canvas = GameObject.Find("Canvas");
		grid = canvas.transform.GetChild(1).GetChild(0).gameObject;

		grid.transform.position = new Vector3(0,45,0);

		// add component "SetRuneMaterial" ,all child
		for(int temp=0;temp<grid.transform.childCount;temp++){
			if (RuneList [temp] == "1"){
			grid.transform.GetChild(temp).gameObject.AddComponent<SetRuneMaterial>().init(temp);
			}
			else if (RuneList [temp] == "0"){
				grid.transform.GetChild(temp).gameObject.AddComponent<SetNullRuneMaterial>().init(temp);
			}
        }

        //讀取檔案
        theSourceFile = new FileInfo("Assets/Completed/Resources/rune.txt");
        StreamReader = theSourceFile.OpenText();
        if (text != null)
        {
            text = StreamReader.ReadToEnd();
            RuneList[i] = text;
            Debug.Log("test:" + RuneList[i]);
            i++;
        }
		/*if (RuneList [0] == '1') {

		}*/
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
