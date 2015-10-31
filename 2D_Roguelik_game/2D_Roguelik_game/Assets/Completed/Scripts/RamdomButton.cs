using UnityEngine;
using System.Collections;

public class RamdomButton : MonoBehaviour {
	public Texture RamdomImage = null;
	// Use this for initialization\
	void OnGUI()
	{
		if (GUI.Button (new Rect (10, 10, 50, 50), RamdomImage)) 
		{

		}
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
