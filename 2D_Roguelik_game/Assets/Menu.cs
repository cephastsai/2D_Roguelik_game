﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	//public static bool Button(Rect (10,10,20,20), Ramdom));
	public GameObject RuneManager = null;
	public GameObject Fog1 = null;
	public GameObject Fog2 = null;

    /*void OnGUI()
    {
        if (GUILayout.Button("Start Game"))
        {
            Application.LoadLevel("Main");
        }
    }*/

    // Use this for initialization

	void Start () {
		//RuneManager = new GameObject("RuneManager");
		//RuneManager.AddComponent<RuneManagerCs>();
		GameObject.Find ("Fog1").AddComponent<SetFog1Material> ();
		GameObject.Find ("Fog2").AddComponent<SetFog2Material> ();
		GameObject.Find ("Fog3").AddComponent<SetFog1Material> ();
		GameObject.Find ("Fog4").AddComponent<SetFog2Material> ();
        //GameObject.Find("Logo").SetActive(true);
        //StartCoroutine("EnterRuneLevel");
    }

    /*IEnumerator EnterRuneLevel()
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("Logo").SetActive(false);
        //print("444");
    }*/

    // Update is called once per frame
    void Update () {
	
	}
}