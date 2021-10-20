using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObj : MonoBehaviour
{
    // 게임매니저 인스턴스화를 위한 변수
    public static GameObj instance;

    // 게임 상태여부 체크로 1은 실패 2는 성공상태
    public static int checkGameSuccess;
    public static int objManage;
    public GameObject collManage;
    public static int ch4FailorSucces = 1;

    // Update에서 호출 제한을 두기 위한 변수
    private bool autoMove = true;

    // 슬롯 객체 담는 변수
    public GameObject[] slot;

    // 메시지 객체 담는 변수
    public GameObject[] uiMsg;

    // 정화트럭 객체 담는 변수
    public GameObject truck;

    // 매립지 객체 담는 변수
    public GameObject landfill;

    // XR Rig 카메라 담는 변수
    //public GameObject xrRig;

    // 자동 이동할 때 사용할 지형 터레인 담는 변수
    //public GameObject[] terrain;
    public GameObject terrain;

    // 싱글톤을 위해 선언
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // 게임이 1(실패), 2(성공) 둘 다 차량 자동이동이 있기 때문에 코루틴으로 이동하는 함수 호출
    void Update()
    {
        if (checkGameSuccess > 0 && autoMove)
        {
            autoMove = false;
            StartCoroutine(AutoMove());
        }
        if (checkGameSuccess == 3 || checkGameSuccess == 4)
        {
            truck.SetActive(false);
            GameManager.Instance._XRrig.GetComponent<MoveTruck>().enabled = false;
            //xrRig.GetComponent<MoveTruck>().enabled = false;
        }
        if (objManage == 1)
        {
            collManage.SetActive(true);
        }
        else
        {
            collManage.SetActive(false);
        }
    }

    // 트럭이 움직이기 전에 세팅을 위한 함수
    IEnumerator AutoMove()
    {
        // 지형, 매립지, 트럭을 활성화하고 잠시 기다렸다가 MoveTruck 스크립트 활성화 시킴
        yield return new WaitForSeconds(6.0f);
        terrain.SetActive(true);
        landfill.SetActive(true);
        truck.SetActive(true);
        GameManager.Instance._XRrig.GetComponent<MoveTruck>().enabled = true;
    }
}
