using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{ 
    enemy0,
    enemy1,
    enemy2
}
public class Enemy : MonoBehaviour {
    public int hp = 1;
    public float speed = 2;
    public float score = 100;
    public EnemyType type = EnemyType.enemy0;
    public bool isDeath = false;
    public Sprite[] explosionSprites; //死亡爆炸动画的数组
    private float timer = 0;
    public int explosionAnimationFrame = 10;  //死亡动画每秒播放的帧数
    private SpriteRenderer render;

    public float hitTimer = 0.2f; //碰撞播放时间 每打击一次0.2秒  碰撞动画
    private float resetHitTime; //每打击一次就对hitTime进行重置

    public Sprite[] hitSprites;


	// Use this for initialization
	void Start () {
        render = this.GetComponent<SpriteRenderer>();
        resetHitTime = hitTimer;
        hitTimer = 0;
    
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y<=-5.6f)
        {
            Destroy(gameObject);
        }
        if (isDeath)
        {

            timer += Time.deltaTime;  //取值从0开始
            int frameIndex = (int)(timer / (1f / explosionAnimationFrame));
            if (frameIndex >= explosionSprites.Length)   //判断动画一共有多少帧
            {
                Destroy(this.gameObject);
            }
            else
            {
                render.sprite = explosionSprites[frameIndex];
            }
        }
        else
        {
            if(type==EnemyType.enemy1||type==EnemyType.enemy2)
            if (hitTimer >= 0)
            { 
                hitTimer-=Time.deltaTime;
                int frameIndex = (int)((resetHitTime - hitTimer) / (1f / explosionAnimationFrame));
                frameIndex %= 2;
                render.sprite = hitSprites[frameIndex];

            }
        }



	}

    public void BeHit()
    {
        hp -= 1;   //减少血量
        if (hp <= 0)   //判断敌人有没有死
            isDeath = true;     //如果死了，就播放死亡动画
        else
        {
            hitTimer = resetHitTime;  //如果没有死，就播放受伤动画
        }
    }



}
