using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{
    public GameObject[] hearts;
    public Sprite heart;
    public Sprite empty_heart;
    private int hp_count = 5;

    void OnCollisionEnter(Collision coll) {
        if (coll.collider.CompareTag("CUBE")) {
            Destroy(coll.gameObject);
            if (hp_count > 0) {
                //hearts[hp_count-1].SetActive(false);
                hearts[hp_count-1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
                hp_count--;
            }
        }
    }
}
