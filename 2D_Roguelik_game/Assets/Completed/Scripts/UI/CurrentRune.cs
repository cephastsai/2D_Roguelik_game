using UnityEngine;
using System.Collections;

public class CurrentRune : MonoBehaviour {

	private int runeID;

	void OnMouseDown(){
		runeID = Story.rune;

		switch(runeID){
		case 1:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("要把這個圖騰放到哪裡呢?",2);
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("可以增加三個道具",2);
			break;
		case 2:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("要把這個圖騰放到哪裡呢?",2);
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("可以讓體力增加了20%",2);
			break;
		case 3:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("要把這個圖騰放到哪裡呢?",2);
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("可以讓增體力加了30",2);
			break;
		case 4:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("要把這個圖騰放到哪裡呢?",2);
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("可以讓所有障礙物都不見!",2);
			break;
		case 5:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("要把這個圖騰放到哪裡呢?",2);
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("可以讓所有敵人都消失!",2);
			break;
		case 6:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("要把這個圖騰放到哪裡呢?",2);
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("可以拿到所有道具!",2);
			break;
		}


	}
}
