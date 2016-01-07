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
	//public static int[,] runeinfo = new int[50,20];
	public static int[] levelrune = new int[20];
    //public static int DieCount = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}


	public static void load(){


		//檔案讀取
		theSourceFile = new FileInfo("levelrune.txt");
		streamReader = theSourceFile.OpenText();

        if (text != null)
		{
			//ReadToEnd:可以將文件從頭讀到尾
			//ReadLine:只可讀取文件的一行文字
			text = streamReader.ReadToEnd();
            //print(text);
			/*
            DieCount = 1;
            for (int temp = 0; temp < text.Length; temp++)
            {
                if (text[temp] == ';')
                {
                    DieCount++;
                }
            }

            string[] textTemp = text.Split(new char[] { ';' }); //";"為每一個死亡次數的區隔
			*/

			//LoadRuneInfo(textTemp);
			LoadRuneInfo();
		}
		streamReader.Close ();

	}
	//int level,int posX,int posY,int runeID
	/*
	public static void SaveFile(int level,int posX,int posY,int runeID){
		//print(text);

		StreamWriter writer = new StreamWriter("levelrune.txt");

		//print(level +","+ posX +","+ posY+","+runeID);
		//text = text +";"+ level.ToString() +","+ posX.ToString() +","+ posY.ToString() +","+runeID.ToString();

		//text[level] = Convert.ToChar(runeID);
		string temp = "";

		for(int i=0;i<text.Length;i++){
			if(i == level){
				temp += (runeID+1);
			}else{
				temp += text[i];
			}
		}	
		print(temp);
		text = temp;

		writer.Write(text);
		writer.Close();
		writer.Dispose();
	}*/

	//public static void LoadRuneInfo(string[] Info_str){
	public static void LoadRuneInfo(){
		for(int i=1;i < text.Length;i++){
			//string tempstring;
			//tempstring[0] = text[i-1];
			levelrune[i] = Convert.ToInt32(text[i]-1)-47;

		}



		//for(int i=0;i < Info_str.Length;i++) print(Info_str[i]);

		//init array runeinfo
		/*for(int m = 0;m<20;m++)
			for(int n = 0;n<20;n++)
				runeinfo[m,n] = -1;*/
		/*
		for(int i=0;i < Info_str.Length;i++){*/
			/*
			string[] temp = null;
			temp = Info_str[i].Split(new char[] { ',' }); //"-"為每次死亡所存取的數值區格									
			for(int j=0;j<temp.Length;j++) print(temp[j]);*/
		/*
			int[] temp_int = null;
			temp_int = Array.ConvertAll(Info_str[i].Split(new char[]{','}),new Converter<String,int>(Convert.ToInt32));
*/
            //for(int j=0;j<temp_int.Length;j++) print(temp_int[j]);

            //DieCount++;
		/*
			runeinfo[temp_int[0],0] 	=  temp_int[1];
			runeinfo[temp_int[0],1]		=  temp_int[2];
			runeinfo[temp_int[0],2] 	=  temp_int[3];
                   
*/

		}
        /*
		for(int i = 0;i<20;i++)
			for(int j = 0;j<20;j++)
				print(i +","+ j +":" +runeinfo[i,j]);
		*/
       // print(DieCount);
        //PlayerPrefs.SetInt("DieCount", (DieCount+1));
    //}

}
