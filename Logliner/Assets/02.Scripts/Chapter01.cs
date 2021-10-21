using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Chapter01 : MonoBehaviour
{
    public ItemContractTablet _itemContractTablet;
    public ItemMemoryTablet _itemMemoryTablet;
    //씬설정
    public Material _skybox;

    //인터렉션 UI 설정
    public Image[] _interactionUI;
    public int _curMission = 0;
    public int _curItem = 0;
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _alpha = 0.0f;
    void Start()
    {
        _itemContractTablet.ShowUI += new FloatingEventHandler(onShowUI);
        _itemContractTablet.HideUI += new FloatingEventHandler(onHideUI);
        _itemContractTablet.ContractConfirmComplete += new FloatingEventHandler(onContractConfirm);
        _itemContractTablet.ContractSignComplete += new FloatingEventHandler(onContractSign);

        _itemMemoryTablet.ShowUI += new FloatingEventHandler(onShowUI);
        _itemMemoryTablet.HideUI += new FloatingEventHandler(onHideUI);
        _itemMemoryTablet.MemoryPlayComplete += new FloatingEventHandler(onMemoryComplete);

        Initialized();
        //한음사 타블렛 인터렉션 활성화
        ActivateContarctTablet();
    }

    /// <summary>
    /// 씬초기화 
    /// </summary>
    public void Initialized()
    {
        RenderSettings.skybox = _skybox; //스카이박스 셋팅
        GameManager.Instance.InitXrRigPosition();//카메라 포지션 초기화
        GameManager.Instance.ActivateMovememt(false);//무브먼트 해제

        //인터렉션 비활성화

        _curMission = 0; //현재 미션 번호
        _curItem = 0; //현재 인터렉션 번호
        _alpha = 0; //인터렉션 이미지 알파값
    }
    public void ActivateContarctTablet()
    {
        StartCoroutine(OnContarctTablet());
    }
    IEnumerator OnContarctTablet()
    {
        yield return new WaitForSeconds(1f);// 1.0s delay
        //인터렉션 안내, 타블렛 집기
        ShowUI(); 
        GameManager.Instance.ShowUI();

        //한음사 타블렛 인터렉션 활성화 
    }
    public void ActivateBackpack()
    {
        //인터렉션 UI show
        ShowUI();
        //배낭 인터렉션 활성화
    }
    public void ActivateMemoryTablet()
    {
        //배낭속 타블렛 인터렉션 활성화
    }
    public void OnGrabContarctTablet()
    {
        //인터렉션 안내, 계약서 확인 누르기
        ShowUI();
    }
    public void ContarctCheck()
    {
        //계약서 확인 
        //타블렛 원위치
        //미션창 팝업
    }
    public void OnBackpack()
    {
        //인터렉션 안내
        ShowUI();
        //배낭 확인하기
    }
    public void OnMemoryTablet()
    {
        //인터렉션 안내
        ShowUI();
        //리진의 기억 확인하기 
    }
    private void onShowUI(object sender)
    {
        Debug.Log("Show");
        GameManager.Instance.ShowUI();
        ShowUI();
    }
    private void onHideUI(object sender)
    {
        Debug.Log("Hide");
        GameManager.Instance.HideUI();
        HideUI();
    }
    private void onContractConfirm(object sender)
    {
        StartCoroutine(StartMissonMemory());
    }
    IEnumerator StartMissonMemory()
    {
        OnMisstion();
        yield return new WaitForSeconds(2f);
        _curItem++;
        ShowUI();
        yield return new WaitForSeconds(1f);
        _itemMemoryTablet.ActivateBackpack();
        //GameManager.Instance.onNext();
    }

    private void onMemoryComplete(object sender)
    {
        StartCoroutine(StartMissonContractSign());
    }
    IEnumerator StartMissonContractSign()
    {
        OnMissionComplete();
        yield return new WaitForSeconds(1.5f);
        OnMisstion();
        yield return new WaitForSeconds(2f);
        _itemContractTablet.ActivateContract();
        _curItem++;
        ShowUI();
    }
    private void onContractSign(object sender)
    {
        //미션 컴플리트 
        StartCoroutine(CompleteMisson());

    }
    IEnumerator CompleteMisson()
    {
        yield return new WaitForSeconds(0.5f);
        OnMissionComplete();
        yield return new WaitForSeconds(2f);
        SceneLoader.Instance.LoadNewScene("Chapter02");
    }

    public void ShowUI()
    {
        //해당 인터렉션안내 UI show
        StopCoroutine(HideInteractionUI());
        StopCoroutine(ShowInteractionUI());
        StartCoroutine(ShowInteractionUI());
    }
    public void HideUI()
    {
        //해당 인터렉션안내 UI hide
        StopCoroutine(HideInteractionUI());
        StopCoroutine(ShowInteractionUI());
        StartCoroutine(HideInteractionUI());

    }

    public void OnMisstion()
    {
        //OnMisstion(intidx): 해당 미션 메시지 UI 노출
        MissionText();
        _curMission++;
    }

    public void OnMissionComplete()
    {
        //OnMissionComplete():미션완료 메시지노출
        MissionText();
        _curMission++;
        
    }

    private void MissionText()
    {
        Text _missionTxt = GameManager.Instance.titleManager._MisstionTitle;
        //씬로드시 표시할 챕터 타이틀 
        switch (_curMission)
        {
            case 0:
                _missionTxt.text = "임무1-1 : 자신의 기억을 확인하세요.";
                break;
            case 1:
                _missionTxt.text = "임무1-1 : 완료!";
                break;
            case 2:
                _missionTxt.text = "임무1-2 : 계약서에 서명하세요.";
                break;
            case 3:
                _missionTxt.text = "임무1-2 : 완료!";
                break;
        }
        GameManager.Instance.titleManager.ShowMisson();
    }


    private IEnumerator ShowInteractionUI()
    {
        if(_curItem < _interactionUI.Length)
        {
            //Fade-in
            //_interactionUI[_curItem].color = new Color(_interactionUI[_curItem].color.r, _interactionUI[_curItem].color.g, _interactionUI[_curItem].color.b, 0);
            while (_alpha <= 0.8f)
            {
                _alpha += _speed * Time.deltaTime;
                _interactionUI[_curItem].color = new Color(_interactionUI[_curItem].color.r, _interactionUI[_curItem].color.g, _interactionUI[_curItem].color.b, _alpha);
                yield return null;
            }
        }
    }
    private IEnumerator HideInteractionUI()
    {
        if (_curItem < _interactionUI.Length)
        {
            //Fade-out
            //_interactionUI[_curItem].color = new Color(_interactionUI[_curItem].color.r, _interactionUI[_curItem].color.g, _interactionUI[_curItem].color.b, 0.8f);
            while (_alpha >= 0.0f)
            {
                _alpha -= _speed * Time.deltaTime;
                _interactionUI[_curItem].color = new Color(_interactionUI[_curItem].color.r, _interactionUI[_curItem].color.g, _interactionUI[_curItem].color.b, _alpha);
                yield return null;
            }
        }
    }



}
