using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotation : MonoBehaviour {
    public float tilt;
    public int model;
    // Use this for initialization
    void Start () {
		
	}

    private void FixedUpdate()
    {

        float horizontal =transform.parent.GetComponent<Rigidbody>().velocity.x;
        float rotation = horizontal * -tilt;
        if(horizontal!=0)
        {
            rotation = horizontal * -tilt;
        }
        
        if (model == 3) transform.rotation = Quaternion.Euler(-90 + rotation, -90, 90);
        else if (model == 2) transform.rotation = Quaternion.Euler(0, 180, -rotation * 1.3f);
        else transform.rotation = Quaternion.Euler(0, 0, rotation);

    }
}
