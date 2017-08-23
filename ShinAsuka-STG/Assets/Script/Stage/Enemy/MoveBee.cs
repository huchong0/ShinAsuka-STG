using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBee : MonoBehaviour {
    public float Speed;
    public float Angle;
    public float TurnSpotZ;

    private float Distance;
    private bool HaveTurned = false;

    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = transform.rotation *new Vector3(0, 0, -Speed);

    }



    // Update is called once per frame
    void Update () {
        if(!HaveTurned)
        {
            if (transform.position.z < TurnSpotZ)
            {
                HaveTurned = true;
                StartCoroutine(Turn(Angle));
            }
        }
    }

    


    IEnumerator Turn(float angle)
    {
        for(int i=0;i<50;++i)
        {
            transform.Rotate(new Vector3(0, angle/50, 0));
            GetComponent<Rigidbody>().velocity = transform.rotation * new Vector3(0, 0, -Speed);
            yield return new WaitForSeconds(0.01f);
        }

    }
}
