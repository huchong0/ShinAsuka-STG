using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {
    GameObject message;
    public List<Enemy> Enemies;
    public int Vehicle;//玩家指定的机体编号
    public GameObject[] Vehicles;
    public GameObject Player;
    public Text PlayerText;
    public Text BombText;
    public Text Score;
    public Text GameOver;
    


    public GameObject[] ClassOfEnemies;
    public GameObject[] EnemyGroups;

    public int LeftBombs;
    public int LeftPlayers;

    public GameObject[] DeadSound;
    public GameObject Music;
    public GameObject BombSound;

    private int choice;
    private int score=0;

    // Use this for initialization
    private void Awake()
    {
        Enemies = new List<Enemy>();
        message = GameObject.Find("Message");
        choice=0;
        if (message!=null)
        {
            choice = message.GetComponent<ChoiceMess>().choice;
            GeneralizeVehicle(choice);
        }
        else //测试代码
        {
            choice = 0;
            GeneralizeVehicle(choice);
        }

        PlayerText.text = "Player: " + LeftPlayers.ToString();
        BombText.text = "Bomb: " + LeftBombs.ToString();

        PlayerText.fontSize = Screen.width / 36;
        BombText.fontSize = Screen.width / 36;
        GameOver.fontSize = Screen.width / 36;
        Score.fontSize = Screen.width / 36;

    }
    void Start () {
        
        StartCoroutine(GenerateEnemies());
        StartCoroutine(GenerateGroups());
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Dead() //机体死亡后调用这个方法进行后续处理
    {
        //掉残，补B，检测游戏是否结束、若未结束则再生成一个机体供玩家操纵
        UseUp();
        if(LeftPlayers<=0)
        {
            gameover();
        }
        else
        GeneralizeVehicle(choice);
    }

    private void GeneralizeVehicle(int Choice)
    {
        Vehicle = Choice;
        Player = Instantiate(Vehicles[Vehicle]);
        Player.GetComponent<Player>().StageController = gameObject;

    }

    IEnumerator GenerateEnemies()
    {
        //利用协程来随着时间生成敌人，形成游戏版面流程
        while(true)
        {
            int index = Random.Range(0, ClassOfEnemies.Length);
            Instantiate(ClassOfEnemies[index], 
                new Vector3(Random.Range(-7.5f, 7.5f), -10, Random.Range(6, 6.5f)),
                new Quaternion());
            yield return new WaitForSeconds(2f);
        }
    }
    IEnumerator GenerateGroups()
    {
        //利用协程来随着时间生成敌人，形成游戏版面流程
        foreach(GameObject group in EnemyGroups)
        {
            group.SetActive(true);
            yield return new WaitForSeconds(10);
        }
    }

    public void GetBomb()
    {
        ++LeftBombs;
        BombText.text = "Bomb: " + LeftBombs.ToString();
    }

    public void UseBomb()
    {
        --LeftBombs;
        BombText.text = "Bomb: " + LeftBombs.ToString();
        PlayBombSound();
    }

    public void GetUp()
    {
        ++LeftPlayers;
        PlayerText.text = "Player: " + LeftPlayers.ToString();
    }

    public void UseUp()
    {
        --LeftPlayers;
        PlayerText.text = "Player: " + LeftPlayers.ToString();

    }

    private void gameover()
    {
        GameOver.text = "GameOver \n Put 'Esc' ";
        StopAllCoroutines();
    }
    public void GameClear()
    {
        GameOver.text = "GameClear \n Put 'Esc' ";
        StopAllCoroutines();
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    public void PlayExplosionSound()
    {
        var temp = DeadSound[Random.Range(0, DeadSound.Length)];
        temp.GetComponent<AudioSource>().Play();
    }

    public void PlayBombSound()
    {
        BombSound.GetComponent<AudioSource>().Play();
    }

    public void GetScore()
    {
        score += 100;
        Score.text = "Score: " + score.ToString();
    }


}
