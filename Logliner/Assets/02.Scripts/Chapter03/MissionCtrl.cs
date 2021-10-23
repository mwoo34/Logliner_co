using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCtrl : MonoBehaviour
{
    // 씬 3의 시작 부분의 3_0에서 메시지창을 출력하기 위한 스크립트
    
    // 메시지 담을 변수
    public GameObject missionMsg;
    public GameObject questMsg;
    // 상호작용 버튼 담을 변수
    public GameObject accept_btn;
    // 메시지를 보여줄 상태를 bool형 타입으로 선언
    private bool active = false;
    private bool missionGuide = false;

    // 메시지를 보여주기위해 코루틴 호출
    void Start()
    {
        StartCoroutine(ChangeSprite());
    }

    // 메시지를 보여줄 함수
    void Update()
    {
        missionMsg.SetActive(active);
        if (missionGuide) {
            //mission.GetComponent<SpriteRenderer>().sprite = sp;
            missionMsg.SetActive(!missionGuide);
            questMsg.SetActive(missionGuide);
            accept_btn.SetActive(true);
        }
    }

    // 미션메시지 보여준 후 미션안내메시지 출력을 위해 값 조절
    IEnumerator ChangeSprite() {
        yield return new WaitForSeconds(2.0f);
        active = true;
        //mission.SetActive(active);
        yield return new WaitForSeconds(5.0f);
        active = false;
        yield return new WaitForSeconds(2.0f);
        missionGuide = true;
    }
}
