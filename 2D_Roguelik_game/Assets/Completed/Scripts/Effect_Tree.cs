using UnityEngine;
using System.Collections;

public class Effect_Tree : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(this.transform.position, GameObject.FindWithTag("Player").transform.position);
        if (dist < 1.1)
        {
            Instantiate(Resources.Load("Prefabs/Wall3B", typeof(GameObject)), this.transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
