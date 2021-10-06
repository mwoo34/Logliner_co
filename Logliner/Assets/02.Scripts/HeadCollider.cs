using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    public GameObject[] rock_hearts;
    public Sprite heart;
    public Sprite empty_heart;
    private int hp_count;

    void Start() {
        rock_hearts = GameObject.Find("Wall").GetComponent<WallCtrl>().hearts;
    }
    
    void OnCollisionEnter(Collision coll) {
        if (coll.collider.CompareTag("ROCKS")) {
            hp_count = GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount;  
            Destroy(coll.gameObject);
            if (hp_count > 0) {
                rock_hearts[hp_count - 1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
                //hp_count--;
                GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount -= 1;
            }
        }
    }
}
