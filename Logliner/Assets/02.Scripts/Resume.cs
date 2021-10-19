using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public void ChangeScene() {
        SceneLoader.Instance.LoadNewScene("Chapter03_1_game");
    }
}
