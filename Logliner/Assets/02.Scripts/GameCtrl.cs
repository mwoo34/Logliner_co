using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    public GameObject resumeMsg;
    public int heartCount = 5;
    public GameObject[] hpImages;
    public GameObject[] slotImages;
    public int slotPos = 0;
    private int remainRound = 4;
    private bool isGameOver = false;
    public bool changeHeart = false;

    private AudioSource audio;

    // GameCtrl 인스턴스화를 위해 선언
    public static GameCtrl instance;

    // 게임의 종료 여부를 저장할 프로퍼티
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                //CancelInvoke("CreateMonster");
                Debug.Log("Loss All Heart");
                audio.Stop();
                //IsGameOver = false;
                ResumeGame();
            }
        }
    }

    // GameCtrl 인스턴스화
    void Awake() 
    {
        instance = this;    
    }
    
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void ResumeGame() {
        //StopAllCoroutines();
        //isGameOver = false;
        IsGameOver = false;
        resumeMsg.SetActive(true);
        changeHeart = true;
    }
}
