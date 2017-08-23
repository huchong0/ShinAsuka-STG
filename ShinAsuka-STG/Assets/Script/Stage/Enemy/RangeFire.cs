using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFire : MonoBehaviour {
    public GameObject Bullet;
    public float Speed;
    public GameObject FireSpot;
    public float Interval;

	// Use this for initialization
	void Start () {
        StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Fire()
    {
        //yield return new WaitForSeconds(Interval/2);
        while(true)
        {
            float PI = 3.14f;
            var bullet1 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            var bullet2 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            var bullet3 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            Vector3 direction = new Vector3(0, 0, -1);
            bullet1.GetComponent<Rigidbody>().velocity = direction * Speed;
            bullet2.GetComponent<Rigidbody>().velocity = direction * Speed * 0.8f;
            bullet3.GetComponent<Rigidbody>().velocity = direction * Speed * 0.6f;

            bullet1 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            bullet2 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            bullet3 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            direction = new Vector3(Mathf.Sin(PI/8+1f*PI), 0, Mathf.Cos(PI/8 + 1f * PI));
            bullet1.GetComponent<Rigidbody>().velocity = direction * Speed * 0.8f;
            bullet2.GetComponent<Rigidbody>().velocity = direction * Speed * 0.6f;
            bullet3.GetComponent<Rigidbody>().velocity = direction * Speed * 0.4f;

            bullet1 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            bullet2 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            bullet3 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            direction = new Vector3(Mathf.Sin(-PI / 8 + 1f * PI), 0, Mathf.Cos(-PI / 8 + 1f * PI));
            bullet1.GetComponent<Rigidbody>().velocity = direction * Speed * 0.8f;
            bullet2.GetComponent<Rigidbody>().velocity = direction * Speed * 0.6f;
            bullet3.GetComponent<Rigidbody>().velocity = direction * Speed * 0.4f;

            bullet1 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            bullet2 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            bullet3 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            direction = new Vector3(Mathf.Sin(PI / 4 + 1f * PI), 0, Mathf.Cos(PI / 4 + 1f * PI));
            bullet1.GetComponent<Rigidbody>().velocity = direction * Speed;
            bullet2.GetComponent<Rigidbody>().velocity = direction * Speed * 0.8f;
            bullet3.GetComponent<Rigidbody>().velocity = direction * Speed * 0.6f;

            bullet1 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            bullet2 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            bullet3 = Instantiate(Bullet, FireSpot.transform.position, new Quaternion());
            direction = new Vector3(Mathf.Sin(-PI / 4 + 1f * PI), 0, Mathf.Cos(-PI / 4 + 1f * PI));
            bullet1.GetComponent<Rigidbody>().velocity = direction * Speed;
            bullet2.GetComponent<Rigidbody>().velocity = direction * Speed * 0.8f;
            bullet3.GetComponent<Rigidbody>().velocity = direction * Speed * 0.6f;

            yield return new WaitForSeconds(Interval);
        }




    }
}
