using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameObj04 : MonoBehaviour
{
    public GameObject _XRrig;
    public GameObject _Left;
    public ActionBasedController _LeftCtrl;
    public ActionBasedContinuousMoveProvider _movement;
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
        if (state == 0)
            gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5.0f);
        noticeMsg[state].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        noticeMsg[state].SetActive(false);
        yield return new WaitForSeconds(10.0f);
        GameManager.Instance._XRrig.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
        //GameManager.Instance.InitXrRigPosition();
        //GameManager.Instance._XRrig.transform.localEulerAngles = new Vector3(0, 180, 0);
        SceneLoader.Instance.LoadNewScene("Chapter04_3_credit");
    }
}
