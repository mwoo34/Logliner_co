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
    //������
    public Material _skybox;

    //���ͷ��� UI ����
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
        //������ Ÿ�� ���ͷ��� Ȱ��ȭ
        ActivateContarctTablet();
    }

    /// <summary>
    /// ���ʱ�ȭ 
    /// </summary>
    public void Initialized()
    {
        RenderSettings.skybox = _skybox; //��ī�̹ڽ� ����
        GameManager.Instance.InitXrRigPosition();//ī�޶� ������ �ʱ�ȭ
        GameManager.Instance.ActivateMovememt(false);//�����Ʈ ����

        //���ͷ��� ��Ȱ��ȭ

        _curMission = 0; //���� �̼� ��ȣ
        _curItem = 0; //���� ���ͷ��� ��ȣ
        _alpha = 0; //���ͷ��� �̹��� ���İ�
    }
    public void ActivateContarctTablet()
    {
        StartCoroutine(OnContarctTablet());
    }
    IEnumerator OnContarctTablet()
    {
        yield return new WaitForSeconds(1f);// 1.0s delay
        //���ͷ��� �ȳ�, Ÿ�� ����
        ShowUI(); 
        GameManager.Instance.ShowUI();

        //������ Ÿ�� ���ͷ��� Ȱ��ȭ 
    }
    public void ActivateBackpack()
    {
        //���ͷ��� UI show
        ShowUI();
        //�賶 ���ͷ��� Ȱ��ȭ
    }
    public void ActivateMemoryTablet()
    {
        //�賶�� Ÿ�� ���ͷ��� Ȱ��ȭ
    }
    public void OnGrabContarctTablet()
    {
        //���ͷ��� �ȳ�, ��༭ Ȯ�� ������
        ShowUI();
    }
    public void ContarctCheck()
    {
        //��༭ Ȯ�� 
        //Ÿ�� ����ġ
        //�̼�â �˾�
    }
    public void OnBackpack()
    {
        //���ͷ��� �ȳ�
        ShowUI();
        //�賶 Ȯ���ϱ�
    }
    public void OnMemoryTablet()
    {
        //���ͷ��� �ȳ�
        ShowUI();
        //������ ��� Ȯ���ϱ� 
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
        //�̼� ���ø�Ʈ 
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
        //�ش� ���ͷ��Ǿȳ� UI show
        StopCoroutine(HideInteractionUI());
        StopCoroutine(ShowInteractionUI());
        StartCoroutine(ShowInteractionUI());
    }
    public void HideUI()
    {
        //�ش� ���ͷ��Ǿȳ� UI hide
        StopCoroutine(HideInteractionUI());
        StopCoroutine(ShowInteractionUI());
        StartCoroutine(HideInteractionUI());

    }

    public void OnMisstion()
    {
        //OnMisstion(intidx): �ش� �̼� �޽��� UI ����
        MissionText();
        _curMission++;
    }

    public void OnMissionComplete()
    {
        //OnMissionComplete():�̼ǿϷ� �޽�������
        MissionText();
        _curMission++;
        
    }

    private void MissionText()
    {
        Text _missionTxt = GameManager.Instance.titleManager._MisstionTitle;
        //���ε�� ǥ���� é�� Ÿ��Ʋ 
        switch (_curMission)
        {
            case 0:
                _missionTxt.text = "�ӹ�1-1 : �ڽ��� ����� Ȯ���ϼ���.";
                break;
            case 1:
                _missionTxt.text = "�ӹ�1-1 : �Ϸ�!";
                break;
            case 2:
                _missionTxt.text = "�ӹ�1-2 : ��༭�� �����ϼ���.";
                break;
            case 3:
                _missionTxt.text = "�ӹ�1-2 : �Ϸ�!";
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
