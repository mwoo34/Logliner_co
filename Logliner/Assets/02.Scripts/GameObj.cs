using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObj : MonoBehaviour
{
    public static GameObj instance;

    public GameObject[] slot;
    public GameObject[] uiMsg;
    public GameObject[] terrain;
    public GameObject truck;
    public GameObject target;
    public GameObject xrRig;
    public static int checkGameSuccess;
    private bool autoMove = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (checkGameSuccess > 0 && autoMove)
        {
            autoMove = false;
            //Invoke("AutoMove", 8.0f);
            //AutoMove();
            StartCoroutine(AutoMove());
        }
    }

    IEnumerator AutoMove()
    {
        if (checkGameSuccess == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                slot[i].SetActive(true);
            }
        }
        terrain[checkGameSuccess - 1].SetActive(true);
        target.SetActive(true);
        truck.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        xrRig.GetComponent<MoveTruck>().enabled = true;
        
    }

}
