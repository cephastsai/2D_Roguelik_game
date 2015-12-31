using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public GameObject RuneManager;

    void OnMouseDown()
    {
        //RuneManager = GameObject.Find("RuneManager");
        //RuneManager.GetComponent<RuneManagerCs>().random();

		Application.LoadLevel("Main");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
