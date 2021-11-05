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

    public AudioSource[] audioSources;

    public static GameCtrl4_0 instance;

    // GameCtrl 인스턴스화
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSources[0].Play();
        StartCoroutine(NoticeMsg());
    }

    void Update()
    {
        // if (greenBtn)
        // {
        //     buttons[1].GetComponent<Animator>().SetBool("blueBtn", true);
        // }
        // if (greenBtn && blueBtn)
        // {
        //     buttons[2].GetComponent<Animator>().SetBool("redBtn", true);
        // }
        // if (greenBtn && blueBtn && redBtn)
        // {
        //     buttons[3].GetComponent<Animator>().SetBool("stopBtn", true);
        // }
        if (greenBtn)
        {
            Debug.Log("greenBtn이 true로 : " + greenBtn);
            buttons[1].GetComponent<Animator>().SetBool("blueBtn", true);
            //buttons[0].GetComponent<Animator>().SetBool("greenBtn", false);
        }
        if (greenBtn && blueBtn)
        {
            buttons[2].GetComponent<Animator>().SetBool("redBtn", true);
            //buttons[1].GetComponent<Animator>().SetBool("blueBtn", false);
        }
        if (greenBtn && blueBtn && redBtn)
        {
            buttons[3].GetComponent<Animator>().SetBool("stopBtn", true);
            //buttons[2].GetComponent<Animator>().SetBool("redBtn", false);
        }
        if (stopBtn)
        {
            stopBtn = false;
            StartCoroutine(CompleteBtn());
        }
    }

    void PlaySound()
    {
        audioSources[1].Play();
    }

    IEnumerator NoticeMsg()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(2.0f);
            noticeMsg[i].SetActive(true);
            yield return new WaitForSeconds(3.0f);
            noticeMsg[i].SetActive(false);
        }
        noticeMsg[2].SetActive(true);
        yield return new WaitForSeconds(5.0f);
        noticeMsg[2].SetActive(false);
        buttons[0].GetComponent<Animator>().SetBool("greenBtn", true);
    }

    IEnumerator CompleteBtn()
    {
        Debug.Log("버튼 모두 완성");
        audioSources[1].Play();
        yield return new WaitForSeconds(1.0f);
        audioSources[0].Stop();
        yield return new WaitForSeconds(4.0f);
        GameObj.instance.leftCtrlSaber.GetComponent<Raycast04_0>().enabled = false;
        GameObj.instance.rightCtrlSaber.GetComponent<Raycast04_0>().enabled = false;
        SceneLoader.Instance.LoadNewScene("Chapter04_1_blackUniverse");
    }
}
