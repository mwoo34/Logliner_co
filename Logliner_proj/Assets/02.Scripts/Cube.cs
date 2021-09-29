using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public GameObject[] hearts;
    private int hp_count = 3;
    public Canvas ca;
    public Image[] hp_img;
    public Sprite sp;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        int index = 1;
        for (int i = 0; i < hp_count; i++) {
            hearts[index] = GameObject.Find("ht" + index.ToString());
            index += 1;
        }
    }

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 2;
        if (transform.localPosition.z > 16.0f) {
            //DestroyHeart();
            DestroyCube();
        }
    }

    void DestroyHeart() {
        // if (hp_count > 0) {
        //     hearts[hp_count - 1].GetComponent<SpriteRenderer>().sprite = sp;
        //     hp_count -= 1;
        // }   
    }

    void DestroyCube() {
        
        Destroy(this.gameObject);
    }
}