using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    public GameObject[] hearts;
    public Sprite heart;
    public Sprite empty_heart;
    public int hp_cnt;

    void OnCollisionEnter(Collision coll) {
        
        if (coll.collider.CompareTag("ROCKS")) {
            Destroy(coll.gameObject);
            if (hp_cnt > 0) {
                hearts[hp_cnt - 1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
                hp_cnt--;
            }
        }
    }
}
