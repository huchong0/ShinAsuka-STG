using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boarder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Enemy")
        {
            other.GetComponent<Enemy>().removeFromList();
        }
        Destroy(other.gameObject);
    }
}
