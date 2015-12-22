using UnityEngine;
using System.Collections;

public class CurrentRune : MonoBehaviour {

	void OnMouseDown(){
		GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("hihi",2);
	}
}
