using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceController : MonoBehaviour {
    public GameObject[] models;
    public Text FireText;
    public Text SpeedText;
    public Text characteristicText;
    public GameObject cursor;
    public AudioSource CursorMove;
    public AudioSource CursorClick;
    public AudioSource CursorBack;


    int state;
    Vector3 zeroPosition;
    float distance=3;
    string[] Fires = { "★★★★", "★★★", "★★★★★", "★★★" };
    string[] Speeds = { "★★★★", "★★★★", "★★★", "★★★★★" };
    string[] Characteristics = { "激光穿透", "追踪导弹", "前方特化", "广域覆盖" };
    float[] distances = { -6, -3, 3, 6 };



    void Start () {
        state = 0;
        
        zeroPosition = cursor.transform.position;
        foreach(var model in models)
        {
            model.SetActive(false);
        }
        models[0].SetActive(true);

        int size = Screen.width / 25;
        FireText.fontSize = size;
        SpeedText.fontSize = size;
        characteristicText.fontSize = size;

        FireText.text = "火力：" + Fires[state];
        SpeedText.text = "速度：" + Speeds[state];
        characteristicText.text = Characteristics[state];
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            models[state].SetActive(false);
            ++state;
            state %= 4;

            cursor.transform.position = new Vector3(
                distances[state],
                zeroPosition.y,
                zeroPosition.z);




            models[state].SetActive(true);
            FireText.text = "火力：" + Fires[state];
            SpeedText.text= "速度：" + Speeds[state];
            characteristicText.text = Characteristics[state];
            CursorMove.Play();

        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            models[state].SetActive(false);
            --state;
            if (state < 0) state = 3;

            cursor.transform.position = new Vector3(
                distances[state],
                zeroPosition.y,
                zeroPosition.z);


            models[state].SetActive(true);
            FireText.text = "火力：" + Fires[state];
            SpeedText.text = "速度：" + Speeds[state];
            characteristicText.text = Characteristics[state];
            CursorMove.Play();
        }
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKey(KeyCode.Space))
        {
            //选好机体，载入下一场景（关卡1）
            CursorClick.Play();
            GameObject message = GameObject.Find("Message");
            message.GetComponent<ChoiceMess>().choice = state;
            SceneManager.LoadScene("Stage1");
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            CursorBack.Play();
            SceneManager.LoadScene("Menu");
        }

    }

}
