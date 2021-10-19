using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    // 실수 가능한 횟수 담은 변수
    public int heartCount = 5;
    // 하트 객체 담을 변수
    public GameObject[] hpImages;
    // 슬롯 객체 담을 변수
    public GameObject[] slotImages;
    //public Sprite[] slot_sp;
    public Texture[] slotTex;
    public RawImage[] slotRawImage;
    // 현재 바뀔 슬롯 위치 값 담은 변수
    public int slotPos = 0;
    // 양 쪽 컨트롤이 같은 객체를 벨 때 ITEMBOX가 2개 베지 않도록 잠그는 변수
    public bool _lock = true;
    public GameObject spawnerCube;

    // 업무 재개 메시지 보관 변수
    public GameObject resumeMsg;
    public GameObject failMsg;
    public GameObject sucMsg;
    // 업무 재개 가능한 횟수 변수
    public int remainRound = 3;
    public GameObject timer;

    // 게임 상태 여부 0은 진행중, 1은 실패, 2는 성공
    public int GameSuccess = 0;
    private bool _gameSuccess = true;
    
    // 업무 남은 횟수 이미지 바꾸지 변수
    public Sprite whiteSprite;
    // 업무 남은 횟수 표시하는 객체 받아오기
    public GameObject[] fuelBtn;
    private bool gameOver = true;
    // 게임 실패 상태 여부 변수
    //private bool isGameOver = false;
    //public bool changeHeart = false;

    // public int saveSlotPos;
    // public int saveRemainRound;
    private bool isSave;

    public AudioSource audio;

    // GameCtrl 인스턴스화를 위해 선언
    public static GameCtrl instance;

    // 게임의 종료 여부를 저장할 프로퍼티
    // public bool IsGameOver
    // {
    //     get { return isGameOver; }
    //     set
    //     {
    //         isGameOver = value;
    //         if (isGameOver)
    //         {
    //             Debug.Log("Loss All Heart");
    //             audio.Stop();
    //             ResumeGame();
    //         }
    //     }
    // }

    // GameCtrl 인스턴스화
    void Awake()
    {
        instance = this;
    }
    
    // 내부 레지스터에 데이터를 가져와서 활성화 된 slot은 다시 활성화 하고
    // 내부 레지스터 값 지움
    void Start()
    {
        isSave = PlayerPrefs.HasKey("SlotPos");
        if (isSave)
        {
            Debug.Log("저장된 데이터가 있습니다");
            slotPos = PlayerPrefs.GetInt("SlotPos");
            remainRound = PlayerPrefs.GetInt("RemainRound");
            Debug.Log("현재 slotPos값 : " + slotPos);
            for (int i = 0; i < slotPos; i++)
            {
                slotImages[i].GetComponentInChildren<RawImage>().texture = slotTex[i];
                //slotImages[i].GetComponent<Image>().sprite = slot_sp[i];
            }
        }
        else
        {
            Debug.Log("저정된 데이터가 없습니다");
        }
        PlayerPrefs.DeleteAll();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // 게임 실패 후 업무재개 화면
    void Update()
    {
        if (gameOver && heartCount == 0)
        {
            gameOver = false;
            audio.Stop();
            ResumeGame();
        }
        if (GameSuccess == 2 && _gameSuccess)
        {
            _gameSuccess = false;
            spawnerCube.SetActive(false);
            audio.Stop();
            //GameSuccess = 0;
            //timer.SetActive(false);
            
            StartCoroutine(SucMsg());
        }
    }

    // 5개 목숨을 다 잃고 나타나는 메시지창과 몇번째 시도인지에 따라 메시지창에
    // 기회가 몇 번 남았는지 알리는 역할
    void ResumeGame() {
        //IsGameOver = false;
        resumeMsg.SetActive(true);
        remainRound -= 1;
        if (remainRound == 0)
        {
            resumeMsg.SetActive(false);
            //noticeMsg.SetActive(true);
            //GameObj.instance.checkGameSuccess = 0;
            
            StartCoroutine(FailMsg());
        }
        else if (remainRound > 0)
        {
            for (int i = 3; i > remainRound; i--)
            {
                fuelBtn[i - 1].GetComponent<Image>().sprite = whiteSprite;
            }
        }
        
        // PlayerPrefs.SetInt("SlotPos", slotPos);
        // PlayerPrefs.SetInt("RemainRound", remainRound);
        // PlayerPrefs.Save();

        // if (remainRound > 0)
        // {
        //     fuelBtn[remainRound - 1].GetComponent<Image>().sprite = whiteSprite;
        //     remainRound -= 1;
        // }
        //ChangeScene();
        //changeHeart = true;
    }

    IEnumerator FailMsg()
    {
        //Debug.Log("notice 코루틴 호출");
        yield return new WaitForSeconds(2.0f);
        failMsg.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        //failMsg.SetActive(false);
        SceneLoader.Instance.LoadNewScene("Chapter03_2_gameFail");
        //GameObj.checkGameSuccess = GameSuccess;
    }

    IEnumerator SucMsg()
    {
        yield return new WaitForSeconds(2.0f);
        sucMsg.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        //sucMsg.SetActive(false);
        SceneLoader.Instance.LoadNewScene("Chapter03_3_gameWin");
        //GameObj.checkGameSuccess = GameSuccess;
    }
}
