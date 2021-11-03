using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl4_3 : MonoBehaviour
{
    public GameObject[] illustrations;
    private int pos = 10;
    public GameObject book;
    public AudioSource audioSource;

    void Start()
    {
        //StartCoroutine(closeIllust());
        StartCoroutine(ShowImages());
    }

    IEnumerator ShowImages()
    {
        yield return new WaitForSeconds(5.0f);
        for (int i = 0; i < 6; i++)
        {
            illustrations[i].SetActive(true);
            yield return new WaitForSeconds(3.0f);
            illustrations[i].SetActive(false);
            yield return new WaitForSeconds(1.0f);
        }
        book.GetComponent<Animator>().SetBool("bookAnim", true);
        yield return new WaitForSeconds(3.0f);
        audioSource.Play();
        yield return new WaitForSeconds(1.0f);
        illustrations[6].SetActive(true);
        illustrations[7].SetActive(true);
        yield return new WaitForSeconds(7.0f);
        illustrations[6].SetActive(false);
        illustrations[7].SetActive(false);
        yield return new WaitForSeconds(1.0f);
        illustrations[8].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        illustrations[8].SetActive(false);
        yield return new WaitForSeconds(1.0f);
        illustrations[9].SetActive(true);
    }

    IEnumerator closeIllust()
    {
        yield return new WaitForSeconds(4.0f);
        for (int i = 0; i < 5; i++)
        {   
            illustrations[i].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            illustrations[i].GetComponent<Animator>().enabled = true;
            // true로 활설화 시키면 바로 사진 확대가 되기 때문에 확대되고 잠시 대기
            yield return new WaitForSeconds(5.0f);
            illustrations[i].GetComponent<Animator>().SetBool("closeArtwork", true);
            yield return new WaitForSeconds(3.0f);
        }
        for (int i = 0; i < 5; i++)
        {
            illustrations[i].SetActive(false);
        }
        book.GetComponent<Animator>().SetBool("closedBook", true);
        StartCoroutine(ShowCredit());
    }

    IEnumerator ShowCredit()
    {
        yield return new WaitForSeconds(6.0f);
        book.SetActive(false);
        illustrations[5].SetActive(true);
        illustrations[6].SetActive(true);
        yield return new WaitForSeconds(5.0f);
        illustrations[5].SetActive(false);
        illustrations[6].SetActive(false);
        yield return new WaitForSeconds(2.0f);
        illustrations[7].SetActive(true);
        yield return new WaitForSeconds(5.0f);
        illustrations[7].SetActive(false);
        yield return new WaitForSeconds(1.0f);
        illustrations[8].SetActive(true);
    }
}
