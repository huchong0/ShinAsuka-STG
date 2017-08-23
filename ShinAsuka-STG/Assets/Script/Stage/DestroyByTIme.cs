using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTIme : MonoBehaviour {

    public float LeftTime;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, LeftTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
