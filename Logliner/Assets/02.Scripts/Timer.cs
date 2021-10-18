using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float startTime;
    private string textTime;
    private float guiTime;
    private int minutes;
    private int seconds;
    private int fraction;
    private bool progressGame;

    public TMP_Text textField;
    
    void Start()
    {
        startTime = Time.time + 70;
        progressGame = true;
    }

    void Update()
    {
        if (progressGame)
            ShowTime();
    }

    void ShowTime()
    {
        if (GameCtrl.instance.heartCount == 0)
            gameObject.SetActive(false);
        guiTime =  startTime - Time.time;
        minutes = (int)guiTime / 60;
        seconds = (int)guiTime % 60;
        fraction = (int)(guiTime * 100) % 100;
        textTime = string.Format("{0:00}:{1:00}", minutes, seconds, fraction);
        if (minutes == 0 && seconds == 0 || GameCtrl.instance.GameSuccess == 2) 
        {
            textField.text = "Game Clear";
            GameCtrl.instance.GameSuccess = 2;
            Debug.Log("GameSuccess 값 : " + GameCtrl.instance.GameSuccess);
            progressGame = false;
            //GameObj.instance.checkGame = 1;
        }
        else 
        {
            textField.text = textTime;
        }
    }
}
