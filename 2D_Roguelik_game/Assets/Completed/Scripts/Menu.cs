using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	//public static bool Button(Rect (10,10,20,20), Ramdom));
	public GameObject RuneManager = null;


    // Use this for initialization

	void Start () {
		RuneManager = new GameObject("RuneManager");
		RuneManager.AddComponent<RuneManagerCs>();
		GameObject.Find("Fog1").AddComponent<SetFog1Material> ();
		GameObject.Find("Fog2").AddComponent<SetFog1Material> ();
		GameObject.Find("Fog3").AddComponent<SetFog1Material> ();
		GameObject.Find("Fog4").AddComponent<SetFog1Material> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
