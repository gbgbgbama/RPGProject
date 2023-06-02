using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestIinteract : MonoBehaviour
{
    public Animator animator;
    public bool isOpen = false;
    public GameObject text;
    public int gold = 100;

    private void Start()
    {
        text.SetActive(false);
        if (isOpen)
        {
            animator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOpen) text.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isOpen = true;
                animator.SetBool("isOpen", true);
                text.SetActive(false);
                ItemManage.instance.gold += gold;
                gold = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}