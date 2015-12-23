using UnityEngine;
using System.Collections;

public class GridUI : MonoBehaviour {

	private float GridLong;
	private float perGridLong;

	void Start () {

		GridLong = transform.GetChild(transform.childCount-1).GetComponent<RectTransform>().position.y - transform.GetChild(0).GetComponent<RectTransform>().position.y ;
		/*print(GridLong);
		print(transform.GetChild(transform.childCount-1).GetComponent<RectTransform>().anchoredPosition);
		print( transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition);
		print(transform.GetChild(transform.childCount-1));
		print(transform.GetChild(0));*/
	}
	

	void Update () {
	
	}
}
