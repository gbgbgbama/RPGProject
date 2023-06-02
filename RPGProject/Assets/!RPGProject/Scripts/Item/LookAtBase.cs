using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBase : MonoBehaviour
{
    public Transform trage;

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(trage);
    }
}