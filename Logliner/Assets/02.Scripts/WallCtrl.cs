using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{
    public GameObject[] hearts;
    private int hp_count = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnCollisionEnter(Collision coll) {
        Debug.Log("Collision...");
        if (coll.collider.CompareTag("CUBE")) {
            Destroy(coll.gameObject);
            if (hp_count > 0) {
                hearts[hp_count-1].SetActive(false);
                hp_count--;
            }
        }
    }
}
