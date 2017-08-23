using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideFire : MonoBehaviour {
    public GameObject Bullet;
    public GameObject FireSpot;
    public float Speed;
    public float WaitTime;

    private GameObject Player;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("StageController").GetComponent<StageController>().Player;
        StartCoroutine(Fire());
    }

    private void Awake()
    {
        Player = GameObject.Find("StageController").GetComponent<StageController>().Player;
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(WaitTime);

        for (int i = 0; i < 6; ++i)
        {
            Vector3 directon = Player.transform.position - transform.position;
            directon.Normalize();
            var temp = Instantiate(Bullet, FireSpot.transform.position, FireSpot.transform.rotation);
            temp.GetComponent<Rigidbody>().velocity = directon * Speed;
            yield return new WaitForSeconds(0.8f);
        }
    }
}
