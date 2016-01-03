using UnityEngine;
using System.Collections;

public class LevelMagicCircle : MonoBehaviour {

	public static int[] MagicCircleDone = new int[20];

	void Awake(){
		foreach(int i in MagicCircleDone){
			MagicCircleDone[i] = 0;
		}
	}
}
