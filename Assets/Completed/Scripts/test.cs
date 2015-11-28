
using UnityEngine;
using System.Collections;

public class test: MonoBehaviour {
	
	Animator _mAnimator; //沒寫public 預設為 private
	
	void Start () 
	{
		// 先取得物件身上的 Aninator 組件，並存在自己是先宣告好的 Aninator變數中 ，為了之後方便快速取用，若要給別支script使用 ，就需要用到 public  / public static 
		_mAnimator = GetComponent<Animator> ();
	}
	
	void OnGUI()
	{
		if (GUILayout.Button ("Start Cube Move Act"))
		{
			//這邊在設定 Parameters 的變數 SetBool("Parameters變數名" , 依照Parameters 變數型態改變 )  (解釋 1)
			//以下四種型態 float 、 int 、 bool 、 trigger 
			_mAnimator.SetBool("Idle", false);  // 這邊可以看作為當不是Idle時，可以觀察到動畫會前進到 Move 並撥放
			
			//以下為剩下三種數值帶法 ， 請自行嘗試並觀察結果 。 Ps 需要自行在 Parameters 分別新增下面三種型態的 Parameters變數 ，並參考(解釋 1 嘗試使用)
			//_mAnimator.SetFloat("Idle", 1.1111);  
			//_mAnimator.SetInteger("Idle", 2);
			//_mAnimator.SetTrigger("Idle"); 
		}
		
		if (GUILayout.Button ("Start Cube Idle Act")) 
		{
			_mAnimator.SetBool("Idle",true); //反知
		}
		
	}
}