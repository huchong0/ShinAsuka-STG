using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQueen : MonoBehaviour {
    public float Speed;
    public float MovingTime;
    public Vector3 EndSpot;
	// Use this for initialization
	void Start () {
        StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Move()
    {
        Vector3 direction = EndSpot - transform.position;
        direction.Normalize();
        GetComponent<Rigidbody>().velocity = direction * Speed;
        yield return new  WaitForSeconds(MovingTime);

        while(true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * Speed / 5;
            yield return new WaitForSeconds(MovingTime);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1) * Speed / 5;
            yield return new WaitForSeconds(MovingTime);
        }
    }
}
