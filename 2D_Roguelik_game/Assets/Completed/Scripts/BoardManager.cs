﻿using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

namespace Completed
	
{
	
	public class BoardManager : MonoBehaviour
	{
		// Using Serializable allows us to embed a class with sub properties in the inspector.
		[Serializable]
		public class Count
		{
			public int minimum; 			//Minimum value for our Count class.
			public int maximum; 			//Maximum value for our Count class.
			
			
			//Assignment constructor.
			public Count (int min, int max)
			{
				minimum = min;
				maximum = max;
			}
		}
		
		
		public int columns = 8; 										//Number of columns in our game board.
		public int rows = 8;											//Number of rows in our game board.
		public Count wallCount = new Count (5, 9);						//Lower and upper limit for our random number of walls per level.
		public Count foodCount = new Count (1, 5);						//Lower and upper limit for our random number of food items per level.
		public GameObject exit;											//Prefab to spawn for exit.
		public GameObject[] floorTiles;									//Array of floor prefabs.
		public GameObject[] wallTiles;									//Array of wall prefabs.
		public GameObject[] foodTiles;									//Array of food prefabs.
		public GameObject[] enemyTiles;									//Array of enemy prefabs.
		public GameObject[] outerWallTiles;								//Array of outer tile prefabs.
		
		private Transform boardHolder;									//A variable to store a reference to the transform of our Board object.
		private List <Vector3> gridPositions = new List <Vector3> ();	//A list of possible locations to place tiles.
		private GameObject[] rune = new GameObject[10];
		private GameObject[] runesprite = new GameObject[10];
		private GameObject CurrentRuneUI = null;
		
		//Clears our list gridPositions and prepares it to generate a new board.
		void InitialiseList ()
		{
			//Clear our list gridPositions.
			gridPositions.Clear ();
			
			//Loop through x axis (columns).
			for(int x = 1; x < columns-1; x++)
			{
				//Within each column, loop through y axis (rows).
				for(int y = 1; y < rows-1; y++)
				{
					//At each index add a new Vector3 to our list with the x and y coordinates of that position.
					gridPositions.Add (new Vector3(x, y, 0f));
				}
			}
		}
		
		
		//Sets up the outer walls and floor (background) of the game board.
		void BoardSetup () //生成
		{
			//Instantiate Board and set boardHolder to its transform.
			boardHolder = new GameObject ("Board").transform;
			//Grave = (GameObject)Resources.Load("Grave",typeof(GameObject));
			
			//Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
			for(int x = -1; x < columns + 1; x++)
			{
				//Loop along y axis, starting from -1 to place floor or outerwall tiles.
				for(int y = -1; y < rows + 1; y++)
				{
					//Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
					GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
					
					//Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
					if(x == -1 || x == columns || y == -1 || y == rows)
						toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
					
					//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					
					//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
					instance.transform.SetParent (boardHolder);
				}
			}
			// set rune
			int level = GameManager.instance.getlevel();
			for(int i =0;i<10;i++){
				if(InformationReaderCs.runeinfo[level,3*i] == -1) break;
				//print(i +"__x:" + InformationReaderCs.runeinfo[level,3*i]+"y:"+InformationReaderCs.runeinfo[level,3*i+1]+"rune:"+InformationReaderCs.runeinfo[level,3*i+2]);
				rune[i] = new GameObject ("rune" + i.ToString());
				rune[i].AddComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Image/Random",typeof(Sprite));			
				rune[i].transform.position = new Vector3(InformationReaderCs.runeinfo[level,3*i],InformationReaderCs.runeinfo[level,3*i+1],0f);
				rune[i].AddComponent<BoxCollider2D>().size = new Vector2(1,1);
				rune[i].GetComponent<BoxCollider2D>().isTrigger = true;
				rune[i].GetComponent<SpriteRenderer>().sortingLayerName = "Rune";
				rune[i].tag = "Rune";
				//print(6*(InformationReaderCs.runeinfo[level,3*i]-1)+InformationReaderCs.runeinfo[level,3*i+1]-1);
				int runePosID = 6*(InformationReaderCs.runeinfo[level,3*i]-1)+InformationReaderCs.runeinfo[level,3*i+1]-1;
				if(runePosID >0)
					gridPositions.RemoveAt(6*(InformationReaderCs.runeinfo[level,3*i]-1)+InformationReaderCs.runeinfo[level,3*i+1]-1);

				runesprite[i] = new GameObject ("runesprite" + i.ToString());
				runesprite[i].transform.position = new Vector3(rune[i].transform.position.x,rune[i].transform.position.y,-1);
				runesprite[i].transform.localScale = new Vector3(0.2f,0.2f,1);
				runesprite[i].AddComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Image/rune" + InformationReaderCs.runeinfo[level,3*i+2].ToString(),typeof(Sprite));
				runesprite[i].GetComponent<SpriteRenderer>().sortingLayerName = "RuneSprite";
				runesprite[i].transform.SetParent(rune[i].transform);

			}

			//show current rune
			//print(SceneManager.CurrentRuneID);
			CurrentRuneUI = new GameObject ("CurrentRune");
			CurrentRuneUI.AddComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Image/rune"+ SceneManager.CurrentRuneID.ToString(),typeof(Sprite));
			//CurrentRuneUI.AddComponent<MeshRenderer>();
			//CurrentRuneUI.AddComponent<MeshFilter>();
			//CurrentRuneUI.AddComponent<SetRuneMaterial>().init(SceneManager.CurrentRuneID);
			CurrentRuneUI.transform.localScale = new Vector3(0.4f,0.4f,1);
			CurrentRuneUI.transform.position = new Vector3(-2,5,0);
		}
		
		
		//RandomPosition returns a random position from our list gridPositions.
		Vector3 RandomPosition ()
		{
			//Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
			int randomIndex = Random.Range (0, gridPositions.Count);
			
			//Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
			Vector3 randomPosition = gridPositions[randomIndex];

			//print(randomIndex+":"+randomPosition);
			
			//Remove the entry at randomIndex from the list so that it can't be re-used.
			gridPositions.RemoveAt (randomIndex);
			
			//Return the randomly selected Vector3 position.
			return randomPosition;
		}
		
		
		//LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
		void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
		{
			//Choose a random number of objects to instantiate within the minimum and maximum limits
			int objectCount = Random.Range (minimum, maximum+1);
			
			//Instantiate objects until the randomly chosen limit objectCount is reached
			for(int i = 0; i < objectCount; i++)
			{
				//Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
				Vector3 randomPosition = RandomPosition();
				
				//Choose a random tile from tileArray and assign it to tileChoice
				GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
				
				//Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
				Instantiate(tileChoice, randomPosition, Quaternion.identity);
			}
		}
		
		
		//SetupScene initializes our level and calls the previous functions to lay out the game board
		public void SetupScene (int level)
		{	
			//Reset our list of gridpositions.
			InitialiseList ();

			//Creates the outer walls and floor.
			BoardSetup ();			

			//Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
			
			//Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);
			
			//Determine number of enemies based on current level number, based on a logarithmic progression
			int enemyCount = (int)Mathf.Log(level, 2f);
			
			//Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
			LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);
			
			//Instantiate the exit tile in the upper right hand corner of our game board
			Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);

			//for(int i=0;i<gridPositions.Count;i++)
				//print(i+":"+gridPositions[i]);
		}
	}
}
