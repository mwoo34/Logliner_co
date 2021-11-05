using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl4_3 : MonoBehaviour
{
    public GameObject[] fail_illust;
    public GameObject[] success_illust;
    private int pos = 10;
    public GameObject book;
    public AudioSource audioSource;
    public Material _skybox;

    void Start()
    {
        RenderSettings.skybox = _skybox;
        GameManager.Instance.InitXrRigPosition();
        GameManager.Instance.ActivateMovememt(false);

        //GameManager.Instance.InitXrRigPosition();
        GameManager.Instance._XRrig.transform.localEulerAngles = new Vector3(0, 0, 0);
        //StartCoroutine(closeIllust());
        StartCoroutine(ShowImages());
    }

    IEnumerator ShowImages()
    {
        yield return new WaitForSeconds(5.0f);
        if (GameObj.checkGameSuccess == 3)
        {
            for (int i = 0; i < 5; i++)
            {
                fail_illust[i].SetActive(true);
                yield return new WaitForSeconds(3.0f);
                fail_illust[i].SetActive(false);
                yield return new WaitForSeconds(1.0f);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                success_illust[i].SetActive(true);
                yield return new WaitForSeconds(3.0f);
                success_illust[i].SetActive(false);
                yield return new WaitForSeconds(1.0f);
            }
        }
        
        book.GetComponent<Animator>().SetBool("bookAnim", true);
        yield return new WaitForSeconds(3.0f);
        audioSource.Play();
        yield return new WaitForSeconds(1.0f);
        fail_illust[5].SetActive(true);
        fail_illust[6].SetActive(true);
        yield return new WaitForSeconds(7.0f);
        fail_illust[5].SetActive(false);
        fail_illust[6].SetActive(false);
        yield return new WaitForSeconds(1.0f);
        fail_illust[7].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        fail_illust[7].SetActive(false);
        yield return new WaitForSeconds(1.0f);
        //SceneLoader.Instance.LoadNewScene("Chapter00");
    }

    // IEnumerator closeIllust()
    // {
    //     yield return new WaitForSeconds(4.0f);
    //     for (int i = 0; i < 5; i++)
    //     {   
    //         fail_illust[i].SetActive(true);
    //         yield return new WaitForSeconds(1.0f);
    //         fail_illust[i].GetComponent<Animator>().enabled = true;
    //         // true로 활설화 시키면 바로 사진 확대가 되기 때문에 확대되고 잠시 대기
    //         yield return new WaitForSeconds(5.0f);
    //         fail_illust[i].GetComponent<Animator>().SetBool("closeArtwork", true);
    //         yield return new WaitForSeconds(3.0f);
    //     }
    //     for (int i = 0; i < 5; i++)
    //     {
    //         fail_illust[i].SetActive(false);
    //     }
    //     book.GetComponent<Animator>().SetBool("closedBook", true);
    //     StartCoroutine(ShowCredit());
    // }

    // IEnumerator ShowCredit()
    // {
    //     yield return new WaitForSeconds(6.0f);
    //     book.SetActive(false);
    //     fail_illust[5].SetActive(true);
    //     fail_illust[6].SetActive(true);
    //     yield return new WaitForSeconds(5.0f);
    //     fail_illust[5].SetActive(false);
    //     fail_illust[6].SetActive(false);
    //     yield return new WaitForSeconds(2.0f);
    //     fail_illust[7].SetActive(true);
    //     yield return new WaitForSeconds(5.0f);
    //     fail_illust[7].SetActive(false);
    //     yield return new WaitForSeconds(1.0f);
    //     fail_illust[8].SetActive(true);
    // }
}
