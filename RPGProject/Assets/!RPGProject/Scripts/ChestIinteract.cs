using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestIinteract : MonoBehaviour
{
    public Animator animator;
    public bool isOpen = false;

    private void Start()
    {
        if (isOpen)
        {
            animator.SetBool("isOpen", true);
        }
    }
}