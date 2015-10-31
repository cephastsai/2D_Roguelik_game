using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	//public static bool Button(Rect (10,10,20,20), Ramdom));
	public GameObject RuneManager = null;

    void OnGUI()
    {
        if (GUILayout.Button("Start Game"))
        {
            Application.LoadLevel("Main");
        }
    }

    // Use this for initialization

	void Start () {
		RuneManager = new GameObject("RuneManager");
		RuneManager.AddComponent<RuneManagerCs>();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
