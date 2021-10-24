using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPLatform : MonoBehaviour
{
    private BoxCollider Collider;
    void Start()
    {
        Collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.SetParent(transform);
    }
}
