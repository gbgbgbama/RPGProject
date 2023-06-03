using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public GameObject wuDing;
    public GameObject jiaJv;

    // Start is called before the first frame update
    private void Start()
    {
        wuDing.SetActive(true);
        jiaJv.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wuDing.SetActive(false);
            jiaJv.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wuDing.SetActive(true);
            jiaJv.SetActive(false);
        }
    }
}