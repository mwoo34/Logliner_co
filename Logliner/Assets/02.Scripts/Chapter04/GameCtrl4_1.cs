using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl4_1 : MonoBehaviour
{
    public GameObject[] noticeMsg;
    private int msgPos = 0;
    private int gameState;

    // 정화차량 탑승한 주인공의 위치 담을 변수
    public Transform playerTr;
    // 도착지의 위치 담을 변수
    public Transform landTr;

    public Button[] buttons;

    void Start()
    {
        if (GameObj.checkGameSuccess == 3)
        {
            GameObj.checkGameSuccess = 1;
        }
        else if (GameObj.checkGameSuccess == 4)
        {
            GameObj.checkGameSuccess = 2;
        }
        gameState = GameObj.checkGameSuccess;
        
    }

    void Update()
    {
        
    }

    IEnumerator NoticeMsg()
    {
        yield return new WaitForSeconds(3.0f);
        noticeMsg[gameState - 1].SetActive(true);
    }
}
