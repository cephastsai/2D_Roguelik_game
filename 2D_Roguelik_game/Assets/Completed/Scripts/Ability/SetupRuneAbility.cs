using UnityEngine;
using System.Collections;

public class SetupRuneAbility : MonoBehaviour {


	//start time boolean
	public static bool startgame = false;
	public static bool endgame = false;
	public static bool gameover = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init(int runeID){

		switch(runeID){
			case 1:
				if(gameObject.GetComponent<MoreFoodInBoard>() == null){
					gameObject.AddComponent<MoreFoodInBoard> ();
				}
				break;

			case 2:
				if(gameObject.GetComponent<AddFoodPercentage>() == null){
					gameObject.AddComponent<AddFoodPercentage> ();
				}
				break;
			case 3:
				if(gameObject.GetComponent<AddFood>() == null){
					gameObject.AddComponent<AddFood> ();
				}
				break;
			case 4:
				if(gameObject.GetComponent<CleanWall>() == null){
					gameObject.AddComponent<CleanWall> ();
				}
				break;
		}

	}
}
