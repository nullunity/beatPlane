using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransform : MonoBehaviour
{

    private float speed = 2;  //创建一个速度

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);  //实现背景的移动
        if (transform.position.y <= -8.52)  //判断背景是否移出屏幕
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 8.52f * 2, transform.position.z);
        }
    }
}
