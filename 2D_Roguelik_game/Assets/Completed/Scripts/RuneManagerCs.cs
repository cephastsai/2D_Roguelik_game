using UnityEngine;
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
	private String RuneList;
	private int K = 0;

	void OnGUI() {
		GUI.skin = RandomSkin;
		if (GUI.Button(new Rect(520, 160,ButtonImage.width,ButtonImage.height),ButtonImage)&&CheckPoint==0)
		{
			plane.SetBool("Idle", false);
			CheckPoint +=1;
			for(int temp=0;temp<grid.transform.childCount;temp++){
				if (RuneList [temp] == '1'){
					ListNo[j] = temp;
					j++;
				}
			}
            K = UnityEngine.Random.Range(1, j);
            print(ListNo[K]); //隨機產生數字
		}
		
	}
    // Use this for initialization
    void Start () {
		plane = GameObject.Find("plane").GetComponent<Animator>();
		ButtonImage = (Texture2D)Resources.Load("Image/Random");
		RandomSkin =  (GUISkin)Resources.Load("GUISkin/RandomButton");
		canvas = GameObject.Find("Canvas");
		grid = canvas.transform.GetChild(1).GetChild(0).gameObject;
		grid.transform.position = new Vector3(0,45,0);
        //讀取檔案
        theSourceFile = new FileInfo("Assets/Completed/Resources/rune.txt");
        StreamReader = theSourceFile.OpenText();
        if (text != null)
        {
            text = StreamReader.ReadToEnd();
            RuneList = text;
            Debug.Log("test:" + RuneList);
        }
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
