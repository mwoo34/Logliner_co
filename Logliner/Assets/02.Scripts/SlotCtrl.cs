using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCtrl : MonoBehaviour
{
    public GameObject[] slot;
    public Sprite[] slot_sp;

    void Start() {
        //rock_hearts = GameObject.Find("Wall").GetComponent<WallCtrl>().hearts;
        slot = GameCtrl.instance.slotImages;
    }
    
    void OnCollisionEnter(Collision coll) {
        if (coll.collider.CompareTag("ITEMBOX")) {
            int pos = GameCtrl.instance.slotPos;
            Destroy(coll.gameObject);
            

            // hp_count = GameCtrl.instance.heartCount;
            // if (hp_count > 0) {
            //     rock_hearts[hp_count - 1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
            //     GameCtrl.instance.heartCount -= 1;
            //     //rock_hearts[hp_count - 1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
            //     //hp_count--;
            //     //GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount -= 1;
            // }
        }
    }
}
