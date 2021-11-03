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
        //gameObject.GetComponent<AudioSource>().Play();
    }

    // 3씬 스카이박스 초기화
    private void Initialized()
    {
        //skybox setting
        RenderSettings.skybox = _skybox;
        //GameObj.checkGameSuccess = 0;
        // GameManager.Instance.InitXrRigPosition();
        // GameManager.Instance.ActivateMovememt(false);
    }
}
