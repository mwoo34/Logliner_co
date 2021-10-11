using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public AudioSource au;
    public GameObject[] slot;
    public Sprite[] slot_sp;

    // Start is called before the first frame update
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        slot = GameCtrl.instance.slotImages;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer)) {
            // if (Vector3.Angle(transform.position- previousPos, hit.transform.up) > 130) {
            //     Destroy(hit.transform.gameObject);
            // }
            au.Play();
            Destroy(hit.transform.gameObject);
        }
        previousPos = transform.position;    
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
