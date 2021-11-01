using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl4_0 : MonoBehaviour
{
    public GameObject[] noticeMsg;

    public GameObject[] buttons;
    public BoxCollider[] btns;
    public bool greenBtn, blueBtn, redBtn, stopBtn;

    public static GameCtrl4_0 instance;

    // GameCtrl 인스턴스화
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // 0은 실패 이후 장면, 1은 성공 이후 장면
        //GameObj.ch4FailorSucces = 0;
        StartCoroutine(NoticeMsg());
    }

    void Update()
    {
        if (greenBtn)
        {
            buttons[1].GetComponent<Animator>().SetBool("blueBtn", true);
        }
        if (greenBtn && blueBtn)
        {
            buttons[2].GetComponent<Animator>().SetBool("redBtn", true);
        }
        if (greenBtn && blueBtn && redBtn)
        {
            buttons[3].GetComponent<Animator>().SetBool("stopBtn", true);
        }
        if (stopBtn)
        {
            StartCoroutine(CompleteBtn());
        }
    }

    IEnumerator NoticeMsg()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3.0f);
            noticeMsg[i].SetActive(true);
            yield return new WaitForSeconds(3.0f);
            noticeMsg[i].SetActive(false);
        }
        // yield return new WaitForSeconds(3.0f);
        // noticeMsg[msgPos].SetActive(true);
        // yield return new WaitForSeconds(3.0f);
        // noticeMsg[msgPos++].SetActive(false);
        // yield return new WaitForSeconds(3.0f);
        // noticeMsg[msgPos].SetActive(true);
        // yield return new WaitForSeconds(3.0f);
        // noticeMsg[msgPos++].SetActive(false);
        // yield return new WaitForSeconds(3.0f);
        // noticeMsg[msgPos].SetActive(true);
        // yield return new WaitForSeconds(3.0f);
        // noticeMsg[msgPos++].SetActive(false);
        buttons[0].GetComponent<Animator>().SetBool("greenBtn", true);
    }

    IEnumerator CompleteBtn()
    {
        Debug.Log("버튼 모두 완성");
        yield return new WaitForSeconds(3.0f);
        GameObj.instance.leftCtrlSaber.GetComponent<Raycast04_0>().enabled = false;
        GameObj.instance.rightCtrlSaber.GetComponent<Raycast04_0>().enabled = false;
        SceneLoader.Instance.LoadNewScene("Chapter04_1_blackUniverse_1030");
    }
}
