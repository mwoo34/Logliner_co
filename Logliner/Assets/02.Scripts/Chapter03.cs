using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter03 : MonoBehaviour
{
    public Material _skybox;
    
    public void Start()
    {
        Initialized();
        PlayerPrefs.DeleteAll();
    }

    // 3씬 스카이박스 초기화
    private void Initialized()
    {
        //skybox setting
        RenderSettings.skybox = _skybox;
        // GameManager.Instance.InitXrRigPosition();
        // GameManager.Instance.ActivateMovememt(false);
    }
}
