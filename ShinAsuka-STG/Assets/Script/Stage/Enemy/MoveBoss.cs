using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator Move()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-0.5f, 0, 0);
        yield return new WaitForSeconds(20f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);


    }
}
