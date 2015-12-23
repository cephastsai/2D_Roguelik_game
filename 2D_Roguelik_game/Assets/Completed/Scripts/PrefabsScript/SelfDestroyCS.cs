using UnityEngine;
using System.Collections;

public class SelfDestroyCS : MonoBehaviour {
	public float creationTime = 0f;
	// Use this for initialization
	void Start () {
		creationTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > (creationTime+3))
		Destroy(gameObject);
		
}
}