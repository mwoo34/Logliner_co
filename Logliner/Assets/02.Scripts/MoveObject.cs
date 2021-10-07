using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // 생성된 큐브 및 땅 움직임
    void Update()
    {
        if (GameCtrl.instance.heartCount == 0) {
            transform.position += Time.deltaTime * transform.forward * 0;
        }
        else {
            transform.position += Time.deltaTime * transform.forward * 3;
        }
    }
}
