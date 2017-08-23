using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    int State = 0;
    public Text[] Choices;
    public Text head;
    public Color Default;
    public AudioSource curse_move;
    public AudioSource curse_click;
    
    // Use this for initialization

    void Start () {
        Choices[State].color = Color.red;
        head.fontSize = Screen.width / 36 ;
        foreach(Text text in Choices)
        {
            text.fontSize = head.fontSize;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Choices[State].color = Default;
            ++State;
            State %= 3;
            Choices[State].color = Color.red;
            curse_move.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Choices[State].color = Default;
            --State;
            if (State < 0) State = 2;
            Choices[State].color = Color.red;
            curse_move.Play();
        }
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            curse_click.Play();
            
            //点击，切换场景


            if(State==0)SceneManager.LoadScene("Choice");
            if (State == 2) Application.Quit();
        }



    }


}
