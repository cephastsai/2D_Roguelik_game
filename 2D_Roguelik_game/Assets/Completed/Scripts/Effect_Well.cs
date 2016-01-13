﻿using UnityEngine;
using System.Collections;

public class Effect_Well : MonoBehaviour {

    public Animator ani;
	private bool flag = true;

    void Awake()
    {
        ani = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(this.transform.position, GameObject.FindWithTag("Player").transform.position);
        if (dist < 1.1)
        {
			if(flag){
				print("2");
				ani.SetInteger("enterFrame", 1);
				flag = false;
			}
            
        }
        else
        {
            ani.SetInteger("enterFrame", 0);
        }
    }
}