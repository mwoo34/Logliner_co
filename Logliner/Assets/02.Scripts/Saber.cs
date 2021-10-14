using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saber : MonoBehaviour
{
    // 컨트롤러로 해당 layer만 베기
    public LayerMask layer;
    private Vector3 previousPos;
    public AudioSource au;
    // Slot객체 받아오는 변수
    public GameObject[] slot;
    // 바꿀 이미지 받아오는 변수
    //public Sprite[] slot_sp;
    public Texture[] slot_tex;
    
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        //slot_tex = GameCtrl.instance.slotTex;
    }

    void Update()
    {
        slot = GameCtrl.instance.slotImages;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            // if (Vector3.Angle(transform.position- previousPos, hit.transform.up) > 130) {
            //     Destroy(hit.transform.gameObject);
            // }
            
            // hit한 순간에 사운드 효과
            au.Play();
            // lock이 true일 때만 진입하고 바로 false로 바꿔서 잠금
            if (GameCtrl.instance._lock)
            {   
                GameCtrl.instance._lock = false;
                // slot의 위치를 가져와서 해당 위치 이미지 교체하는 기능
                int pos = GameCtrl.instance.slotPos;
                Debug.Log("해당 pos 값 : " + pos);
                if (pos < 3 && hit.collider.CompareTag("ITEMBOX")) 
                {
                    slot[pos].GetComponentInChildren<RawImage>().texture = slot_tex[pos];
                    //slot[pos].GetComponent<Image>().sprite = slot_sp[pos];
                    GameCtrl.instance.slotPos += 1;
                }
                // 1초 정도 후에 lock을 false에서 true로 바꿔주는 함수
                StartCoroutine(LockState());
            }
            Destroy(hit.transform.gameObject);
        }
        previousPos = transform.position;
    }

    IEnumerator LockState()
    {
        yield return new WaitForSeconds(1.0f);
        GameCtrl.instance._lock = true;
    }
}
