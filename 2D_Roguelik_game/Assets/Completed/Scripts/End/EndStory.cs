using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndStory : MonoBehaviour {

	public GameObject EndImage;
	private bool endimageflag = false;

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
	private float startTime = 0;

	//Audio
	public AudioSource EndSong;
	private float Songvolume = 0.1f;
	private bool SongStart = false;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

		EndSong.volume = 0.1f;

		//=======================================================================
		storypoem.text =  "魚 要如何理解 天空?\n\n";

		storypoem.text += "鳥 要如何理解 海洋?\n\n\n";


		storypoem.text += "風 要如何理解 盤根?\n\n";

		storypoem.text += "樹 要如何理解 遠方?\n\n\n";


		storypoem.text += "人 要如何理解 永恆?\n\n";

		storypoem.text += "神 要如何理解 死亡?\n\n\n";


		storypoem.text += "花 要如何理解 困厄?\n\n\n\n\n\n\n\n\n\n\n";










		storypoem.text += "你 要如何理解 我們?\n\n\n\n\n\n\n\n\n\n\n";
		//storypoem.text += "\n\n\n\n\n\n\n\n\n\n\n";






		storypoem.text += "\n\n\n\n\n\n\n\n\n\n\n";

		//~~~~~~
		storypoem.text +="Lair:grim split製作團隊\n\n\n\n\n";

		storypoem.text +="企劃 : 蔡元泓\n\n";

		storypoem.text +="      胡又臻\n\n\n";

		storypoem.text +="程式 : 蔡元泓\n\n";
		
		storypoem.text +="      莊承欣\n\n";

		storypoem.text +="      張求凱\n\n\n";

		storypoem.text +="美術 : 利冠鳳\n\n";
		
		storypoem.text +="      胡又臻\n\n";
		
		storypoem.text +="特效 : 張求凱\n\n\n";

		storypoem.text +="指導老師 : 謝承勳老師\n\n\n\n\n\n\n\n";

		storypoem.text +="背景音樂 : \n\n\n";

		storypoem.text +="遊戲開始畫面\n\n";

		storypoem.text +="\"Deep Haze\" Kevin MacLeod (incompetech.com) \n";
		storypoem.text +="Licensed under Creative Commons: By Attribution 3.0\n";
		storypoem.text +="http://creativecommons.org/licenses/by/3.0/";


		storypoem.text +="\n\n\n";
		storypoem.text +="遊戲中\n\n";
		
		storypoem.text +="\"Tenebrous Brothers Carnival - Mermaid\" Kevin MacLeod (incompetech.com) \n";
		storypoem.text +="Licensed under Creative Commons: By Attribution 3.0\n";
		storypoem.text +="http://creativecommons.org/licenses/by/3.0/";


		storypoem.text +="\n\n\n";
		storypoem.text +="結局\n\n";
		
		storypoem.text +="\"Darkness is Coming\" Kevin MacLeod (incompetech.com)  \n";
		storypoem.text +="Licensed under Creative Commons: By Attribution 3.0\n";
		storypoem.text +="http://creativecommons.org/licenses/by/3.0/";
		storypoem.text +="\n\n\n\n\n\n\n\n\n\n\n\n";
		storypoem.text +="Thank You";
	

		//=======================================================================
	}
	
	// Update is called once per frame
	void Update () {
		Timer = Time.time;
		if(lastTime != (int)Timer){
			storytime();
			lastTime = (int)Timer;
		}

		if(SongStart && Songvolume <= 0.35){
			Songvolume += 0.001f;
			EndSong.volume = Songvolume;
		}

		if(poemstartflag){
			storypoem.transform.position = Vector3.MoveTowards(storypoem.transform.position,new Vector3(storypoem.transform.position.x,10000,0),PoemMoveV *  Time.deltaTime);
		}

		if(endimageflag){
			EndImage.transform.position = Vector3.MoveTowards(EndImage.transform.position,new Vector3(EndImage.transform.position.x,10000,0), 0.4f*Time.deltaTime);
		}
	}

	void storytime(){

		print((int)Timer);
		switch((int)(Timer - startTime)){
		case 3:
			storytext1.GetComponent<InfoOutput>().AddStringToQue("我走了出去，卻是一片漆黑",1);
			break;
		case 8:
			storytext2.GetComponent<InfoOutput>().AddStringToQue("那個聲音問道:",1);
			break;
		case 10:
			storytext3.GetComponent<InfoOutput>().AddStringToQue("你的手為何沾滿了鮮血呢?",1);
			EndSong.Play();
			SongStart = true;
			break;
		case 15:
			storytext1.GetComponent<InfoOutput>().AddStringToQue("\"我在黑暗中看不見雙手...\"",1);
			break;
		case 20:
			storytext2.GetComponent<InfoOutput>().AddStringToQue("那個聲音的問道:",1);
			break;
		case 22:
			storytext3.GetComponent<InfoOutput>().AddStringToQue("你能理解他們為何朝聖嗎?",1);
			break;
		case 27:
			storytext1.GetComponent<InfoOutput>().AddStringToQue("\"我在無光之處看不見他們的屍體...\"",1);
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
		case 93:
			endimageflag = true;
			break;
		}
	}
}
















