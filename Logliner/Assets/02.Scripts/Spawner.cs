using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60 / 105) * 2;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameCtrl.instance.heartCount == 0) {
            gameObject.SetActive(false);
        }
        if (timer > beat && GameCtrl.instance.heartCount > 0) {
            GameObject cube = Instantiate(cubes[Random.Range(0, 3)], points[Random.Range(0, 3)]);
            cube.transform.localPosition = Vector3.zero;
            //cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            //cube.transform.Rotate(transform.forward);
            timer -= beat;
        }
        timer += Time.deltaTime;
        
    }
}
