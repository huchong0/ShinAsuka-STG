using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFront : MonoBehaviour {
    public float Speed;

	// Use this for initialization
	void Start () {
        Vector3 direction = transform.forward;
        GetComponent<Rigidbody>().velocity = -Speed * transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        

    }
}
