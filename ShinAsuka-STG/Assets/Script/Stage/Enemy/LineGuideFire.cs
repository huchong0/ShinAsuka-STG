using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGuideFire : MonoBehaviour {
    public GameObject StageController;
    public GameObject Bullet;
    public float Speed;
    public int Times = -1;
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
        GameObject end=null;
        if(StageController!=null)
        {
            end = StageController.GetComponent<StageController>().Player;
        }
        while(Times!=0)
        {
            yield return new WaitForSeconds(Interval);
            Vector3 direction;
            if(end!=null)
            {
                direction = end.transform.position - transform.position;
                direction.Normalize();
            }
            else
            {
                direction = -transform.forward;
            }

            var bullet1 = Instantiate(Bullet, transform.position, Quaternion.Euler(direction));
            bullet1.GetComponent<Rigidbody>().velocity = Speed * direction;
            

            bullet1 = Instantiate(Bullet, transform.position, Quaternion.Euler(direction));
            bullet1.GetComponent<Rigidbody>().velocity = Speed * direction * 0.90f;

            bullet1 = Instantiate(Bullet, transform.position, Quaternion.Euler(direction));
            bullet1.GetComponent<Rigidbody>().velocity = Speed * direction * 0.75f;

            bullet1 = Instantiate(Bullet, transform.position, Quaternion.Euler(direction));
            bullet1.GetComponent<Rigidbody>().velocity = Speed * direction * 0.55f;

            bullet1 = Instantiate(Bullet, transform.position, Quaternion.Euler(direction));
            bullet1.GetComponent<Rigidbody>().velocity = Speed * direction * 0.30f;

            --Times;
        }
    }
}
