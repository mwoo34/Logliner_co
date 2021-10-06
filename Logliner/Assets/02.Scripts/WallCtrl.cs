using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{
    public GameObject[] hearts;
    public Sprite heart;
    public Sprite empty_heart;
    private int hp_count;

    void OnCollisionEnter(Collision coll) {
        hp_count = GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount;
        if (coll.collider.CompareTag("CUBE")) {
            Destroy(coll.gameObject);
            if (hp_count > 0) {
                //hearts[hp_count-1].SetActive(false);
                hearts[hp_count-1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
                //hp_count--;
                GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount -= 1;
            }
        }
        
    }
}
