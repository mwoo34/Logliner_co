using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

public class GameCtrl4_1 : MonoBehaviour
{
    public GameObject[] uiMsg;
    private int uiPos = 0;
    private int gameState;
    //public PlayableDirector playableDirector;
    //public TimelineAsset timeline;
    public GameObject[] planets;
    public Animator anim;
    public Button btn;

    // 로딩 바 부분
    private float initLoding = 0.05f;
    public float currLoding;
    public Image lodingBar;
    private float chargeAmount;
    private float maxAmount;
    public TMP_Text textField;

    void Start()
    {
        if (GameObj.checkGameSuccess == 3)
        {
            gameState = 0; // 실패 상태 검은 우주
            chargeAmount = 0.01f;
            maxAmount = 0.4f;
        }
        else if (GameObj.checkGameSuccess == 4)
        {
            gameState = 1; // 성공 상태 검은 우주
            chargeAmount = 0.02f;
            maxAmount = 1.0f;
        }
        lodingBar.fillAmount = 0.05f;
        Debug.Log("gamestate : " + gameState);
        //gameState = GameObj.checkGameSuccess;
        StartCoroutine(NoticeMsg());
        //btn.onClick.AddListener
    }

    void Update()
    {
        
    }

    IEnumerator NoticeMsg()
    {
        yield return new WaitForSeconds(3.0f);
        uiMsg[gameState].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        uiMsg[gameState].SetActive(false);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(ShowAnim());
    }

    IEnumerator ShowAnim()
    {
        MovePlanet();
        yield return new WaitForSeconds(8.0f);
        for (int i = 2; i < 5; i++)
        {
            uiMsg[i].SetActive(true);
        }
        btn.onClick.AddListener(Display);
    }

    public void MovePlanet()
    {
        anim.SetBool("MovePlanet", true);
    }

    public void Display()
    {
        StartCoroutine(ChargeLoading());
    }

    IEnumerator ChargeLoading()
    {
        DisplayLoding();
        yield return new WaitForSeconds(0.1f);
        if (lodingBar.fillAmount <= maxAmount)
            StartCoroutine(ChargeLoading());
        else
            StopAllCoroutines();
    }

    void DisplayLoding()
    {
        lodingBar.fillAmount += chargeAmount;
    }
}
