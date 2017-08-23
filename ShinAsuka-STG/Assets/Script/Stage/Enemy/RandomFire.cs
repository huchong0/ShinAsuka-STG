using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFire : MonoBehaviour {
    public GameObject Bullet;
    public float Speed;
    public GameObject FireSpot;
    public float Delay;
    public float Interval;

    private GameObject Player;


	// Use this for initialization
	void Start () {
        GameObject stageController = GameObject.Find("StageController");
        Player = stageController.GetComponent<StageController>().Player;
        StartCoroutine(Fire());

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Awake()
    {
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(Delay);

        while(true)
        {
            GeneralizeBullet();
            yield return new WaitForSeconds(Interval);
        }

    }

    void GeneralizeBullet()
    {
        Vector3 direction = Player.transform.position - FireSpot.transform.position;
        direction.Normalize();
        var Bullet1 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
        Bullet1.GetComponent<Rigidbody>().velocity = Speed * direction;

        var Bullet2 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
        Bullet2.GetComponent<Rigidbody>().velocity = Speed * direction * 0.6f;

        var Bullet3 = Instantiate(Bullet, FireSpot.transform.position+new Vector3(1,0,0), new Quaternion());
        Bullet3.GetComponent<Rigidbody>().velocity = Speed * direction * 0.8f;

        var Bullet4 = Instantiate(Bullet, FireSpot.transform.position + new Vector3(-1, 0, 0), new Quaternion());
        Bullet4.GetComponent<Rigidbody>().velocity = Speed * direction * 0.8f;

        var Bullet5 = Instantiate(Bullet, FireSpot.transform.position + new Vector3(1.5f, 0, 0), new Quaternion());
        Bullet5.GetComponent<Rigidbody>().velocity = Speed * direction * 0.6f;

        var Bullet6 = Instantiate(Bullet, FireSpot.transform.position + new Vector3(-1.5f, 0, 0), new Quaternion());
        Bullet6.GetComponent<Rigidbody>().velocity = Speed * direction * 0.6f;


    }
}
