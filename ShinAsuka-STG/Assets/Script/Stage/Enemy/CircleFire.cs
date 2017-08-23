using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFire : MonoBehaviour {
    public GameObject Bullet;
    public float Speed;
    public float Interval;
    public float Times=-1;

    // Use this for initialization
    void Start () {
        StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Fire()
    {
        while(Times!=0)
        {
            for (float i = 0; i < 360; i += 10)
            {

                Vector3 direction = new Vector3(Mathf.Sin(i / 360 * 6.28f), 0, Mathf.Cos(i / 360 * 6.28f));
                var temp = Instantiate(Bullet, transform.position, new Quaternion());
                temp.GetComponent<Rigidbody>().velocity = direction * Speed;
            }
            yield return new WaitForSeconds(Interval);
            --Times;
        }

    }


}
