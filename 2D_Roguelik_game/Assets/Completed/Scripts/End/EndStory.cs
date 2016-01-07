using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndStory : MonoBehaviour {

	//story texts
	public GameObject storytext1;
	public GameObject storytext2;
	public GameObject storytext3;
	public Text storypoem;

	//poem
	private bool poemstartflag = false;
	public float PoemMoveV = 30;

	//time
	private float Timer = 0;
	private int lastTime = 0;

	//Audio
	public AudioSource EndSong;

	// Use this for initialization
	void Start () {

		storypoem.text =  "魚 要如何理解 天空?\n\n";

		storypoem.text += "鳥 要如何理解 海洋?\n\n\n";


		storypoem.text += "風 要如何理解 盤根?\n\n";

		storypoem.text += "樹 要如何理解 遠方?\n\n\n";


		storypoem.text += "人 要如何理解 永恆?\n\n";

		storypoem.text += "神 要如何理解 死亡?\n\n\n";


		storypoem.text += "花 要如何理解 困厄?\n\n\n\n\n\n\n\n\n\n\n";











		storypoem.text += "你 要如何理解 我們?\n\n\n\n\n\n\n\n\n";






		storypoem.text += "E N D\n\n";
	}
	
	// Update is called once per frame
	void Update () {
		Timer = Time.time;
		if(lastTime != (int)Timer){
			storytime();
			lastTime = (int)Timer;
		}

		if(poemstartflag){
			storypoem.transform.position = Vector3.MoveTowards(storypoem.transform.position,new Vector3(storypoem.transform.position.x,1000,0),PoemMoveV *  Time.deltaTime);
		}
	}

	void storytime(){
		
		switch((int)Timer){
		case 3:
			storytext1.GetComponent<InfoOutput>().AddStringToQue("走了出去，卻是一片漆黑",1);
			break;
		case 8:
			storytext2.GetComponent<InfoOutput>().AddStringToQue("那個聲音問道",1);
			break;
		case 10:
			storytext3.GetComponent<InfoOutput>().AddStringToQue("你的手為何沾滿了鮮血呢?",1);
			EndSong.Play();
			break;
		case 15:
			storytext1.GetComponent<InfoOutput>().AddStringToQue("在黑暗中看不見雙手...",1);
			break;
		case 20:
			storytext2.GetComponent<InfoOutput>().AddStringToQue("那個聲音的問道",1);
			break;
		case 22:
			storytext3.GetComponent<InfoOutput>().AddStringToQue("你能理解他們為何朝聖嗎?",1);
			break;
		case 27:
			storytext1.GetComponent<InfoOutput>().AddStringToQue("在無光之處看不見他們的屍體...",1);
			break;
		case 32:
			storytext2.GetComponent<InfoOutput>().AddStringToQue("那個聲音沒有再問任何問題了",1);
			break;
		case 36:
			storytext1.GetComponent<InfoOutput>().AddStringToQue("他們開始吟唱",1);
			break;
		case 39:
			storytext1.GetComponent<InfoOutput>().AddStringToQue("那是一首詩歌",1);
			break;
		case 45:
			poemstartflag = true;
			break;
			/*
		case 45:
			storypoem.text = "魚要如何理解天空?\n\n";
			break;
		case 48:
			storypoem.text += "鳥要如何理解海洋?\n\n";
			break;
		case 52:
			storypoem.text += "風要如何理解盤根?\n\n";
			break;
		case 55:
			storypoem.text += "樹要如何理解遠方?\n\n";
			break;
		case 59:
			storypoem.text += "人要如何理解永恆?\n\n";
			break;
		case 62:
			storypoem.text += "神要如何理解死亡?\n\n";
			break;
		case 66:
			storypoem.text += "花要如何理解困厄?\n\n";
			break;
		case 69:
			storypoem.text += "你要如何理解我們?\n\n";
			break;		
			*/
		}
	}
}
















