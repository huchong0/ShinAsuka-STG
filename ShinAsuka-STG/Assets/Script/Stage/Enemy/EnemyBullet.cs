using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public float Speed;
    public Quaternion Direction;

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = Direction * new Vector3(0, 0, -Speed);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




}
