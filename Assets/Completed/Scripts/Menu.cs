using UnityEngine;
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
		RuneManager = new GameObject("RuneManager");
		RuneManager.AddComponent<RuneManagerCs>();
		Fog1 = GameObject.Find("Fog1");
		//Fog1 = new GameObject("Fog1");
		Fog1.gameObject.AddComponent<SetFog1Material> ();
		Fog2 = GameObject.Find("Fog2");
		//Fog2 = new GameObject ("Fog2");
		Fog2.gameObject.AddComponent<SetFog2Material> ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
