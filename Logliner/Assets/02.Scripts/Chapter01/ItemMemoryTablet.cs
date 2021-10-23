using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;
using RenderHeads.Media.AVProVideo;

public class ItemMemoryTablet : MonoBehaviour
{
    public event FloatingEventHandler ShowUI;
    public event FloatingEventHandler HideUI;
    public event FloatingEventHandler MemoryPlayComplete;

    //배낭속 리진타블렛
    public GameObject _MemoryTablet;
    private Vector3 _tabletposition;
    private Quaternion _tabletrotation;
	public MediaPlayer _memoryPlayer;

    public RenderTexture _VideoScreen;
    public AudioSource _sound;

    //collider
    public BoxCollider _colBackpack;
    public BoxCollider _colTablet;
    public BoxCollider _colBtnPlay;

    //Interactable 
    public XRGrabInteractable memoryTablet;
    public XRSimpleInteractable btnPlay;

    private bool _deActivate = false;

    public void Start()
    {
        //비디오 재생완료 이벤트
        _memoryPlayer.Events.AddListener(OnVideoEvent);

        _tabletposition = _MemoryTablet.GetComponent<Transform>().localPosition;
        _tabletrotation = _MemoryTablet.GetComponent<Transform>().localRotation;
    }
    public void ShowTablet()
    {
        //배낭 선택
        _MemoryTablet.SetActive(true);
    }
    public void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
    {
        switch (et)
        {
            case MediaPlayerEvent.EventType.ReadyToPlay:
                break;
            case MediaPlayerEvent.EventType.Started:
                break;
            case MediaPlayerEvent.EventType.FirstFrameReady:
                break;
            case MediaPlayerEvent.EventType.FinishedPlaying:
                //Debug.Log("FinishedPlaying");
                //비디오 재생 완료
                _deActivate = true;
                memoryTablet.enabled = false;
                //원래 자리로 돌아감
                _MemoryTablet.GetComponent<Transform>().localPosition = _tabletposition;
                _MemoryTablet.GetComponent<Transform>().localRotation = _tabletrotation;
                //미션
                onMemoryPlayComplete();
                break;
        }
        //Debug.Log("Event: " + et.ToString());
    }

    public void ActivateBackpack()
    {
        memoryTablet.enabled = true;
        InvokeRepeating("OnTest", 1f, 2.0f);
    }
    void OnTest()
    {
        StopAllCoroutines();
        StartCoroutine(PlaySound());
    }
    IEnumerator PlaySound()
    {
        _sound.Play();
        yield return new WaitForSeconds(0.02f);
        GameManager.Instance._LeftCtrl.SendHapticImpulse(0.5f, 0.9f);
        GameManager.Instance._RightCtrl.SendHapticImpulse(0.5f, 0.9f); 
        yield return new WaitForSeconds(2.0f);
        _sound.Stop();
    }

    /// <summary>
    /// 잡기
    /// </summary>
    public void OnGrab()
    {
        //Debug.Log("OnGrab");
        onHideUI();

        //isTrigger
        _colTablet.isTrigger = true;
        _colBackpack.isTrigger = true;

        //제셍 버튼 활성화
        btnPlay.gameObject.SetActive(true);

        _sound.Stop();
        CancelInvoke("OnTest");
        StopAllCoroutines();

    }
    /// <summary>
    /// 떨어뜨림
    /// </summary>
    public void OnDrop()
    {
        //Debug.Log("OnDrop");
        if (!_deActivate)
        {
            onShowUI();

            _memoryPlayer.Control.Pause();           
            _memoryPlayer.Control.Seek(100);
            _memoryPlayer.Control.Stop();           
            
            btnPlay.gameObject.SetActive(false);

            //isTrigger
            _colTablet.isTrigger = false;
            _colBackpack.isTrigger = false;

            //원래 자리로 돌아감
            _MemoryTablet.GetComponent<Transform>().localPosition = _tabletposition;
            _MemoryTablet.GetComponent<Transform>().localRotation = _tabletrotation;
        }
    }
    /// <summary>
    /// 영상재생
    /// </summary>
    public void OnSelectPlay()
    {
        //isTrigger
        _colTablet.isTrigger = true;
        _colBackpack.isTrigger = true;
       

        btnPlay.gameObject.SetActive(false);
        _memoryPlayer.Control.Seek(0);
        _memoryPlayer.Control.Play();
    }
    ////////////////////////////////////////////////////
    // Floating Event
    ////////////////////////////////////////////////////
    protected virtual void onShowUI()
    {
        if (ShowUI != null)
            ShowUI(this);
    }
    protected virtual void onHideUI()
    {
        if (HideUI != null)
            HideUI(this);
    }

    protected virtual void onMemoryPlayComplete()
    {
        if (MemoryPlayComplete != null)
            MemoryPlayComplete(this);
    }

}

