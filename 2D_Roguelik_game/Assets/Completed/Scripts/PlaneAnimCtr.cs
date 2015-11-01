using UnityEngine;
using System.Collections;

public class PlaneAnimCtr : MonoBehaviour {

    public Animator plane;
     
	// Use this for initialization
	void Start () {
        plane = GameObject.Find("plane").GetComponent<Animator>();
	}

    void OnGUI()
    {
        if (GUILayout.Button("Start Cube Move Act"))
        {

            plane.SetBool("Idle", false);  // 這邊可以看作為當不是Idle時，可以觀察到動畫會前進到 Move 並撥放

         
        }
    }
}
