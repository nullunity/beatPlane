using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float rate = 0.2f;//每隔两秒发一发子弹

    public GameObject bullet;
	// Use this for initialization
	void Start () {
        openFire();
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    public void fire()
    {
        GameObject.Instantiate(bullet, transform.position, Quaternion.identity);//Quaternion.identity:让它没有任何旋转
    }
    public void openFire()
    {
        InvokeRepeating("fire",1,rate); //一秒之后开始调用fire方法，以后每隔rete秒调用一次
    }

}
