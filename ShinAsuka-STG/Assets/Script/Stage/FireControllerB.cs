using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControllerB : MonoBehaviour {
    public GameObject MainBullet;
    public int Power
    {
        get; set;
    }
    public float IntervalTime;
    public GameObject FireSpot;
    public GameObject Model;




    public GameObject AuxBullet;
    public GameObject[] Auxor;
    public List<Enemy> Enemies;

    private float NextTime;
    private bool IsSuper = false;


    // Use this for initialization
    void Start()
    {
        Power = 3;
    }
    private void Awake()
    {
        StartCoroutine(Super());
        GameObject temp = GameObject.Find("StageController");
        var Enemies = temp.GetComponent<StageController>().Enemies;
        this.Enemies = Enemies;
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
            yield return new WaitForSeconds(0.02f);
        }
    }
    void Fire1()
    {
        var bullet1 = Instantiate(AuxBullet, Auxor[0].transform.position,new Quaternion());
        var bullet2 = Instantiate(AuxBullet, Auxor[1].transform.position, new Quaternion());
        bullet1.GetComponent<GuideMissile>().Enemies = Enemies;
        bullet2.GetComponent<GuideMissile>().Enemies = Enemies;
        //bullet1.transform.parent = transform;
        //bullet2.transform.parent = transform;
    }
    IEnumerator Fire2()
    {
        for (int i = 0; i < 6; ++i)
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

            yield return new WaitForSeconds(0.02f);
        }

    }
    void Fire3()
    {
        var bullet1 = Instantiate(AuxBullet, Auxor[2].transform.position, new Quaternion());
        var bullet2 = Instantiate(AuxBullet, Auxor[3].transform.position, new Quaternion());
        bullet1.GetComponent<GuideMissile>().Enemies = Enemies;
        bullet2.GetComponent<GuideMissile>().Enemies = Enemies;
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
