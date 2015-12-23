using UnityEngine;
using System.Collections;

public class FoodHealing : MonoBehaviour {

	public void healing(){
		Instantiate (Resources.Load("Prefabs/HealingFX",typeof(GameObject)), this.transform.position, Quaternion.Euler(-90, 0, 0));
	}
}
