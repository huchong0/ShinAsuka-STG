using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideMissile : MonoBehaviour {
    public List<Enemy> Enemies;
    public float ForceOfEngine;
    public float waitTime;
    public float speed;
    public GameObject Explosion;




    private bool Guide=false;
    private bool Change = true;
    private float FinalTime;
    private Enemy Aim;
    private Vector3 Direction= new Vector3(0,0,1);
    
    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        FinalTime = Time.time + waitTime;
        if(Enemies.Count!=0)
        {
            Aim = Enemies[0];
            CalculateDirection();
            Accelerate();
            Guide = true;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        }
    }

    private void FixedUpdate()
    {
        if(!Guide)
        {
            if(Time.time>=FinalTime)
            {
                Guide = true;
                Change = false;
            }
            else
            {
                if(Enemies.Count!=0)
                {
                    Aim = Enemies[0];
                    CalculateDirection();
                    Accelerate();
                    Guide = true;
                }
            }
        }
        else
        {
            if (Enemies.Count != 0)
            {
                if (Aim != Enemies[0])
                {
                    Guide = false;
                    //Change = false;
                }
            }
            else
            {
                Aim = null;
                Change = false;
            }

            if (Change)
            {
                CalculateDirection();
                Accelerate();
            }
            else
            {
                Accelerate();
            }
        }
    }

    // Update is called once per frame
    void Update () {
        Rotate();
	}

    void CalculateDirection()
    {
        float dx = Aim.transform.position.x - transform.position.x;
        float dz = Aim.transform.position.z - transform.position.z;
        float S = Mathf.Sqrt(dx * dx + dz * dz);

        Direction = new Vector3(dx / S, 0f, dz / S);
    }

    void Accelerate()
    {
        GetComponent<Rigidbody>().velocity = (Direction*speed);
    }

    void Rotate()
    {
        float angle1 = Mathf.Atan2(Direction.x, Direction.z);
        transform.rotation = Quaternion.Euler(0, angle1 / Mathf.PI * 180, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            var explosion = Instantiate(Explosion, transform.position, new Quaternion());
            Destroy(explosion, 3);

        }
    }
}
