using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControllerC : MonoBehaviour {
    public GameObject MainBullet;
    private int Power
    {
        get; set;
    }
    public float IntervalTime;
    public float MissileIntervalTime;
    private float NextTime;
    private float MissileNextTime;
    public GameObject FireSpot;

    public GameObject AuxBullet;
    public GameObject[] Auxor;
    public GameObject Model;
    private bool IsSuper = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Super());
        Power = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (NextTime < Time.time)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                switch (Power)
                {
                    case 0:
                        StartCoroutine(Fire0());
                        break;
                    case 1:
                        StartCoroutine(Fire0());
                        Fire1();
                        break;
                    case 2:
                        StartCoroutine(Fire2());
                        Fire1();
                        break;
                    default:
                        StartCoroutine(Fire2());
                        Fire3();
                        break;

                }
                NextTime = Time.time + IntervalTime;
            }
        }
    }
    IEnumerator Fire0()
    {
        for (int i = 0; i < 4; ++i)
        {
            Vector3 position = FireSpot.transform.position;
            Instantiate(MainBullet,
                new Vector3(position.x - 0.05f, position.y, position.z + 0.5f),
                new Quaternion());
            Instantiate(MainBullet,
                new Vector3(position.x + 0.05f, position.y, position.z + 0.5f),
                new Quaternion());
            yield return new WaitForSeconds(0.03f);
        }
    }
    void Fire1()
    {
        if(Time.time>=MissileNextTime)
        {
            MissileNextTime = Time.time + MissileIntervalTime;
            Instantiate(AuxBullet,new Vector3(Auxor[0].transform.position.x, Auxor[0].transform.position.y, Auxor[0].transform.position.z),new Quaternion());
            Instantiate(AuxBullet, new Vector3(Auxor[1].transform.position.x, Auxor[1].transform.position.y, Auxor[1].transform.position.z), new Quaternion());
        }
        
    }
    IEnumerator Fire2()
    {
        for (int i = 0; i < 4; ++i)
        {
            Vector3 position = FireSpot.transform.position;
            Instantiate(MainBullet,
                new Vector3(position.x - 0.05f, position.y, position.z + 0.5f),
                new Quaternion());
            Instantiate(MainBullet,
                new Vector3(position.x + 0.05f, position.y, position.z + 0.5f),
                new Quaternion());
            Instantiate(MainBullet,
                new Vector3(position.x - 0.15f, position.y, position.z + 0.5f),
                new Quaternion());
            Instantiate(MainBullet,
                new Vector3(position.x + 0.15f, position.y, position.z + 0.5f),
                new Quaternion());
            yield return new WaitForSeconds(0.03f);
        }

    }
    void Fire3()
    {
        if (Time.time >= MissileNextTime)
        {
            MissileNextTime = Time.time + MissileIntervalTime;
            Instantiate(AuxBullet, new Vector3(Auxor[0].transform.position.x, Auxor[0].transform.position.y, Auxor[0].transform.position.z), new Quaternion());
            Instantiate(AuxBullet, new Vector3(Auxor[1].transform.position.x, Auxor[1].transform.position.y, Auxor[1].transform.position.z), new Quaternion());
            Instantiate(AuxBullet, new Vector3(Auxor[2].transform.position.x, Auxor[2].transform.position.y, Auxor[2].transform.position.z), new Quaternion());
            Instantiate(AuxBullet, new Vector3(Auxor[3].transform.position.x, Auxor[3].transform.position.y, Auxor[3].transform.position.z), new Quaternion());

        }
    }

    public void GetPower()
    {
        if (Power == 3) return;
        else ++Power;
        switch (Power)
        {
            case 1:
                Auxor[0].SetActive(true);
                Auxor[1].SetActive(true);
                break;

            case 3:
                Auxor[2].SetActive(true);
                Auxor[3].SetActive(true);

                break;

        }
    }
    IEnumerator Super()
    {
        IsSuper = true;
        gameObject.GetComponent<Collider>().enabled = false;
        float endTime = Time.time + 3f;
        while (endTime >= Time.time)
        {
            Model.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            Model.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        IsSuper = false;
        gameObject.GetComponent<Collider>().enabled = true;


    }
}
