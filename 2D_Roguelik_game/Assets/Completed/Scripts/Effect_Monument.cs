using UnityEngine;
using System.Collections;

public class Effect_Monument : MonoBehaviour {
    public Animator ani;

    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        float dist = Vector3.Distance(this.transform.position, GameObject.FindWithTag("Player").transform.position);
        if (dist < 1.1)
        {
            ani.SetInteger("enterFrame", 1);
        }
        else
        {
            ani.SetInteger("enterFrame", 0);
        }
    }
}
