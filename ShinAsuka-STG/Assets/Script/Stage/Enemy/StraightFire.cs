using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFire : MonoBehaviour {
    public GameObject Bullet;
    public GameObject FireSpot;
    public float WaitTime;
    public float Speed;
    public float Interval = 0.4f;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(WaitTime);

        for(int i=0;i<8;++i)
        {


            Vector3 Direction = this.transform.forward;
            Direction.Normalize();
            var temp = Instantiate(Bullet, FireSpot.transform.position,FireSpot.transform.rotation);
            temp.GetComponent<Rigidbody>().velocity = Direction * -Speed;
            yield return new WaitForSeconds(Interval);
        }
    }

}
