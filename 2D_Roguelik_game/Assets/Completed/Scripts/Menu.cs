using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
    void OnGUI()
    {
        if (GUILayout.Button("Start Game"))
        {
            Application.LoadLevel("Main");
        }
        /*if(GUI.Button(new Rect(0, 50, 50, 150), "Left"))
		{
			StartCoroutine("ChangeRuneScaleLeft");
		}
		if(GUI.Button(new Rect(590, 50, 50, 150), "Right")){
			StartCoroutine("ChangeRuneScaleRight");
			//Rune1 = GameObject.Find("Rune1(Clone)");
			//Rune1.transform.position   += new Vector3(5,0.94f,0);
			//Rune1.transform.localScale -= new Vector3(0.2f,0.2f,0.2f);

		}*/
    }

    // Use this for initialization
	/*IEnumerator ChangeRuneScaleLeft() 
	{
		Rune1 = GameObject.Find("Rune1(Clone)");
		Rune1.transform.position +=new Vector3(-5,0.94f,0);
		Rune1.transform.localScale -= new Vector3 (0.2f, 0.2f, 0.2f);
		yield return 0;
	}
	IEnumerator ChangeRuneScaleRight() 
	{
		Rune1 = GameObject.Find("Rune1(Clone)");
		Rune1.transform.position   += new Vector3(5,0.94f,0);
		Rune1.transform.localScale -= new Vector3(0.2f,0.2f,0.2f);
		yield return 0;
	}*/
	void Start () {
	//	GameObject  Prefab = Instantiate(Resources.Load("Rune1" ,typeof(GameObject)),RunePosition4,Quaternion.Euler(90, 180, 0)) as GameObject;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
