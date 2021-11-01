using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;
using UnityEngine.InputSystem;

public class GameCtrl4_1 : MonoBehaviour
{
    private int gameState;
    public GameObject[] uiMsg;
    private int uiPos = 0;
    public GameObject inputActive;
    public bool _inputActive;

    public GameObject[] planets;
    public Animator anim;
    public Button btn;
    public GameObject[] dissolve;

    // 로딩 바 부분
    private float initLoding = 0.05f;
    public float currLoding;
    public Image lodingBar;
    private float chargeAmount;
    private float maxAmount;
    int value = 0;
    public TMP_Text textField;

    public static GameCtrl4_1 instance;

    void Awake()
    {
        instance = this;
    }

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
    }

    void Update()
    {
        if (_inputActive)
        {
            Display();
        }
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
        //inputActive.SetActive(true);
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
    }

    void DisplayLoding()
    {
        lodingBar.fillAmount += chargeAmount;
        value = (int)(lodingBar.fillAmount * 100);
        textField.text = "지구화 진행도 " + value + "%";
        StartCoroutine(DissolveEffect());
    }

    IEnumerator DissolveEffect()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log(gameState + "활성화");
        if (value == 40 || value == 100)
            dissolve[gameState].SetActive(true);
    }
}
