using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject StageController;
    public GameObject BOOM;
    object mutex = new object();
    private bool HaveDead = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="EnemyBullet" || other.tag=="Enemy")
        {
            lock(mutex)
            {
                if(!HaveDead)
                {
                    HaveDead = true;
                    Instantiate(BOOM, transform.position, transform.rotation);
                    StageController.GetComponent<StageController>().Dead();
                    Destroy(gameObject);
                }
            }
        }
        else if (other.tag == "Bomb")
        {
            other.gameObject.SetActive(false);
            StageController.GetComponent<StageController>().GetBomb();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Up")
        {
            other.gameObject.SetActive(false);
            StageController.GetComponent<StageController>().GetUp();
            Destroy(other.gameObject);
        }
    }
}
