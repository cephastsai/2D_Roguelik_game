using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class InformationReaderCs : MonoBehaviour {


	public static FileInfo theSourceFile = null;
	public static StreamReader streamReader = null;
	public static StreamWriter streamWriter = null;
	public static string text = " ";
	public static int[][][] runeinfo;
	//public static string[] temp

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void load(){


		//檔案讀取
		theSourceFile = new FileInfo("Assets/Completed/Resources/test.txt");
		streamReader = theSourceFile.OpenText();

		if (text != null)
		{
			//ReadToEnd:可以將文件從頭讀到尾
			//ReadLine:只可讀取文件的一行文字
			text = streamReader.ReadToEnd();
			//print(text);

			string[] textTemp = text.Split(new char[] { ';' }); //";"為每一個死亡次數的區隔


			LoadRuneInfo(textTemp);
		}
		streamReader.Close ();

	}

	public static void SaveFile(){
		//print(text);
		//theSourceFile = new FileInfo("Assets/Completed/Resources/test.txt");
		StreamWriter writer = new StreamWriter("Assets/Completed/Resources/test.txt");
		//writer.Write(text,0,20);
		writer.Write(text);
		writer.Close();
		//writer.Dispose();

	}

	public static void LoadRuneInfo(string[] Info_str){
		//for(int i=0;i < Info_str.Length;i++) print(Info_str[i]);

		for(int i=0;i < Info_str.Length;i++){
			/*
			string[] temp = null;
			temp = Info_str[i].Split(new char[] { ',' }); //"-"為每次死亡所存取的數值區格											
			for(int j=0;j<temp.Length;j++) print(temp[j]);*/

			int[] temp_int = null;
			temp_int = Array.ConvertAll(Info_str[i].Split(new char[]{','}),new Converter<String,int>(Convert.ToInt32));

			//for(int j=0;j<temp_int.Length;j++) print(temp_int[j]);

			/*
			for(int w=0;w < 10;w++){
				if( runeinfo[temp_int[0]][w][0] == 0){
					runeinfo[temp_int[0]][w][0] = -1;
					runeinfo[temp_int[0]][w][1] = temp_int[1];
					runeinfo[temp_int[0]][w][2] = temp_int[2];
					runeinfo[temp_int[0]][w][3] = temp_int[3];
					break;
				}
			}


			Debug.Log(temp_int[0]); 
			Debug.Log(temp_int[1]); 
			Debug.Log(temp_int[2]); 
			Debug.Log(temp_int[3]); 
			*/

		}

	}

}
