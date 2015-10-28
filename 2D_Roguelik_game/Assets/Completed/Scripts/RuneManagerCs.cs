using UnityEngine;
using System.Collections;

public class RuneManagerCs : MonoBehaviour {

	private GameObject canvas = null;
	private GameObject grid = null;


	// Use this for initialization
	void Start () {
		//find gameobject "gird"
		canvas = GameObject.Find("Canvas");
		grid = canvas.transform.GetChild(1).GetChild(0).gameObject;

		for(int temp=0;temp<grid.transform.childCount;temp++){
			grid.transform.GetChild(temp).gameObject.AddComponent<SetRuneMaterial>().init(temp);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
