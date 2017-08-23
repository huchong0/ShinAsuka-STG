using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControllerA : MonoBehaviour {
    public GameObject MainBullet;
    public int Power
    {
        get; set;
    }
    public float IntervalTime;

    public GameObject FireSpot;
    public GameObject AuxBullet;
    public GameObject[] Auxor;
    public GameObject Model;


    private float NextTime;
    private GameObject[] Lasers = new GameObject[4];
    private bool IsSuper = false;

    // Use this for initialization
    void Start()
    {
        Power = 3;
        StartCoroutine(Super());
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
                    case 3:
                        StartCoroutine(Fire2());
                        Fire1();
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
            yield return new WaitForSeconds(0.04f);
        }
    }
    void Fire1()
    {
        if(Lasers[0]==null || Lasers[0].gameObject.GetComponent<Renderer>().material.color.a<=0.02)
        {
            if (Lasers[0] != null)
            {
                Destroy(Lasers[0]);
                Destroy(Lasers[1]);
            }
            Transform pos1 = Auxor[0].transform;
            Lasers[0] = Instantiate(AuxBullet, 
                new Vector3(pos1.position.x,pos1.position.y,pos1.position.z+6),
                Quaternion.Euler(90,0,0));
            Lasers[0].transform.parent = gameObject.transform;

            Transform pos2 = Auxor[1].transform;
            Lasers[1] = Instantiate(AuxBullet,
                new Vector3(pos2.position.x, pos2.position.y, pos2.position.z+6),
                Quaternion.Euler(90, 0, 0));
            Lasers[1].transform.parent = gameObject.transform;
        }
    }
    IEnumerator Fire2()
    {
        for (int i = 0; i < 5; ++i)
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
            yield return new WaitForSeconds(0.04f);
        }

    }
    void Fire3()
    {
        if (Lasers[2] == null || Lasers[2].gameObject.GetComponent<Renderer>().material.color.a <= 0.02)
        {
            if (Lasers[2] != null)
            {
                Destroy(Lasers[2]);
                Destroy(Lasers[3]);
            }
            Transform pos1 = Auxor[2].transform;
            Lasers[2] = Instantiate(AuxBullet,
                new Vector3(pos1.position.x+4f, pos1.position.y, pos1.position.z + 5.3f),
                Quaternion.Euler(90, 30, 0));
            Lasers[2].transform.parent = gameObject.transform;

            Transform pos2 = Auxor[3].transform;
            Lasers[3] = Instantiate(AuxBullet,
                new Vector3(pos2.position.x-4f, pos2.position.y, pos2.position.z + 5.3f),
                Quaternion.Euler(90, -30, 0));
            Lasers[3].transform.parent = gameObject.transform;
        }

    }

    private void FixedUpdate()
    {
        for(int i=0;i<2;++i)
        {
            if (Lasers[i] != null)
            {
                Transform pos1 = Auxor[i].transform;
                Lasers[i].transform.position = new Vector3(pos1.position.x, pos1.position.y, pos1.position.z + 6);
                Lasers[i].transform.rotation = Quaternion.Euler(90, 0, 0);
            }
        }
        if(Lasers[2]!=null)
        {
            Transform pos1 = Auxor[2].transform;

            Lasers[2].transform.position = new Vector3(pos1.position.x + 4f, pos1.position.y, pos1.position.z + 5.3f);
            Lasers[2].transform.rotation = Quaternion.Euler(90, 30, 0);
        }
        if(Lasers[3]!=null)
        {
            Transform pos1 = Auxor[3].transform;

            Lasers[3].transform.position = new Vector3(pos1.position.x - 4f, pos1.position.y, pos1.position.z + 5.3f);
            Lasers[3].transform.rotation = Quaternion.Euler(90, -30, 0);

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
