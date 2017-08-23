using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControllerD : MonoBehaviour {
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


    private bool IsSuper = false;
    private float NextTime;

    // Use this for initialization
    private void Awake()
    {
        StartCoroutine(Super());
        Enemies = GameObject.Find("StageController").GetComponent<StageController>().Enemies;
    }
    void Start()
    {
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
        for (int i = 0; i < 3; ++i)
        {
            Vector3 position = FireSpot.transform.position;
            var temp = Instantiate(MainBullet,
                new Vector3(position.x, position.y, position.z + 0.5f),
                new Quaternion());

            temp = Instantiate(MainBullet,
                new Vector3(position.x - 0.2f, position.y, position.z + 0.5f),
                 Quaternion.Euler(new Vector3(0,-15,0)));
            temp.GetComponent<Rigidbody>().velocity = new Vector3(-2.7f, 0, 10);

            temp = Instantiate(MainBullet,
                new Vector3(position.x + 0.2f, position.y, position.z + 0.5f),
                 Quaternion.Euler(new Vector3(0, 15, 0)));
            temp.GetComponent<Rigidbody>().velocity = new Vector3(2.7f, 0, 10);
            yield return new WaitForSeconds(0.04f);
        }
    }
    void Fire1()
    {
        var pos1 = Auxor[0].transform.position;
        var pos2 = Auxor[1].transform.position;

        if (Enemies.Count==0)
        {
            Instantiate(AuxBullet, pos1, new Quaternion());
            Instantiate(AuxBullet, pos2, new Quaternion());
            return;
        }

        float speed = AuxBullet.GetComponent<Bullet>().speed;
        var EndPos = Enemies[Enemies.Count / 2].transform.position;

        float angle1 =  Mathf.Atan2(EndPos.x - pos1.x, EndPos.z - pos1.z);
        float angle2 = Mathf.Atan2(EndPos.x - pos2.x, EndPos.z - pos2.z);

        var bullet1 = Instantiate(AuxBullet, pos1, Quaternion.Euler(0,angle1/Mathf.PI*180,0));
        var bullet2 = Instantiate(AuxBullet, pos2, Quaternion.Euler(0, angle2 / Mathf.PI * 180, 0));

        //bullet1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle1));
        bullet1.GetComponent<Rigidbody>().velocity = new Vector3(speed* Mathf.Sin(angle1), 0, speed * Mathf.Cos(angle1));

        //bullet2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle2));
        bullet2.GetComponent<Rigidbody>().velocity = new Vector3(speed * Mathf.Sin(angle2), 0, speed * Mathf.Cos(angle2));

        

    }
    IEnumerator Fire2()
    {
        for (int i = 0; i < 4; ++i)
        {
            Vector3 position = FireSpot.transform.position;
            var temp = Instantiate(MainBullet,
                new Vector3(position.x-0.1f, position.y, position.z + 0.5f),
                new Quaternion());

            temp = Instantiate(MainBullet,
                new Vector3(position.x+0.1f, position.y, position.z + 0.5f),
                new Quaternion());


            temp = Instantiate(MainBullet,
                new Vector3(position.x - 0.2f, position.y, position.z + 0.5f),
                 Quaternion.Euler(new Vector3(0, -15, 0)));
            temp.GetComponent<Rigidbody>().velocity = new Vector3(-2.7f, 0, 10);

            temp = Instantiate(MainBullet,
                new Vector3(position.x + 0.2f, position.y, position.z + 0.5f),
                 Quaternion.Euler(new Vector3(0, 15, 0)));
            temp.GetComponent<Rigidbody>().velocity = new Vector3(2.7f, 0, 10);

            temp = Instantiate(MainBullet,
                new Vector3(position.x + 0.2f, position.y, position.z + 0.5f),
                 Quaternion.Euler(new Vector3(0, 30, 0)));
            temp.GetComponent<Rigidbody>().velocity = new Vector3(5.88f, 0, 10);

            temp = Instantiate(MainBullet,
                new Vector3(position.x -0.2f, position.y, position.z + 0.5f),
                 Quaternion.Euler(new Vector3(0, -30, 0)));
            temp.GetComponent<Rigidbody>().velocity = new Vector3(-5.88f, 0, 10);

            yield return new WaitForSeconds(0.04f);
        }

    }
    void Fire3()
    {

        var pos1 = Auxor[2].transform.position;
        var pos2 = Auxor[3].transform.position;
        if (Enemies.Count == 0)
        {
            Instantiate(AuxBullet, pos1, new Quaternion());
            Instantiate(AuxBullet, pos2, new Quaternion());
            return;
        }

        float speed = AuxBullet.GetComponent<Bullet>().speed;
        var EndPos = Enemies[0].transform.position;


        float angle1 = Mathf.Atan2(EndPos.x - pos1.x, EndPos.z - pos1.z);
        float angle2 = Mathf.Atan2(EndPos.x - pos2.x, EndPos.z - pos2.z);

        var bullet1 = Instantiate(AuxBullet, pos1, Quaternion.Euler(0, angle1 / Mathf.PI * 180, 0));
        var bullet2 = Instantiate(AuxBullet, pos2, Quaternion.Euler(0, angle2 / Mathf.PI * 180, 0));

        //bullet1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle1));
        bullet1.GetComponent<Rigidbody>().velocity = new Vector3(speed * Mathf.Sin(angle1), 0, speed * Mathf.Cos(angle1));

        //bullet2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle2));
        bullet2.GetComponent<Rigidbody>().velocity = new Vector3(speed * Mathf.Sin(angle2), 0, speed * Mathf.Cos(angle2));


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
