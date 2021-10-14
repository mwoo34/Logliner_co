using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadCollider : MonoBehaviour
{
    public GameObject[] rock_hearts;
    public Texture empty_heart;
    private int hp_count;

    void Start()
    {
        
    }

    void Update()
    {
        rock_hearts = GameCtrl.instance.hpImages;
    }
    
    // 카메라에 캡슐을 하나 붙여서 돌에 맞는지 확인하는 함수
    void OnCollisionEnter(Collision coll) {
        if (coll.collider.CompareTag("ROCKS")) {
            Destroy(coll.gameObject);
            hp_count = GameCtrl.instance.heartCount;
            if (hp_count > 0) {
                rock_hearts[hp_count - 1].GetComponent<RawImage>().texture = empty_heart;
                GameCtrl.instance.heartCount -= 1;
                //rock_hearts[hp_count - 1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
                //rock_hearts[hp_count - 1].gameObject.GetComponent<SpriteRenderer>().sprite = empty_heart;
                //hp_count--;
                //GameObject.Find("GameCtrl").GetComponent<GameCtrl>().heartCount -= 1;
            }
        }
    }
}
