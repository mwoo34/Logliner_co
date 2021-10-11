using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallCtrl : MonoBehaviour
{
    public GameObject[] hearts;
    public Sprite heart;
    public Sprite empty_heart;
    public Image[] imgs;
    private int hp_count;

    void Start() {
        hearts = GameCtrl.instance.hpImages;
        //imgs = GameCtrl.instance.hpImages;
    }

    void OnCollisionEnter(Collision coll) {
        //hp_count = GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount;
        if (coll.collider.CompareTag("CUBE") || coll.collider.CompareTag("ITEMBOX")) {
            hp_count = GameCtrl.instance.heartCount;
            Destroy(coll.gameObject);
            if (hp_count > 0) {
                //imgs[hp_count - 1].sprite = empty_heart;
                GameCtrl.instance.heartCount -= 1;
                //hearts[hp_count - 1].GetComponent<SpriteRenderer>().sprite = empty_heart;
                hearts[hp_count - 1].GetComponent<Image>().sprite = empty_heart;
                //hearts[hp_count-1].SetActive(false);
                //hearts[hp_count-1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
                //hp_count--;
                //GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount -= 1;
                //hearts[hp_count-1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
            }
        }
        
    }
}
