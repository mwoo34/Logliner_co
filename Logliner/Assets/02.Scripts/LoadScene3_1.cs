using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene3_1 : MonoBehaviour
{
    public void ChangeScene() {
        SceneLoader.Instance.LoadNewScene("Chapter3_1");
    }
}
