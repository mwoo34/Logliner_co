using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameCtrl4_1 : MonoBehaviour
{
    public GameObject[] uiMsg;
    private int uiPos = 0;
    private int gameState;
    public PlayableDirector playableDirector;
    public TimelineAsset timeline;
    
    public Button btn;

    void Start()
    {
        if (GameObj.checkGameSuccess == 3)
        {
            gameState = 1; // 실패 상태 검은 우주
        }
        else if (GameObj.checkGameSuccess == 4)
        {
            gameState = 2; // 성공 상태 검은 우주
        }
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
        uiMsg[gameState - 1].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        uiMsg[gameState - 1].SetActive(false);
        yield return new WaitForSeconds(3.0f);
        PlayFromTimeline();
    }

    public void PlayFromTimeline()
    {
        playableDirector.Play(timeline);
    }
}
