using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public float timer = 0;  //动画播放时间
    public int speed = 10;  //一秒播放几帧
    public bool animation = true; //标志位  是否进行动画
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    private bool isMouseDown = false;  //用来判断鼠标左键是否按下
    private Vector3 lastMousePosition = Vector3.zero;  


	// Use this for initialization
	void Start () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();  //获取SpriteRenderer这个组件
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (animation)
        {
            timer += Time.deltaTime;  //计时器timer进行计时(动画播放总时间)
            int frameIndex = (int)(timer / (1.0f / speed));  //1.0f / speed:每一帧的播放时间   timer / (1.0f / speed):当前播放到第几帧
            int frame = frameIndex % 2;  //得到0 1 用来取数组，实现图片的循环取余循环播放
            spriteRenderer.sprite = sprites[frame];
        }
        if (Input.GetMouseButtonDown(0))  //如果鼠标左键按下
        {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }
        if (isMouseDown)
        {
            if(lastMousePosition!=Vector3.zero)
            {

                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;  //得到移动的位置差
                transform.position = transform.position + offset;
                checkPosition();
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        }
    }
        private void checkPosition()  //防止英雄移出屏幕
        {
            Vector3 pos = transform.position;
            float x = pos.x;
            float y = pos.y;
            if (x > 1.9f)
            {
                x = 1.9f;
            }
            if (x < -1.9f)
            {
                x = -1.9f;
            }
            if (y > 3.4f)
            {
                y = 3.4f;
            }
            if (y < -3.4f)
            {
                y = -3.4f;
            }
            transform.position = new Vector3(x, y, 0);

        }
	
}

