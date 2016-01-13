using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Newhand : MonoBehaviour {

	//is Newhead run?
	public static bool Newhandflag = true;

	//Set GameObject 
	public GameObject BG = null;
	public Text text = null;
	public GameObject arrow = null;
	public GameObject arrowhead = null;
	public GameObject player = null;
	private GameObject gameMamager = null;
	public TextIInfoOutput InfoOutput = null;
	public GameObject RuneManager = null;

	//Set Varible
	private int level;
	public static bool isPlayerCantMove = true;
	private Vector3 PlayerCantMovePosition;
	private bool Newhandstart = false;
	public bool ExitOn = true;

	//Mission GameObject
	private GameObject MissionFood = null;
	public MagicCircle magiccircle = null;

	//Mission Varible
	public bool Mission_GotFood = false;
	public bool MagicCircleOn = true;

	//mission section
	public enum MissionSection
	{
		Null,
		Start, 
		FirstTlak, 
		FirstTalkEnd,
		ShowEnergyUI,
		GetEnergyText,
		KeyBoard,
		GetFood,
		GetFoodEnd,
		Rune1,
		Rune2,
		Rune3,
		RuneAbility,
		RuneAbilityTalk,
		MagicCircle,
		MagicCirCleTalk,
		MagicCirCleTalkEnd,
		MagicCirCle1,
		MagicCirCleMission,
		MagicCirCleMission2,
		MagicCirCle2,
		MagicCirCle3,
		Exit,
		End
	
	};

	public MissionSection Section = MissionSection.Start;
	public MissionSection LastSection ;//= MissionSection.Null;
	private bool missionflag = false;

	//Timer
	private float Timer;

	//Mouse
	private int MouseClickNum = 0;
	private int LastMouseClickNum = 0;

	void init(){
		//set
		gameMamager = GameObject.Find("GameManager(Clone)");
		level = gameMamager.GetComponent<Completed.GameManager>().getlevel();

		//destroy rune ability 1
		RuneManager = GameObject.Find("RuneAbilityManager");
		if(RuneManager.GetComponent<MoreFoodInBoard>() != null){
			Destroy(RuneManager.GetComponent<MoreFoodInBoard>());
		}

		//Set Varible
		MagicCircleOn = false;
		ExitOn = false;
	}

	void Start(){
		if(Newhandflag){
			//set
			init ();
			
			//start
			NewhandMission();
		}
	}

	void Update(){

		//Mission Section Search
		if(Newhandstart){
			MissionSectionSearch();
		}	

		//Section change (trigger)
		if(Section != LastSection && !missionflag){
			print("[MissionSection]" + Section + "["+ (int)Section +"]");
			missionflag = true;
			LastSection = Section;
		}

		//pass mission
		if(Input.GetKeyDown("p")){
			Section = MissionSection.End;
		}

	}

	void NewhandMission(){

		//start newhead setting
		Newhandstart = true;
		isPlayerCantMove = true;
		Section = MissionSection.Start;

		//set Image
		gameMamager.GetComponent<Completed.GameManager>().SetStarrtImage();
	}

	void MissionSectionSearch(){

		//MissionSection case
		switch(Section){

		case MissionSection.Start:
			if(missionflag){
				//just start
				Section = MissionSection.FirstTlak;

				//flag
				missionflag = false;
			}
			break;
			//=================================================================================================
		case MissionSection.FirstTlak:

			if(missionflag){
				//InfoOutput
				InfoOutput.AddStringToQue("這裡是哪裡?",3);
				InfoOutput.AddStringToQue("我為什麼在這裡?",3);
				InfoOutput.AddStringToQue("看來我應該要好好觀察一下四周",3);


				Section = MissionSection.FirstTalkEnd;
				//flag
				missionflag = false;
			}

			break;
			//=================================================================================================
		case MissionSection.FirstTalkEnd:
			//all talk Done
			if(InfoOutput.InfoListClean && missionflag){
				//Timer on
				Timer = Time.time;

				//flag
				missionflag = false;
			}
			//print(Time.time - Timer);

			if(Time.time - Timer > 5f && !missionflag){
				Section = MissionSection.ShowEnergyUI;
			}
			break;
			//=================================================================================================
		case MissionSection.ShowEnergyUI:
		
			if(missionflag){
				ShowText();
				text.text = "這是我的體力條，\n我可不想要沒有體力而死掉\n[點擊繼續]";
				arrowhead = (GameObject)Instantiate(arrow,new Vector3(-2.67f,2.56f,0f),Quaternion.identity);

				//set mouse chick
				LastMouseClickNum = MouseClickNum;

				//flag
				missionflag = false;
			}

			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Section = MissionSection.GetEnergyText;
				Destroy(arrowhead);
			}

			break;
			//=================================================================================================
		case MissionSection.GetEnergyText:
			if(missionflag){
				text.text = "四周有光球可以補充我的體力，\n應該快點去蒐集光球\n[點擊繼續]";

				arrowhead = (GameObject)Instantiate(arrow,GetCloseFood(),Quaternion.identity);
				arrowhead.transform.position = new Vector3(arrowhead.transform.position.x +1.3f, arrowhead.transform.position.y, arrowhead.transform.position.z);

				//set mouse chick
				LastMouseClickNum = MouseClickNum;

				//flag
				missionflag = false;
			}

			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Section = MissionSection.KeyBoard;
			}
			break;
			//=================================================================================================
		case MissionSection.KeyBoard:
			if(missionflag){
				text.text = "使用 W、A、S、D 慢慢的前進好了\n[點擊繼續]";
				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				HideText();
				isPlayerCantMove = false;
				Section = MissionSection.GetFood;
			}
			break;
			//=================================================================================================
		case MissionSection.GetFood:
			if(missionflag && Mission_GotFood){
				Destroy(arrowhead);
				isPlayerCantMove = true;

				Section = MissionSection.GetFoodEnd;
				//flag
				missionflag = false;
			}
			break;
			//=================================================================================================
		case MissionSection.GetFoodEnd:
			if(missionflag){
				text.text = "這個聲音?莫非是符紋!\n[點擊繼續]";
				ShowText();

				//set mouse chick
				LastMouseClickNum = MouseClickNum;

				//flag
				missionflag = false;
			}

			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Section = MissionSection.Rune1;
			}

			break;
			//=================================================================================================
		case MissionSection.Rune1:
			if(missionflag){
				text.text = "這裡看起來是這關的符紋，\n繼續走下去每關應該都不一樣才對\n[點擊繼續]";
				arrowhead = (GameObject)Instantiate(arrow,new Vector3(-1.58f,7.42f,0f),Quaternion.identity);
				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Destroy(arrowhead);

				Section = MissionSection.Rune2;
			}
			
			break;
			//=================================================================================================
		case MissionSection.Rune2:
			if(missionflag){
				text.text = "這邊顯示了這關符文的能力，\n我應該要好好運用\n[點擊繼續]";
				arrowhead = (GameObject)Instantiate(arrow,new Vector3(-0.66f,6.14f,0f),Quaternion.identity);
				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Destroy(arrowhead);

				Section = MissionSection.Rune3;
			}
			
			break;
			//=================================================================================================
		case MissionSection.Rune3:
			if(missionflag){
				text.text = "才剛講完符紋就發動了\n[點擊繼續]";
				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Destroy(arrowhead);
				HideText();

				Section = MissionSection.RuneAbility;
			}
			
			break;
			//=================================================================================================
		case MissionSection.RuneAbility:
			if(missionflag){						
				RuneManager.AddComponent<MoreFoodInBoard>().moreFoodInBoard();

				//Timer on
				Timer = Time.time;

				//flag
				missionflag = false;
			}

			if(Time.time - Timer > 3f && !missionflag){
				Section = MissionSection.RuneAbilityTalk;
			}

			break;
			//=================================================================================================
		case MissionSection.RuneAbilityTalk:
			if(missionflag){
				text.text = "多了三顆光球，也是不錯\n[點擊繼續]";
				ShowText();
				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Section = MissionSection.MagicCirCleTalk;
			}
			
			break;
			//=================================================================================================
		case MissionSection.MagicCirCleTalk:
			
			if(missionflag){
				text.text = "符紋陣!\n這個東西雖然古遠...我倒是會操作\n[點擊繼續]";
				arrowhead = (GameObject)Instantiate(arrow,new Vector3(5.33f,3.52f,0f),Quaternion.identity);
				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;

				//flag
				missionflag = false;
			}

			if(LastMouseClickNum != MouseClickNum && !missionflag){				
				Section = MissionSection.MagicCirCle1;
			}
			
			break;
			//=================================================================================================		
		case MissionSection.MagicCirCle1:
			if(missionflag){
				text.text = "站到符紋陣上，\n啟動它吧!\n[點擊繼續]";

				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				isPlayerCantMove = false;
				HideText();
				MagicCircleOn = true;
				
				Section = MissionSection.MagicCirCleMission;
			}
			
			break;
			//=================================================================================================
		case MissionSection.MagicCirCleMission:
			if(magiccircle.ToActivateFlag && missionflag){
				isPlayerCantMove = true;
				Destroy(arrowhead);

				Section = MissionSection.MagicCirCleMission2;

				//flag
				missionflag = false;
			}					
			break;
			//=================================================================================================
		case MissionSection.MagicCirCleMission2:
			if(magiccircle.OverActivate && missionflag){

				Section = MissionSection.MagicCirCle2;	

				//flag
				missionflag = false;
			}					
			break;
			//=================================================================================================
		case MissionSection.MagicCirCle2:
			if(missionflag){
				text.text = "看來這關的符紋被我啟動了!\n[點擊繼續]";
				ShowText();
				arrowhead = (GameObject)Instantiate(arrow,new Vector3(-1.38f,-0.84f,0f),Quaternion.identity);
				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Destroy(arrowhead);
				
				Section = MissionSection.MagicCirCle3;
			}
			
			break;
			//=================================================================================================
		case MissionSection.MagicCirCle3:
			if(missionflag){
				text.text = "只要把所有符紋都啟動，\n就可以知道我出現在這的原因了吧\n[點擊繼續]";
				arrowhead = (GameObject)Instantiate(arrow,new Vector3(-1.29f,2.53f,0f),Quaternion.identity);

				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Destroy(arrowhead);
				
				Section = MissionSection.Exit;
			}
			
			break;
			//=================================================================================================
		case MissionSection.Exit:
			if(missionflag){
				text.text = "好吧，朝出口前進吧\n[點擊繼續]";
				arrowhead = (GameObject)Instantiate(arrow,new Vector3(5.52f,6.95f,0f),Quaternion.Euler(0,0,180));
				
				//set mouse chick
				LastMouseClickNum = MouseClickNum;
				
				//flag
				missionflag = false;
			}
			
			if(LastMouseClickNum != MouseClickNum && !missionflag){
				Destroy(arrowhead);
				HideText();
				isPlayerCantMove = false;
				ExitOn = true;
				
				Section = MissionSection.End;
			}
			
			break;
			//=================================================================================================
		case MissionSection.End:
			if(missionflag){

				//Newhand END set flag
				Newhandflag = false;		

				//Set all varible
				Destroy(arrowhead);
				HideText();
				isPlayerCantMove = false;
				ExitOn = true;
				InfoOutput.ClearQue();

				//RunAbility for PassMission
				if(RuneManager.GetComponent<MoreFoodInBoard>() == null){
					RuneManager.AddComponent<MoreFoodInBoard>().moreFoodInBoard();
				}

				//flag
				missionflag = false;
			}
			
			break;
			//=================================================================================================
		}
	}



	//=================================================================================================
	void ShowText(){
		BG.GetComponent<SpriteRenderer>().enabled = true;
		text.gameObject.SetActive(true);
	}

	void HideText(){
		BG.GetComponent<SpriteRenderer>().enabled = false;
		text.gameObject.SetActive(false);
	}

	void OnMouseDown(){
		MouseClickNum++;
	}

	Vector3 GetCloseFood(){

		//varible
		float XYsum = 20;

		//Close position
		Vector3 ClosePosition = new Vector3();

		//Get Food
		GameObject[] Food;
		GameObject[] Soda;
		Food = GameObject.FindGameObjectsWithTag("Food");
		Soda = GameObject.FindGameObjectsWithTag("Soda");
				
		//Search
		for(int i=0;i<Food.Length;i++){
			if(Food[i].transform.position.x + Food[i].transform.position.y < XYsum){
				XYsum = Food[i].transform.position.x +Food[i].transform.position.y;
				ClosePosition = Food[i].transform.position;
				MissionFood = Food[i];
			}

		}
		
		for(int i=0;i<Soda.Length;i++){
			if(Soda[i].transform.position.x + Soda[i].transform.position.y < XYsum){
				XYsum = Soda[i].transform.position.x +Soda[i].transform.position.y;
				ClosePosition = Soda[i].transform.position;
				MissionFood = Soda[i];
			}
		}

		return ClosePosition;
	}
}












