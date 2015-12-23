using UnityEngine;
using System.Collections;

public class GridUI : MonoBehaviour {

	private float GridLong;
	private float perGridLong;

	void Start () {

		GridLong = transform.GetChild(0).position.x - transform.GetChild(transform.childCount).position.x;
		print(GridLong);
	}
	

	void Update () {
	
	}
}
