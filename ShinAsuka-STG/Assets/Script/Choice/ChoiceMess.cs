using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMess : MonoBehaviour {
    public int choice;
	// Use this for initialization
	void Start () {
		if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
	}
	static ChoiceMess instance;
    // Update is called once per frame
    void Update () {
		
	}
}
