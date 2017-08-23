using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public int attack;
	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, speed);
    }

    // Update is called once per frame
    void Update () {
		
	}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag=="Enemy")
    //    {
    //        //给敌人减血(attack)、给一个小爆炸、子弹消失
    //        //可能还要给player发信息报告子弹消失
    //        other.gameObject.GetComponent<Enemy>().BeAttacked(attack);
    //        Destroy(gameObject);
    //    }
    //}
}
