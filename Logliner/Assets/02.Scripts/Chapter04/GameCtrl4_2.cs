using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl4_2 : MonoBehaviour
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
        StartCoroutine(PlayerBehaviour());
    }

    void Update()
    {
        
    }

    IEnumerator PlayerBehaviour()
    {
        CheckPlayerState();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(PlayerBehaviour());
    }

    // 매립지와 주인공 거리를 가져와서 상태를 변환시키는 함수
    void CheckPlayerState()
    {
        float distance = Vector3.Distance(landTr.position, playerTr.position);
        if (distance < 3.0f)
        {
            StartCoroutine(NoticeMsg());
        }
    }

    IEnumerator NoticeMsg()
    {
        yield return new WaitForSeconds(3.0f);
        noticeMsg[gameState - 1].SetActive(true);
    }
}
