﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

namespace Completed
{
	using System.Collections.Generic;		//Allows us to use Lists. 
	using UnityEngine.UI;					//Allows us to use UI.
	
	public class GameManager : MonoBehaviour
	{
		//1
		public float levelStartDelay = 2f;						//Time to wait before starting level, in seconds.
        public float gameEndDelay = 5f;                         //Time to wait before change Main scene to End scene, in seconds.
        public float turnDelay = 0.1f;							//Delay between each Player turn.
		public int playerFoodPoints = 100;						//Starting value for Player food points.
        public int playerMaxFoodPoint = 100;
		public static GameManager instance = null;				//Static instance of GameManager which allows it to be accessed by any other script.
		/*[HideInInspector] */public bool playersTurn = false;       //Boolean to check if it's players turn, hidden in inspector but public.

        public int starve;
        public int max;
		
		private Text levelText;									//Text to display current level number.
        private Text maxpointText;
        private Text pointText;
        private GameObject levelImage;							//Image to block out level as levels are being set up, background for levelText.
		private BoardManager boardScript;						//Store a reference to our BoardManager which will set up the level.
        private SceneManager SceneManager;
        private int level = 1;									//Current level number, expressed in game as "Day 1".
		public List<Enemy> enemies;							//List of all Enemy units, used to issue them move commands.
		private bool enemiesMoving;								//Boolean to check if enemies are moving.
		private bool doingSetup = true;                         //Boolean to check if we're setting up board, prevent Player from moving during setup.
        private bool gameover_flag = true;
		private Image canvasBGImage = null;

        private FileInfo theSourceFile = null;
        private StreamReader StreamReader = null;
        private string text = " ";

		private float PlayerBornTime;
		private bool PlayerBornTimeSetup = false;



        //Awake is always called before any Start functions
        void Awake()
		{
			//Debug.Log ("Awake");
            
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this){

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy(gameObject);
			}
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            //Assign enemies to a new List of Enemy objects.
            enemies = new List<Enemy>();

			gameObject.AddComponent<InformationReaderCs>();

			InformationReaderCs.load();

            //Get a component reference to the attached BoardManager script
            boardScript = GetComponent<BoardManager>();

			gameObject.AddComponent<Story>().init();

            //Call the InitGame function to initialize the first level 
            InitGame();	

			SetupRuneAbility.startgame = true;
            		 
        }

		void Start(){

		}

		
		//This is called each time a scene is loaded.
		void OnLevelWasLoaded(int index) //當場景載入就不會執行(loader>gamemanager)
		{
			if (SceneManager.menu_flag == false){
				//Add one to our level number.
				level++;
				//print(level);
				
				//Call InitGame to initialize our level.
				InitGame();
			}
           
			Story.Level = level;
            SceneManager.menu_flag = false;
        }
		
		//Initializes the game for each level.
		void InitGame() 
		{
			//While doingSetup is true the player can't move, prevent player from moving while title card is up.
			doingSetup = true;
			playersTurn = false;
			//Player.runed = false;

			//Get a reference to our image LevelImage by finding it by name.
			levelImage = GameObject.Find("LevelImage");
			//bug 001
			canvasBGImage = levelImage.GetComponent<Image>();
			canvasBGImage.sprite = (Sprite)Resources.Load("blackBG",typeof(Sprite));

			//Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
			levelText = GameObject.Find("LevelText").GetComponent<Text>();
            maxpointText = GameObject.Find("MaxPointText").GetComponent<Text>();
            //pointText = GameObject.Find("PointText").GetComponent<Text>();

            //Set the text of levelText to the string "Day" and append the current level number.
			print(level);
            levelText.text = "Day : " + level;
			levelImage.transform.GetChild(0).GetComponent<Text>().text = "Day  " + level;
			
			//Set levelImage to active blocking player's view of the game board during setup.
			levelImage.SetActive(true);
			
			//Call the HideLevelImage function with a delay in seconds of levelStartDelay.
			Invoke("HideLevelImage", levelStartDelay);
			
			//Clear any Enemy objects in our List to prepare for next level.
			enemies.Clear();
			
			//Call the SetupScene function of the BoardManager script, pass it current level number.
			boardScript.SetupScene(level);
        }

        //Hides black image used between levels
        void HideLevelImage()
		{
			//Disable the levelImage gameObject.
			levelImage.SetActive(false);

			PlayerBornTime = Time.time;
			PlayerBornTimeSetup = false;
			Instantiate (Resources.Load("Prefabs/CharacterBornFXVer2",typeof(GameObject)), this.transform.position, Quaternion.identity);
			GameObject.Find("CharacterBornFXVer2(Clone)").AddComponent<SelfDestroyCS>().SetDestroyTime(1.2f);
			//Set doingSetup to false allowing player to move again.

		}
		
		//Update is called every frame.
		void Update()
		{
			if(Time.time - PlayerBornTime >= 1.5f && !PlayerBornTimeSetup && !levelImage.activeInHierarchy){
				//print("go");
				doingSetup = false;
				playersTurn = true;
				PlayerBornTimeSetup = true;
			}

			//levelText.text = "Day " + level;
			//Check that playersTurn or enemiesMoving or doingSetup are not currently true.
			if(playersTurn || enemiesMoving || doingSetup)
				
				//If any of these are true, return and do not start MoveEnemies.
				return;
			
			//Start moving enemies.
			StartCoroutine (MoveEnemies ());
		}
		
		//Call this to add the passed in Enemy to the List of Enemy objects.
		public void AddEnemyToList(Enemy script)
		{
			//Add Enemy to List enemies.
			enemies.Add(script);
		}
		
		
		//GameOver is called when the player reaches 0 food points
		public void GameOver()
		{
            //Set levelText to display number of levels passed and game over message
            //levelText.text = "After " + level + " days, you starved.";
            //maxpointText.text = "Max point: " + playerMaxFoodPoint;


			//InformationReaderCs.SaveFile(level,(int)player.transform.position.x,(int)player.transform.position.y,0);

            //Enable black background image gameObject.
            levelImage.SetActive(true);
			
			//Disable this GameManager.
			enabled = false;

            gameover_flag = false;

            SceneManager.menu_flag = true;

            //Destroy(this);
			Destroy(gameObject);

            GetKey();

            //return;
            Application.LoadLevel("End");
        }

        void GetKey()
        {
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.SetInt("playerMaxFoodPoint", playerMaxFoodPoint);
        }

        //Coroutine to move enemies in sequence.
        IEnumerator MoveEnemies()
		{
			//While enemiesMoving is true player is unable to move.
			enemiesMoving = true;
			
			//Wait for turnDelay seconds, defaults to .1 (100 ms).
			yield return new WaitForSeconds(turnDelay);
			
			//If there are no enemies spawned (IE in first level):
			if (enemies.Count == 0) 
			{
				//Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
				yield return new WaitForSeconds(turnDelay);
			}
			
			//Loop through List of Enemy objects.
			for (int i = 0; i < enemies.Count; i++)
			{
				//Call the MoveEnemy function of Enemy at index i in the enemies List.
				enemies[i].MoveEnemy ();
				
				//Wait for Enemy's moveTime before moving next Enemy, 
				yield return new WaitForSeconds(enemies[i].moveTime);
			}
			//Once Enemies are done moving, set playersTurn to true so player can move.
			playersTurn = true;
			
			//Enemies are done moving, set enemiesMoving to false.
			enemiesMoving = false;
		}

		public int getlevel(){
			return level;
		}
	}
}

