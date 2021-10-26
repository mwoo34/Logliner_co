using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlanet : MonoBehaviour
{
    public GameObject planet;
    public Transform planetTr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        planet.transform.position += Vector3.up * Time.deltaTime;
    }
}
