using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    public Animator greenBtnAnim;
    public Animator blueBtnAnim;
    public Animator redBtnAnim;
    public Animator stopBtnAnim;
    public bool _greenBtn, _blueBtn, _redBtn, _stopBtn;
    public BoxCollider[] boxColliders;
    private int pos = 0;

    public void OnSelectedGreen()
    {
        Debug.Log("초록버튼셀렉");
        greenBtnAnim.SetBool("pushBtn", true);
        boxColliders[pos].isTrigger = true;
        StartCoroutine(DelayTime());
        greenBtnAnim.SetBool("greenBtn", false);
        GameCtrl4_0.instance.greenBtn = true;
    }

    public void OnSelectedBlue()
    {
        blueBtnAnim.SetBool("pushBtn", true);
        boxColliders[pos].isTrigger = true;
        StartCoroutine(DelayTime());
        greenBtnAnim.SetBool("blueBtn", false);
        GameCtrl4_0.instance.blueBtn = true;
    }

    public void OnSelectedRed()
    {
        redBtnAnim.SetBool("pushBtn", true);
        boxColliders[pos].isTrigger = true;
        StartCoroutine(DelayTime());
        greenBtnAnim.SetBool("redBtn", false);
        GameCtrl4_0.instance.redBtn = true;
    }

    public void OnSelectedStop()
    {
        blueBtnAnim.SetBool("stopBtn", false);
        boxColliders[pos].isTrigger = true;
        GameCtrl4_0.instance.stopBtn = true;
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(2.0f);
        pos += 1;
        boxColliders[pos].isTrigger =  false;
    }
}
