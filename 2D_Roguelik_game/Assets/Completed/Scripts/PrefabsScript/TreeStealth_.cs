using UnityEngine;
using System.Collections;

public class TreeStealth_ : MonoBehaviour {
	public int d = 1;
	public float c = 0f;
	public Color A = new Vector4(1,1,1,0);
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		A = new Vector4 (1, 1, 1, c);
		GetComponent<SpriteRenderer> ().color = A;
		/*
		if (c < 1) 
		{
			c +=1/255;
		}*/

	}
}
