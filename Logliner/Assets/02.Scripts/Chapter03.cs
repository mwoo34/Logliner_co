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

    private void Initialized()
    {
        //skybox setting
        RenderSettings.skybox = _skybox;
        // GameManager.Instance.InitXrRigPosition();
        // GameManager.Instance.ActivateMovememt(false);
    }
}
