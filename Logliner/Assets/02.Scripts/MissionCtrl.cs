using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCtrl : MonoBehaviour
{
    public GameObject missionMsg;
    public GameObject questMsg;
    public GameObject accept_btn;
    private bool active = false;
    private bool missionGuide = false;

    void Start()
    {
        StartCoroutine(ChangeSprite());
    }

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
