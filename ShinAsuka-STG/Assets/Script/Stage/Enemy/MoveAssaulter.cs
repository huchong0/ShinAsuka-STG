using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAssaulter : MonoBehaviour {
    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -Speed);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
