using UnityEngine;
using System.Collections;

public class LevelRuneText : MonoBehaviour {

	private UILabel label = null;

	private int level;
	private int Curlevel = 0;
	private int levelRune = 0;

	// Use this for initialization
	void Start () {
		label = gameObject.GetComponent<UILabel>();

		level = GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().getlevel();
	}
	
	// Update is called once per frame
	void Update () {
		level = GameObject.Find("GameManager(Clone)").GetComponent<Completed.GameManager>().getlevel();

		if(Curlevel != level){
			levelRune = InformationReaderCs.levelrune[level];
			RuneTextCahnge();
			Curlevel = level;
		}		
	}

	void RuneTextCahnge(){

		switch(levelRune){
		case 1:
			label.text = "增加三個光球!";
			break;
		case 2:
			label.text = "體力增加20%!";
			break;
		case 3:
			label.text = "體力增加30!";
			break;
		case 4:
			label.text = "清除障礙物!";
			break;
		case 5:
			label.text = "清除敵人!";
			break;
		case 6:
			label.text = "得到所有光球!";
			break;
		}
	}
}
