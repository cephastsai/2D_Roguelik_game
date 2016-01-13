using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Story : MonoBehaviour {

	//Set GameObject
	public GameObject Player = null;
	public TextIInfoOutput InfoOutput = null;
	public MagicCircle magiccircle = null;

	//Set Varible
	public static int Level = 1;

	//Set temp bool
	private bool firstflag = true;
	private bool secondflag = true;

	void Update(){
		if(Level > 4){
			//first
			if(Player.transform.position.x + Player.transform.position.y == 1 && firstflag){
				
				InfoOutput.AddStringToQue("躺在這個墳墓中的朝聖者追求的是什麼呢?",3);
				//flag
				firstflag = false;
			}


			//second
			if(magiccircle.OverActivate && secondflag){

				switch(Level){
				case 5:
					InfoOutput.AddStringToQue("有個聲音回答道:霍伊特啊，它追求的是永生",3);
					break;
				case 6:
					InfoOutput.AddStringToQue("有個聲音回答道:米爾寇啊，祂追求的是榮耀",3);
					break;
				case 7:
					InfoOutput.AddStringToQue("有個聲音回答道:托斯卡啊，他追求的是勝利",3);
					break;
				case 8:
					InfoOutput.AddStringToQue("有個聲音回答道:維吉爾啊，他追求的是真理",3);
					break;
				case 9:
					InfoOutput.AddStringToQue("有個聲音回答道:拉密亞啊，她追求的是真愛",3);
					break;
				case 10:
					InfoOutput.AddStringToQue("有個聲音回答道:亞刃啊，他追求的是自我",3);
					break;
				}

				//flag
				secondflag = false;
			}

		}

		

	}
}
