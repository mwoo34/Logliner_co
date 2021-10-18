using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // 생성된 큐브 및 땅 움직임
    void Update()
    {
        if (GameCtrl.instance.GameSuccess == 0) {
            Debug.Log("GameSuccess 값 : " + GameCtrl.instance.GameSuccess);
            transform.position += Time.deltaTime * transform.forward * 3;
        }
        else {
            transform.position += Time.deltaTime * transform.forward * 0;
            //this.gameObject.SetActive(false);
            
        }
    }
}
