using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    // 씬 Chapter03_1_game 게임매니저
    
    // 실수 가능한 횟수 담은 변수
    public int heartCount = 5;
    // 하트 객체 담을 변수
    public GameObject[] hpImages;
    // 슬롯 객체 담을 변수
    public GameObject[] slotImages;

    // 슬롯에 넣을 Texture와 Image 소스
    public Texture[] slotTex;
    public Image[] changeSlotImages;
    // 현재 바뀔 슬롯 위치 값 담은 변수
    public int slotPos = 0;

    // 양 쪽 컨트롤이 같은 객체를 벨 때 ITEMBOX가 2개 베지 않도록 잠그는 변수
    public bool _lock = true;
    // 장애물 스폰하는 객체
    public GameObject spawnerCube;

    // 지형 받을 변수
    //public GameObject plat;

    // 업무 재개 메시지 보관 변수
    public GameObject resumeMsg;
    public GameObject failMsg;
    public GameObject sucMsg;

    // 업무 재개 가능한 횟수 변수
    public int remainRound = 3;

    // 시간 표시할 객체
    public GameObject timer;

    // 게임 상태 여부 0은 진행중, 1은 실패, 2는 성공
    public int GameSuccess = 0;
    // 게임 상태에 따라 업데이트에서 불리는 것을 제한하기 위한 변수
    private bool _gameSuccess = true;
    
    // 업무 남은 횟수 표시하는 객체 받아오기
    //public GameObject[] fuelBtn;
    // 업무 남은 횟수를 하얀색 이미지로 표시하기 위해 담을 변수
    //public Sprite whiteSprite;

    // 게임오버인지 상태 체크 변수
    private bool gameOver = true;

    // 게임 실패 상태 여부 변수
    //private bool isGameOver = false;
    //public bool changeHeart = false;
    // public int saveSlotPos;
    // public int saveRemainRound;

    // 내부 레지스터에 저장된 데이터가 있는지 확인하기 위한 변수
    private bool isSave;

    // 오디오 받을 변수
    private AudioSource audio;

    // GameCtrl 인스턴스화를 위해 선언
    public static GameCtrl instance;

    public TMP_Text textField;

    // GameCtrl 인스턴스화
    void Awake()
    {
        instance = this;
    }
    
    // 내부 레지스터에 데이터를 가져와서 활성화 된 slot은 다시 활성화 하고
    // 내부 레지스터 값 지움
    void Start()
    {
        // for (int i = 0; i < heartCount; i++)
        // {
        //     hpImages[i].SetActive(false);
        // }
        // hpImages[heartCount].SetActive(true);
        //resumeMsg.SetActive(false);
        StartCoroutine(StartGame());
        //GameObj.checkGameSuccess = 0;
        GameObj.instance.leftShape[0].SetActive(false);
        GameObj.instance.rightShape[0].SetActive(false);
        GameObj.instance.leftShape[1].SetActive(true);
        GameObj.instance.rightShape[1].SetActive(true);
        // 기존에 저장된 값이 있는지 확인
        isSave = PlayerPrefs.HasKey("SlotPos");
        // 데이터가 있다면 불러오고 없으면 넘어감
        if (isSave)
        {
            Debug.Log("저장된 데이터가 있습니다");
            slotPos = PlayerPrefs.GetInt("SlotPos");
            remainRound = PlayerPrefs.GetInt("RemainRound");
            Debug.Log("현재 slotPos값 : " + slotPos);
            // 오픈된 슬롯 만큼 다시 열어주는 역할
            for (int i = 0; i < slotPos; i++)
            {
                //slotImages[i].GetComponentInChildren<Image>().sprite = changeSlotImages[i];
                slotImages[i].SetActive(true);
            }
        }
        else
        {
            Debug.Log("저정된 데이터가 없습니다");
        }
        // 불러왔기 때문에 저장된 데이터 전체 삭제함
        PlayerPrefs.DeleteAll();
        audio = gameObject.GetComponent<AudioSource>();
        GameObj.objManage = 1;
    }

    // 게임 실패 후 업무재개 화면
    void Update()
    {
        // 게임오버되고 하트 갯수가 0이라면 오디오를 멈추고 업무재개 메시지창 띄움
        if (gameOver && heartCount == 0)
        {
            gameOver = false;
            audio.Stop();
            ResumeGame();
        }
        // 게임을 성공하면 장애물 스폰과 오디오를 끄고 성공 메시지창 띄움
        if (GameSuccess == 2 && _gameSuccess)
        {
            _gameSuccess = false;
            spawnerCube.SetActive(false);
            audio.Stop();
            timer.SetActive(false);
            StartCoroutine(SucMsg());
        }
    }

    // 5개 목숨을 다 잃고 나타나는 업무재개창과 
    // 몇번째 시도인지에 따라 메시지창에 기회가 몇 번 남았는지 알리는 역할
    void ResumeGame() {
        resumeMsg.SetActive(true);
        remainRound -= 1;
        Debug.Log("remainRound : " + remainRound);
        textField.text = "남은 기회 : [ " + remainRound + " ]";
        // 남은 라운드가 0인경우 실패 메시지 출력
        if (remainRound == 0)
        {
            resumeMsg.SetActive(false);
            timer.SetActive(false);
            StartCoroutine(FailMsg());
        } // 남은 라운드가 있다면 메시지창과 남은 라운드 버튼 이미지 출력
        // else if (remainRound > 0)
        // {
        //     for (int i = 3; i > remainRound; i--)
        //     {
        //         fuelBtn[i - 1].GetComponent<Image>().sprite = whiteSprite;
        //     }
        // }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(7.0f);
        GameObj.checkGameSuccess = 0;
    }

    // 실패 메시지를 보여준 후 게임 실패 씬으로 이동
    IEnumerator FailMsg()
    {
        GameObj.objManage = 0;
        yield return new WaitForSeconds(2.0f);
        failMsg.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        GameObj.checkGameSuccess = 1;
        SceneLoader.Instance.LoadNewScene("Chapter03_2_landFill");
    }

    // 게임 성공 메시지를 보여준 후 게임 성공 씬으로 이동
    IEnumerator SucMsg()
    {
        GameObj.objManage = 0;
        yield return new WaitForSeconds(2.0f);
        sucMsg.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        GameObj.checkGameSuccess = 2;
        SceneLoader.Instance.LoadNewScene("Chapter03_2_landFill");
    }
}
