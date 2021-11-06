using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter03 : MonoBehaviour
{
    public Material _skybox;
    // 메시지 담을 변수
    public GameObject missionMsg;
    public GameObject questMsg;
    // 상호작용 버튼 담을 변수
    //public GameObject accept_btn;
    // 메시지를 보여줄 상태를 bool형 타입으로 선언
    private bool active = false;
    private bool missionGuide = false;

    // 배경음, 임무안내, 정보설명, 클릭
    public AudioSource[] audioSources;

    public void Start()
    {
        RenderSettings.skybox = _skybox;
        GameManager.Instance.InitXrRigPosition();
        GameManager.Instance.ActivateMovememt(false);
        //Initialized();
        PlayerPrefs.DeleteAll();

        audioSources[0].Play();
        //gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(NoticeMsg());
    }

    // 메시지를 보여줄 함수
    void Update()
    {
        
    }

    IEnumerator NoticeMsg()
    {
        yield return new WaitForSeconds(2.0f);
        missionMsg.SetActive(true);
        audioSources[1].Play();
        yield return new WaitForSeconds(4.0f);
        missionMsg.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        questMsg.SetActive(true);
        audioSources[2].Play();
    }

    // 미션메시지 보여준 후 미션안내메시지 출력을 위해 값 조절
    // IEnumerator ChangeSprite() {
    //     yield return new WaitForSeconds(2.0f);
    //     active = true;
    //     //mission.SetActive(active);
    //     yield return new WaitForSeconds(5.0f);
    //     active = false;
    //     yield return new WaitForSeconds(2.0f);
    //     missionGuide = true;
    // }

    public void ChangeScene()
    {
        audioSources[3].Play();
        SceneLoader.Instance.LoadNewScene("Chapter03_1_game");
    }
}
