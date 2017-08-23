using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontMissile : MonoBehaviour {
    public GameObject Explosion;
    public float Acceleration;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        var vel = GetComponent<Rigidbody>().velocity;
        var pos = transform.position;
        transform.position = new Vector3(pos.x + Random.Range(-0.1f, 0.1f), pos.y, pos.z);
        GetComponent<Rigidbody>().velocity = new Vector3(vel.x, vel.y, vel.z + Random.Range(-0.3f, 0.3f));
    }

    private void FixedUpdate()
    {
        var vel = GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().velocity = new Vector3(vel.x, vel.y, vel.z + Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var explosion = Instantiate(Explosion, transform.position, new Quaternion());
            Destroy(explosion, 3);

        }
    }

}
