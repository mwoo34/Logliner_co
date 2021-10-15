using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlat : MonoBehaviour
{
    public GameObject plats;
    public Transform points;
    private bool create = true;
    void Start()
    {
        StartCoroutine(MakePlat());
    }

    // Update is called once per frame
    void Update()
    {
        // if (create) {
        //     StartCoroutine(MakePlat());
        // }
        if (GameCtrl.instance.heartCount == 0) 
        {
            create = false;
            //GameCtrl.instance.IsGameOver = true;
            StopCoroutine(MakePlat());
        }
    }

    IEnumerator MakePlat() {
        if (create) {
            GameObject plat = Instantiate(plats, points);
            plat.transform.localPosition = Vector3.zero;
            //create = false;
            yield return new WaitForSeconds(20.0f);
            //create = true;
            StartCoroutine(MakePlat());
        }
    }
}
