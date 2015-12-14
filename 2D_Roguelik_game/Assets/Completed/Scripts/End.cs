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
		private int size1 = 50;
		private int size2 = 50;
		private int size3 = 50;
		private int size4 = 50;
		bool l1 =true;
		private int p =0;
		bool p1 = true;
		private int r =0;
		bool r1 = true;
		private int d =0;
		bool d1 = true;

        bool restartBool = false;
        //private GameObject RestartGame;

        // Use this for initialization
        void Start()
		{
			level = PlayerPrefs.GetInt("level", level);
			playerMaxFoodPoint = PlayerPrefs.GetInt("playerMaxFoodPoint", playerMaxFoodPoint);
			RuneCount = PlayerPrefs.GetInt("RuneCount", RuneCount);
			DieCount = PlayerPrefs.GetInt("DieCount", DieCount);
		}

		IEnumerator Level(){
			yield return new WaitForSeconds (0.25f);
			l++;
			l1 = true;
		}
		IEnumerator FoodPoint(){
			yield return new WaitForSeconds (0.01f);
			p++;
			p1 = true;
		}
		IEnumerator Rune(){
			yield return new WaitForSeconds (0.25f);
			r++;
			r1 = true;
		}
		IEnumerator Die(){
			yield return new WaitForSeconds (0.25f);
			d++;
			d1 = true;
		}

		// Update is called once per frame
		void Update()
		{
			string day = "" + l;
			string food = "" + p;
			string life = "" + d;
			string rune = "" + r;
			GameObject.Find ("Day(2)").GetComponent<UILabel> ().text = day;
			GameObject.Find ("Point(2)").GetComponent<UILabel> ().text = food;
			GameObject.Find ("Life(2)").GetComponent<UILabel> ().text = life;
			GameObject.Find ("Rune(2)").GetComponent<UILabel> ().text = rune;
            GameObject.Find("RestartGame").SetActive(false);
            //GameObject.Find("Restart") = restartBool;
            if (l1 && level>l) {
				StartCoroutine ("Level");
				l1 =false;
			} else if (l == level) {
				StopCoroutine ("Level");
				GameObject.Find ("Day(2)").GetComponent<UILabel> ().fontSize = size1;
			}
			if (GameObject.Find ("Day(2)").GetComponent<UILabel> ().fontSize >= 30) {
				size1--;
			}
			if (p1 && playerMaxFoodPoint>p&&l==level) {
				GameObject.Find ("Label2").transform.localPosition = new Vector3(-107,11,0);
				StartCoroutine ("FoodPoint");
				p1 =false;
			} else if (p == playerMaxFoodPoint) {
				StopCoroutine ("FoodPoint");
				GameObject.Find ("Point(2)").GetComponent<UILabel> ().fontSize = size2;
			}
			if (GameObject.Find ("Point(2)").GetComponent<UILabel> ().fontSize >= 30) {
				size2--;
			}
			if (r1 && RuneCount>r&&p==playerMaxFoodPoint) {
				GameObject.Find ("Label3").transform.localPosition = new Vector3(43,9.7f,0);
				StartCoroutine ("Rune");
				r1 =false;
			} else if (r == RuneCount) {
				StopCoroutine ("Rune");
				GameObject.Find ("Rune(2)").GetComponent<UILabel> ().fontSize = size3;
			}
			if (GameObject.Find ("Rune(2)").GetComponent<UILabel> ().fontSize >= 30) {
				size3--;

			}
			if (d1 && DieCount>d&&r==RuneCount) {
				GameObject.Find ("Label4").transform.localPosition = new Vector3(54.8f,-111,0);
				StartCoroutine ("Die");
				d1 =false;
			} else if (d == DieCount) {
				StopCoroutine ("Die");
				GameObject.Find ("Life(2)").GetComponent<UILabel> ().fontSize = size4;
                restartBool = true;
            }
			if (GameObject.Find ("Life(2)").GetComponent<UILabel> ().fontSize >= 30) {
				size4--;
			}

            if(restartBool == true)
            {
                GameObject.Find("RestartGame").SetActive(true);
            }
		}
	}
}