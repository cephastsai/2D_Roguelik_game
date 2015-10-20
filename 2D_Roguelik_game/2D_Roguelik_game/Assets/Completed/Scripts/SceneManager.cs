using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public static bool menu_flag = true;
    public static SceneManager instance = null;
    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            menu_flag = true;
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
