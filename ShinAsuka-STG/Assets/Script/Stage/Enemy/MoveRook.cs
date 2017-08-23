using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRook : MonoBehaviour {
    public float xSpeed;
    public float zSpeed;


    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, 0, zSpeed);
        var Laser = transform.Find("Laser");
        if(Laser!=null)Laser.GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, 0, zSpeed); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
