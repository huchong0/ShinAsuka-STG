using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float  speed;
    public GameObject bomb;
    private GameObject StageController;
	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        StageController = GameObject.Find("StageController");
    }
    // Update is called once per frame
    void Update () {
        
        

	}
    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().velocity = speed * new Vector3(horizontal, 0f, vertical);
        //transform.forward = speed * new Vector3(horizontal, 0f, vertical);

        var x = transform.position.x;
        var z = transform.position.z;

        x = Mathf.Clamp(x, -7.7f, 7.7f);
        z = Mathf.Clamp(z, -4.55f, 4.55f);
        transform.position = new Vector3(x, -10f, z);

        if(Input.GetKeyDown(KeyCode.X))
        {
            if(StageController.GetComponent<StageController>().LeftBombs>0)
            {
                Instantiate(bomb, transform.position, new Quaternion());
                StageController.GetComponent<StageController>().UseBomb();
            }
            
        }


    }




}
