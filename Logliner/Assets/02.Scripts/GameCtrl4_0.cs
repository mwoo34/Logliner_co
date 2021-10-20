using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl4_0 : MonoBehaviour
{
    public GameObject xrRig;
    public GameObject[] noticeMsg;
    private int msgPos = 0;

    public Button[] buttons;
    private int greenBtn, blueBtn, redBtn;

    void Start()
    {
        // 0은 실패 이후 장면, 1은 성공 이후 장면
        GameObj.ch4FailorSucces = 0;
        xrRig = GameObject.FindWithTag("XRRIG");
        StartCoroutine(NoticeMsg());
    }

    void Update()
    {
        
    }

    IEnumerator NoticeMsg()
    {
        yield return new WaitForSeconds(3.0f);
        noticeMsg[msgPos].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        noticeMsg[msgPos++].SetActive(false);
        yield return new WaitForSeconds(3.0f);
        noticeMsg[msgPos].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        noticeMsg[msgPos++].SetActive(false);
        yield return new WaitForSeconds(3.0f);
        noticeMsg[msgPos].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        noticeMsg[msgPos++].SetActive(false);
    }
}
