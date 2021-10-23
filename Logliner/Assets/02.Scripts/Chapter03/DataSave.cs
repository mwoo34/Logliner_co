using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSave : MonoBehaviour
{
    // 업무 재개 버튼을 누를경우 현재 오픈된 슬롯 갯수와 남은 라운드 수를 저장
    public void Save()
    {
        int slotPos = GameCtrl.instance.slotPos;
        int remainRound = GameCtrl.instance.remainRound;
        Debug.Log("저장할 slotpos, remainround 값 : " + slotPos + " " + remainRound);
        PlayerPrefs.SetInt("SlotPos", slotPos);
        PlayerPrefs.SetInt("RemainRound", remainRound);
        PlayerPrefs.Save();
        Debug.Log("저장 되었습니다");
        ChangeScene();
    }

    // 업무 재개를 위해 씬 리로드
    public void ChangeScene()
    {
        //GameCtrl.instance.IsGameOver = false;
        SceneLoader.Instance.LoadNewScene("Chapter03_1_game");
        //Load();
    }
}
