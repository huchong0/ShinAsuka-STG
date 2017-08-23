using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour,IDisposable {
    public int hp;
    public List<Enemy> Enemies;
    public GameObject Explosion;
    public bool boss;

    private GameObject StageController;

    public bool BeAttacked(int ATK)
    {

        hp -= ATK;
        if (hp <= 0)
        {
            return true;
        }
        else return false;
    }
    // Use this for initialization
    protected void Awake()
    {
        StageController = GameObject.Find("StageController");
        addToList();
    }


    public void Dispose()
    {
        Enemies.Remove(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //玩家死亡，调用相关函数进行后续工作
            Destroy(other.gameObject);

        }
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            if (BeAttacked(other.GetComponent<Bullet>().attack))
            {
                Enemies.Remove(this);
                Instantiate(Explosion, transform.position, transform.rotation);
                StageController.GetComponent<StageController>().PlayExplosionSound();
                if (boss) StageController.GetComponent<StageController>().GameClear();
                StageController.GetComponent<StageController>().GetScore();

                Destroy(this.gameObject);
            }
        }
        if (other.tag == "ShortLaser")
        {
            if (BeAttacked(other.GetComponent<Bullet>().attack))
            {
                Enemies.Remove(this);
                Instantiate(Explosion, transform.position, transform.rotation);
                StageController.GetComponent<StageController>().PlayExplosionSound();
                if (boss) StageController.GetComponent<StageController>().GameClear();
                StageController.GetComponent<StageController>().GetScore();

                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Laser")
        {
            if (BeAttacked(other.GetComponent<Laser>().Attack))
            {
                Enemies.Remove(this);
                Instantiate(Explosion, transform.position, transform.rotation);
                StageController.GetComponent<StageController>().PlayExplosionSound();
                if (boss) StageController.GetComponent<StageController>().GameClear();
                StageController.GetComponent<StageController>().GetScore();

                Destroy(this.gameObject);
            }

        }
    }


    public void addToList()
    {
        Enemies = StageController.GetComponent<StageController>().Enemies;
        Enemies.Add(this);
    }
    public void removeFromList()
    {
        Enemies.Remove(this);
    }


}
