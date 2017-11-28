using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullt : MonoBehaviour {
    public float speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up*speed*Time.deltaTime);
        if (transform.position.y > 4.2f)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)    // 碰撞触发器    当子弹击中敌人之后
    {
        if (other.tag == "enemy")   
        {
            if(!other.GetComponent<Enemy>().isDeath)
            { 
            other.gameObject.SendMessage("BeHit");  //   SendMessage：调用BeHit这个方法
            GameObject.Destroy(this.gameObject);
            }
        }
    }

}
