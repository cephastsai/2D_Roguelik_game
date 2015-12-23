using UnityEngine;
using System.Collections;
using System;

public class Grave : MonoBehaviour {

	void OnMouseDown(){
		int temp;
		temp = (int)Math.Floor( (double)UnityEngine.Random.Range(1f,4f) );
		
		switch(temp){
		case 1:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("這個是誰的墳墓呢?",2);
			break;
		case 2:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("上面的字都看不清楚了",2);
			break;
		case 3:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("這個墳墓有種熟悉個感覺",2);
			break;
		}
		
	}
}
