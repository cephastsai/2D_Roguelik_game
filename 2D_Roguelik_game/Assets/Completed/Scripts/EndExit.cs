using UnityEngine;
using System.Collections;

public class EndExit : MonoBehaviour {

	private float Timer = 0f;
	public GameObject BG = null;
	private bool endflag = false;
	private bool endflag1 = false;
	public AudioSource Music;
	private float Musicvalue = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - Timer > 10f && endflag){
			Instantiate(BG,new Vector3(0,0,0),Quaternion.identity);
			endflag =false;
		}

		if(Time.time - Timer > 13f && endflag1){
			DestoryGameObject();
			endflag1 = false;
		}

		if(Music != null && Time.time - Timer > 8f && endflag1){
			Musicvalue -= 0.006f;
			Music.volume = Musicvalue;
		}
	}

	public void EndingExit(){
		Newhand.isPlayerCantMove = true;
		Timer = Time.time;
		endflag = true;
		endflag1 = true;
		Music = GameObject.Find("SoundManager(Clone)").GetComponent<AudioSource>();
		GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("終於到了最後的出口",3);
		GameObject.Find("StoryInfoBG").GetComponent<TextIInfoOutput>().AddStringToQue("我走了進去",3);
	}

	void DestoryGameObject(){
		Instantiate(BG,new Vector3(0,0,0),Quaternion.identity);
		Destroy(GameObject.Find("GameManager(Clone)"));
		Destroy(GameObject.Find("SoundManager(Clone)"));
		Destroy(GameObject.Find("InterFace"));
		Application.LoadLevel ("End");
	}
}
