using UnityEngine;
using System.Collections;

public class TreeStealth_ : MonoBehaviour {
	public int d = 1;
	public float c = 1f;
	public Color A = new Vector4(1,1,1,1);
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		A = new Vector4 (1, 1, 1, c);
		GetComponent<SpriteRenderer> ().color = A;
		if (d==1) {
			c -= 0.02f;
			if (c < 0) 
			{
				d = 0;
			}
		} 
		else if (d == 0) 
		{
			c +=0.02f;
			if (c > 1) 
			{
				d =1;
			}
		}
	}
}
