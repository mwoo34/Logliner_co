using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl4_0 : MonoBehaviour
{
    public GameObject[] noticeMsg;
    private int msgPos = 0;

    public Button[] buttons;
    private int greenBtn, blueBtn, redBtn;
    private bool btnComplete;

    void Start()
    {
        // 0은 실패 이후 장면, 1은 성공 이후 장면
        //GameObj.ch4FailorSucces = 0;
        StartCoroutine(NoticeMsg());
    }

    void Update()
    {
        if (btnComplete)
        {
            SceneLoader.Instance.LoadNewScene("Chapter04_1_blackUniverse");
        }
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
