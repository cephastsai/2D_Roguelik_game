using UnityEngine;
using System.Collections;

public class SelfDestroyCS : MonoBehaviour {
	public float creationTime = 0f;
	private float DestroyTime = 3f;


	void Start () {
		creationTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > (creationTime+DestroyTime))
		Destroy(gameObject);
		
	}

	public void SetDestroyTime(float time){
		DestroyTime = time;
	}
}