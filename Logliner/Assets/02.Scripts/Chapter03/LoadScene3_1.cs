using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene3_1 : MonoBehaviour
{
    // 정화세이버 게임 씬으로 이동
    public void ChangeScene() {
        SceneLoader.Instance.LoadNewScene("Chapter03_1_game");
    }

}
