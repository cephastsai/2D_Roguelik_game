using UnityEngine;
using System.Collections;
using System;

public class Exit : MonoBehaviour {

	void OnMouseDown(){
		int temp;
		temp = (int)Math.Floor( (double)UnityEngine.Random.Range(1f,4f) );

		switch(temp){
		case 1:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("看來這個就是出口了",2);
			break;
		case 2:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("那邊有風，我應該是要往那邊走",2);
			break;
		case 3:
			GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("這個出口會通到哪裡呢?",2);
			break;
		}

	}

	void OnMouseEnter(){
		Instantiate (Resources.Load("Prefabs/ExitFXVer2",typeof(GameObject)), this.transform.position, Quaternion.Euler(180, 180, 0));
	}

	void OnMouseExit(){
		Destroy(GameObject.Find("ExitFXVer2(Clone)"));
	}

	public void InsExit(){
		Instantiate (Resources.Load("Prefabs/ExitFXVer2",typeof(GameObject)), this.transform.position, Quaternion.Euler(180, 180, 0));
	}


}
