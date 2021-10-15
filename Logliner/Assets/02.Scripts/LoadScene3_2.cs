using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene3_2 : MonoBehaviour
{
    public void ChangeScene() {
        SceneLoader.Instance.LoadNewScene("Chapter03_2");
    }
}
