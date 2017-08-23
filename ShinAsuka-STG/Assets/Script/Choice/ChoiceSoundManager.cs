using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSoundManager : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(instance);
            instance = this;
            DontDestroyOnLoad(this);
        }

        
    }
    void Start () {
	}
    static ChoiceSoundManager instance;
	
	// Update is called once per frame
	void Update () {
		
	}
}
