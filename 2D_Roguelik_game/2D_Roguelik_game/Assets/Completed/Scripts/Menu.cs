using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {


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
