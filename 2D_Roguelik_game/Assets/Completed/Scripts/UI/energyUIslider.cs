using UnityEngine;
using System.Collections;

public class energyUIslider : MonoBehaviour {

	private UISlider slider;

	private GameObject player = null;

	private int food;
	// Use this for initialization
	void Start () {
		slider =  gameObject.GetComponent<UISlider>();

		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		food = player.GetComponent<Completed.Player>().food;
		slider.sliderValue =  1f - (float)food/200f;
	}
}
