using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    public float Speed;
    private Vector3 Direction;
	// Use this for initialization
	void Start () {
		
	} 

    private void Awake()
    {

        Direction = new Vector3(Random.Range(-0.3f, 0.3f), 0, -1);
        Direction.Normalize();
        GetComponent<Rigidbody>().velocity = Direction * Speed;
        GetComponent<Rigidbody>().angularVelocity =
                new Vector3(Random.Range(-3, 3),
                Random.Range(-3, 3),
                Random.Range(-3, 3));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
