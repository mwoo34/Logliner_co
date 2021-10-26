using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Load);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        SceneLoader.Instance.LoadNewScene("Chapter03_1_game");
    }
}
