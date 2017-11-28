using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemy0Prefeb;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject award0Prefab;
    public GameObject award1Prefab;

    public float enemy0Rate = 0.5f;
    public float enemy1Rate = 5f;
    public float enemy2Rate = 8f;
    public float award0Rate = 7f;
    public float award1Rate = 10f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("createEnemy0", 1, enemy0Rate);
        InvokeRepeating("createEnemy1", 3, enemy1Rate);
        InvokeRepeating("createEnemy2", 6, enemy2Rate);
        InvokeRepeating("createAward0", 10, award0Rate);
        InvokeRepeating("createAward1", 10, award1Rate);
	}
	// Update is called once per frame
	void Update () {
	
    }
    public void createEnemy0()
    {
        float x = Random.Range(-2.15f,2.15f);  //x坐标的随机分布
        GameObject.Instantiate(enemy0Prefeb, new Vector3(x,transform.position.y,0), Quaternion.identity);
    }
    public void createEnemy1()
    {
        float x = Random.Range(-2.06f,2.06f);
        GameObject.Instantiate(enemy1Prefab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void createEnemy2()
    {
        float x = Random.Range(-1.55f,1.55f);
        GameObject.Instantiate(enemy2Prefab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void createAward0()
    {
        float x = Random.Range(-2.1f, 2.1f);  
        GameObject.Instantiate(award0Prefab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void createAward1()
    {
        float x = Random.Range(-2.1f, 2.1f);
        GameObject.Instantiate(award1Prefab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
}
