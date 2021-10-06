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
        GameObject plat = Instantiate(plats, points);
        plat.transform.localPosition = Vector3.zero;
        StartCoroutine(MakePlat());
    }

    // Update is called once per frame
    void Update()
    {
        if (create) {
            StartCoroutine(MakePlat());
        }
        if (GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount == 0) {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            GameObject.Find("GameCtrl").GetComponent<GameCtrl>().IsGameOver = true;
        }
    }

    IEnumerator MakePlat() {
        if (create) {
            create = false;
            yield return new WaitForSeconds(35.0f);
            GameObject plat = Instantiate(plats, points);
            plat.transform.localPosition = Vector3.zero;
            create = true;
        }
    }
}
