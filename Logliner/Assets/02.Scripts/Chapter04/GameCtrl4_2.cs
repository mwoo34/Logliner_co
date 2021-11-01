using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl4_2 : MonoBehaviour
{
    private int gameState;
    public GameObject[] noticeMsg;
    private int msgPos = 0;
    public GameObject[] grounds;
    public GameObject windowBar;

    // 정화차량 탑승한 주인공의 위치 담을 변수
    public Transform playerTr;
    // 도착지의 위치 담을 변수
    public Transform windowTr;
    private bool _distance;

    void Start()
    {
        windowBar.GetComponent<Animator>().SetBool("onLight", true);
        playerTr = GameManager.Instance._XRrig.GetComponent<Transform>();
        if (GameObj.checkGameSuccess == 3)
        {
            gameState = 0;
        }
        else if (GameObj.checkGameSuccess == 4)
        {
            gameState = 1;
        }
        grounds[gameState].SetActive(true);
        StartCoroutine(PlayerBehaviour());
    }

    void Update()
    {
        // if (_distance)
        // {
        //     _distance = false;
        //     StartCoroutine(NoticeMsg());
        // }
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
        float distance = Vector3.Distance(windowTr.position, playerTr.position);
        Debug.Log("주인공과 창문 거리 : " + distance);
        if (distance < 3.0f)
        {
            StopAllCoroutines();
            GameObj04.instance._distance = true;
            GameObj04.instance.state = gameState;
            //StartCoroutine(NoticeMsg());
        }
    }

    // IEnumerator NoticeMsg()
    // {
    //     yield return new WaitForSeconds(3.0f);
    //     noticeMsg[gameState].SetActive(true);
    // }
}
