using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : Singleton<GameManager>
{
    public GameObject _XRrig;
    public GameObject _Left;
    public ActionBasedController _LeftCtrl;
    public ActionBasedController _RightCtrl;
    public ActionBasedContinuousMoveProvider _movement;
    public TitleManager titleManager = null;

    /*public Material[] _skybox;
    public void SettingSkyBOX(int idx)
    {
        //camera rig potion 
        //skybox setting
        RenderSettings.skybox = _skybox[idx];
    }*/
    private void Start()
    {
       
    }
    public void InitXrRigPosition()
    {
        //camera rig potion 
        Transform tr = _XRrig.GetComponent<Transform>();
        tr.localPosition = Vector2.zero;
    }
    public void ActivateMovememt(bool _enable)
    {
        //ContinuousMoveProvider
        _movement.enabled = _enable;
    }

    public void OnHaptic()
    {
        StartCoroutine(HapticTest());
    }

    IEnumerator HapticTest()
    {
        yield return new WaitForSeconds(0.2f);
        _LeftCtrl.SendHapticImpulse(1f, 0.5f);

        yield return new WaitForSeconds(0.8f);
        _LeftCtrl.SendHapticImpulse(0.5f, 0.5f);

        yield return new WaitForSeconds(1f);
        _LeftCtrl.SendHapticImpulse(1f, 0.5f);
    }

    //인터렉션 UI 설정
    public Image[] _interactionUI;
    public int _curMission = 0;
    public int _curItem = 0;
    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private float _alpha = 0.0f;
    public void onNext()
    {
        _curItem++;
        ShowUI();
    }
    
    public void ShowUI()
    {
        //해당 인터렉션안내 UI show
        StopAllCoroutines();
        StartCoroutine(ShowInteractionUI());
    }
    public void HideUI()
    {
        //해당 인터렉션안내 UI hide
        StopAllCoroutines();
        StartCoroutine(HideInteractionUI());
        //_curItem++;
    }
    private IEnumerator ShowInteractionUI()
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
    private IEnumerator HideInteractionUI()
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
