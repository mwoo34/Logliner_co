using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject[] hearts;
    public Sprite heart;
    public Sprite empty_heart;
    private int hp_count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene() {
        Debug.Log("Resume Testing...");
        // Time.timeScale = 1;
        // Time.fixedDeltaTime = 0.02f * Time.timeScale;
        //GameObject.Find("GameCtrl").GetComponent<GameCtrl>().IsGameOver = false;
        
        //hp_count = GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount;
        GameObject.Find("GameCtrl").GetComponent<GameCtrl>().IsGameOver = false;
        for (int i = 0; i < 5; i++) {
            hearts[i].gameObject.GetComponent<SpriteRenderer>().sprite = heart;
        }

        SceneLoader.Instance.LoadNewScene("Chapter3_1");
    }
}