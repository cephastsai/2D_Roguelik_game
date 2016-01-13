using UnityEngine;
using System.Collections;

public class Arrowhead : MonoBehaviour {

	//Tramsform to set position
	private Transform target = null;
	private Vector3 start ;
	private Vector3 end ;

	//v
	private float start_v = 0.2f;
	private float end_v = 2f;

	//bool
	private bool move = true;

	void init(){
		target = gameObject.transform.GetChild(0);
		end = gameObject.transform.GetChild(1).localPosition;
		start = target.localPosition;
	}

	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		if(target.localPosition == end){
			move = false;
			end_v = 2f;
		}

		if(target.localPosition == start){
			move = true;
			start_v = 0.2f;
		}

		if(move){
			start_v += 0.05f;
			target.localPosition = Vector3.MoveTowards(target.localPosition, end, start_v*Time.deltaTime);
		}else{
			target.localPosition = Vector3.MoveTowards(target.localPosition, start, end_v*Time.deltaTime);
		}

	}

}
