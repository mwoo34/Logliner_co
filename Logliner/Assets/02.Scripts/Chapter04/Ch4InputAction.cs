using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ch4InputAction : MonoBehaviour
{
    public InputActionReference _toggleReference = null;
    private void Awake()
    {
        _toggleReference.action.started += Toggle;
    }

    private void OnDestroy()
    {
        _toggleReference.action.started -= Toggle;

    }
   
    private void Toggle(InputAction.CallbackContext context)
    {
        GameCtrl4_1.instance._inputActive = true;
        this.gameObject.SetActive(false);
    }
}
