using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {
    public GameObject MainBullet;
    public int Power
    {
        get;set;
    }
    public float IntervalTime;
    private float NextTime;
    public GameObject FireSpot;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(NextTime<Time.time)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                switch (Power)
                {
                    case 0:
                        StartCoroutine(Fire0());
                        break;
                    case 1:
                        StartCoroutine(Fire0());
                        break;
                    case 2:
                        StartCoroutine(Fire0());
                        break;
                    default:
                        StartCoroutine(Fire0());
                        break;

                }
                NextTime = Time.time + IntervalTime;
            }
        }
	}
    IEnumerator Fire0()
    {
        for(int i=0;i<4;++i)
        {
            Vector3 position = FireSpot.transform.position;
            Instantiate(MainBullet,
                new Vector3(position.x - 0.05f, position.y, position.z+0.5f),
                new Quaternion());
            Instantiate(MainBullet,
                new Vector3(position.x + 0.05f, position.y, position.z+0.5f),
                new Quaternion());
            yield return new WaitForSeconds(0.02f);
        }
    }
    //IEnumerator Fire1()
    //{
    //}
    //IEnumerator Fire2()
    //{
    //}
    //IEnumerator Fire3()
    //{
    //}
}
