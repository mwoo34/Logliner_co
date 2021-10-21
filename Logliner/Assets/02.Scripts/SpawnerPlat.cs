using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlat : MonoBehaviour
{
    // 지형을 일정 시간마다 스폰하는 스크립트, 그냥 큰 지형 하나를 이동시키는 것도 괜찮을 듯 함
    // 지형 프리팹을 담을 변수
    public GameObject plats;
    // 스폰 위치를 담을 변수
    public Transform points;
    // 객체를 생성할지 말지 정할 bool 변수
    private bool create = true;

    // 땅 만드는 코루틴 호출
    void Start()
    {
        //StartCoroutine(MakePlat());
        MakePlat2();
    }

    // 하트를 다 잃거나 게임 클리어스 땅 만드는 코루틴 멈춤
    void Update()
    {
        if (GameCtrl.instance.heartCount == 0) 
        {
            
            //create = false;
            //GameCtrl.instance.IsGameOver = true;
            //StopCoroutine(MakePlat());
        }
        if (GameCtrl.instance.GameSuccess == 2)
        {
            //create = false;
            //StopCoroutine(MakePlat());
        }
    }

    void MakePlat2()
    {
        GameObject plat = Instantiate(plats, points);
        plat.transform.localPosition = Vector3.zero;
    }

    // 땅을 해당 위치에 일정 시간마다 생성하는 함수
    IEnumerator MakePlat() {
        if (create) {
            GameObject plat = Instantiate(plats, points);
            plat.transform.localPosition = Vector3.zero;
            //create = false;
            yield return new WaitForSeconds(20.0f);
            //create = true;
            //StartCoroutine(MakePlat());
        }
    }
}
