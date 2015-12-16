using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("EnterRuneLevel");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator EnterRuneLevel()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Menu");
    }

}
