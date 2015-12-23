using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	private int level;

	void OnMouseDown(){
		level = Story.Level;

		switch(level){
		case 1:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("頭好痛!",2);
			break;
		case 2:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("頭還是暈暈的...",2);
			break;
		case 3:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("真不知道我在哪裡",2);
			break;
		case 4:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("頭好多了，不會暈了",2);
			break;
		case 5:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("這邊讓我心裡蠻平靜的",2);
			break;
		case 6:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("好像有什麼事我忘記了",2);
			break;
		case 7:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("到底我忘了什麼事呢?",2);
			break;
		case 8:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("感覺心中好像缺了什麼東西",2);
			break;
		case 9:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("我忘了什麼?一想頭又開始痛了...",2);
			break;

		}

	}

}
