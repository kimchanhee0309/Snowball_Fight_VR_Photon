using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
    //싱글턴 접근용 프로퍼티
    public static GameManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }

            return m_instance;
        }
    }

    private static GameManager m_instance;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;

    public GameObject Gameovercanvas;

    float setTime = 180;
    private int score = 0;

    public bool isGameover = false;

    int min;
    float sec;
    
    private void Awake()
    {
        if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int newScore)
    {
        if(!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + newScore;

        }
    }
    void Update()
    {
        setTime -= Time.deltaTime;

        if(setTime >= 60f)
        {
            min = (int)setTime / 60;
            sec = setTime % 60;
            timeText.text = "Time " + min + ":" + (int)sec;
        }

        if (setTime < 60f)
        {
            timeText.text = "Time " + (int)setTime;
        }

        if(setTime <= 0)
        {
            timeText.text = "Time : 0";
            EndGame();
        }
    }

    public void EndGame()
    {
        isGameover = true;
        Gameovercanvas.SetActive(true);
    }
}
