using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObj04 : MonoBehaviour
{
    public GameObject[] noticeMsg;
    public bool _distance;
    public int state;

    public static GameObj04 instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (_distance)
        {
            _distance = false;
            StartCoroutine(NoticeMsg());
        }
    }

    IEnumerator NoticeMsg()
    {
        yield return new WaitForSeconds(3.0f);
        noticeMsg[state].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        noticeMsg[state].SetActive(true);
        SceneLoader.Instance.LoadNewScene("Chapter04_3_credit");
    }
}
