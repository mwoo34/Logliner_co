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

    public TMP_Text textField;
    
    void Start()
    {
        startTime = Time.time + 70;
    }

    void Update()
    {
        if (GameCtrl.instance.heartCount == 0)
            gameObject.SetActive(false);
        guiTime =  startTime - Time.time;
        minutes = (int)guiTime / 60;
        seconds = (int)guiTime % 60;
        fraction = (int)(guiTime * 100) % 100;
        textTime = string.Format("{0:00}:{1:00}", minutes, seconds, fraction);
        if (minutes == 0 && seconds == 0) {
            textField.text = "TIME OVER";
        }
        else {
            textField.text = textTime;
        }
    }
}
