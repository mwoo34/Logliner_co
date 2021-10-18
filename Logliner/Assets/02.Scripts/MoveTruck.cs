using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTruck : MonoBehaviour
{
    public enum State
    {
        IDLE,
        TRACE
    }

    public State state = State.IDLE;

    public Transform playerTr;
    public Transform landTr;
    public NavMeshAgent agent;
    public float lookUpDist = 45.0f;
    public GameObject leftController;
    public GameObject rightController;
    public GameObject noticeMsg1;
    public GameObject terrain;
    public GameObject landfill;
    public GameObject[] slot;
    private RectTransform slotRectTrans;

    //public float stopDist = 10.0f;
    public float traceDist = 1.0f;
    public float msgDist = 2.0f;
    private bool moveState = false;

    void Start()
    {
        playerTr = GetComponent<Transform>();
        landTr = GameObject.FindWithTag("LANDFILL").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        this.gameObject.GetComponent<NavMeshAgent>().enabled = true;
        playerTr.transform.SetPositionAndRotation(new Vector3(16.0f, 2.0f, 7.0f), Quaternion.Euler(0f, 45.0f, 0f));
        leftController.SetActive(false);
        rightController.SetActive(false);
        int pos = GameObj.checkGameSuccess;
        noticeMsg1 = GameObj.instance.uiMsg[pos - 1];
        terrain.SetActive(true);
        landfill.SetActive(true);
        this.gameObject.GetComponent<AudioSource>().enabled = true;
        for (int i = 0; i < 3; i++)
        {
            slot[i].SetActive(true);
        }
        StartCoroutine(PlayerBehaviour());
    }

    void Update()
    {
        if (agent.remainingDistance >= 2.0f)
        {
            Vector3 direction = agent.desiredVelocity;

            if (direction.sqrMagnitude >= 0.1f * 0.1f)
            {
                Quaternion rot = Quaternion.LookRotation(direction);
                playerTr.rotation = Quaternion.Slerp(playerTr.rotation, rot, Time.deltaTime * 10.0f);
            }
        }
    }

    IEnumerator PlayerBehaviour()
    {
        CheckPlayerState();
        PlayerAction();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(PlayerBehaviour());
    }

    void CheckPlayerState()
    {
        float distance = Vector3.Distance(landTr.position, playerTr.position);
        if (distance <= 2.0f)
        {
            state = State.IDLE;
        }
        else
        {
            state = State.TRACE;
        }
    }

    void PlayerAction()
    {
        switch (state)
        {
            case State.IDLE:
                agent.isStopped = true;
                moveState = true;
                StopAllCoroutines();
                StartCoroutine(NoticeMsg());
                break;
            case State.TRACE:
                agent.SetDestination(landTr.position);
                agent.isStopped = false;
                break;
        }
    }

    IEnumerator NoticeMsg()
    {
        yield return new WaitForSeconds(1.0f);
        noticeMsg1.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        noticeMsg1.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        //noticeMsg1.SetActive(false);
        //ChangeScene();
        if (GameObj.checkGameSuccess == 2)
            StartCoroutine(ZoomSlot());
        else if (GameObj.checkGameSuccess == 1)
            ChangeScene();
    }

    IEnumerator ZoomSlot()
    {
        //Vector3 playerPos = new Vector3(playerTr.transform.localPosition.x + 0.83f, playerTr.transform.localPosition.y, playerTr.transform.localPosition.z + 6.5f);
        // Quaternion(0,-0.355803162,0,0.934561014)
        // Vector3(0,318.314636,0)
        // Vector3(0,0,0)
        Quaternion qPlayerOri = transform.rotation;
        Vector3 vPlayerOri = qPlayerOri.eulerAngles;
        
        for (int i = 0; i < 3; i++) 
        {
            yield return new WaitForSeconds(2.0f);
            slot[i].SetActive(false);
            yield return new WaitForSeconds(1.0f);
            slot[i + 3].SetActive(true);
            // slot[i].transform.SetPositionAndRotation(new Vector3(
            // slot[i].transform.position.x - 16.0f,
            // slot[i].transform.position.y - 8.6f,
            // slot[i].transform.position.z - 17.0f),
            // Quaternion.Euler(0.0f, 0.0f, 0.0f)
            // slot[i].transform.SetPositionAndRotation(playerPos, Quaternion.Euler(new Vector3(0, playerTr.transform.localRotation.y, 0))
            // );
            //double gap = 4.5 * i;
            // Vector3 playerPos = new Vector3(playerTr.transform.localPosition.x, playerTr.transform.localPosition.y, playerTr.transform.localPosition.z + 5.5f);
            // slotRectTrans = slot[i].GetComponent<RectTransform>();
            // Debug.Log("슬롯 위치 : " + slotRectTrans.transform.position.x);
            // slotRectTrans.SetPositionAndRotation(playerPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            // slotRectTrans.transform.Rotate(vPlayerOri);
            //playerPos.x += gap;
            //slotRectTrans.transform.Rotate(new Vector3(0.0f, this.gameObject.transform.rotation.y, 0f));
            //Debug.Log(this.gameObject.transform.rotation.y);
            
            //Vector3 posY = Quaternion.Euler(this.gameObject.transform.rotation.y);
            //Quaternion posY = Quaternion.LookRotation(transform.forward, )
            //slotRectTrans.localRotation.Set(0, 0, 0, 0);
        }

        //Debug.Log("슬롯 위치 값 : " + slot[0].transform.position.x + " " + slot[0].transform.position.y + " " + slot[0].transform.position.z);
        //Debug.Log("XR Rig 위치 값 : " + playerTr.transform.localPosition.x + " " + playerTr.transform.localPosition.y + " " + playerTr.transform.localPosition.z);
    }

    void ChangeScene() {
        terrain.SetActive(false);
        landfill.SetActive(false);
        playerTr.transform.SetPositionAndRotation(new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
        this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        if (GameObj.checkGameSuccess == 1)
        {
            SceneLoader.Instance.LoadNewScene("Chapter04_0");
        }
        else if (GameObj.checkGameSuccess == 2)
        {
            SceneLoader.Instance.LoadNewScene("Chapter04_0");
        }
    }
}
