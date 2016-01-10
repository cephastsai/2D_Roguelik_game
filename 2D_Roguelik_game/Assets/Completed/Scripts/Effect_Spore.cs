using UnityEngine;
using System.Collections;

public class Effect_Spore : MonoBehaviour {

	private bool flag = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(this.transform.position, GameObject.FindWithTag("Player").transform.position);
        if (dist < 1.1 && flag)
        {
            Instantiate(Resources.Load("Prefabs/Spore", typeof(GameObject)), this.transform.position, Quaternion.identity);
			flag = false;
        }
    }
}
