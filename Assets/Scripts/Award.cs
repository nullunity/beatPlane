﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour {

    public int type = 0;
    public float speed = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -4.7f)
        {
            Destroy(gameObject);
        }
	}
}
