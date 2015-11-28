using UnityEngine;
using System.Collections;

namespace Completed
{
	public class End : MonoBehaviour
	{
		public int level;
		public int playerMaxFoodPoint;
		public int RuneCount;
		public int DieCount;
		private int l =0;
		bool l1 =true;
		private int p =0;
		bool p1 = true;
		private int r =0;
		bool r1 = true;
		private int d =0;
		bool d1 = true;
		// Use this for initialization
		void Start()
		{
			level = PlayerPrefs.GetInt("level", level);
			playerMaxFoodPoint = PlayerPrefs.GetInt("playerMaxFoodPoint", playerMaxFoodPoint);
			RuneCount = PlayerPrefs.GetInt("RuneCount", RuneCount);
			DieCount = PlayerPrefs.GetInt("DieCount", DieCount);
		}
		IEnumerator Level(){
			yield return new WaitForSeconds (1);
			l++;
			l1 = true;
		}
		IEnumerator FoodPoint(){
			yield return new WaitForSeconds (0.01f);
			p++;
			p1 = true;
		}
		IEnumerator Rune(){
			yield return new WaitForSeconds (1);
			r++;
			r1 = true;
		}
		IEnumerator Die(){
			yield return new WaitForSeconds (0.5f);
			d++;
			d1 = true;
		}
		// Update is called once per frame
		void Update()
		{
			if (l1 && level>l) {
				StartCoroutine ("Level");
				l1 =false;
			} else if (l == level) {
				StopCoroutine ("Level");
			}
			if (p1 && playerMaxFoodPoint>p) {
				StartCoroutine ("FoodPoint");
				p1 =false;
			} else if (p == playerMaxFoodPoint) {
				StopCoroutine ("FoodPoint");
			}
			if (r1 && RuneCount>r) {
				StartCoroutine ("Rune");
				r1 =false;
			} else if (r == RuneCount) {
				StopCoroutine ("Rune");
			}
			if (d1 && DieCount>d) {
				StartCoroutine ("Die");
				d1 =false;
			} else if (d == DieCount) {
				StopCoroutine ("Die");
			}
		}
		
		void OnGUI()
		{
			GUI.Label(new Rect(250, 50, 300, 50), "After " + l + " days, you starved.");
			GUI.Label(new Rect(250, 80, 300, 50), "Max point: " + p);
			GUI.Label(new Rect(250, 110, 300, 50), "DieCount :" + d);
			GUI.Label(new Rect(250, 140, 300, 50), "RuneCount: " + r);
			if (GUILayout.Button("Restart Game"))
			{
				Application.LoadLevel("Menu");
			}
		}
	}
}