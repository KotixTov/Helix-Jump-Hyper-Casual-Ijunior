using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlatformSegment platformSegment))
        {
            other.GetComponentInParent<Platform>().Break();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out FinishPlatform finishPlatform))
        {
            Debug.Log("Win!");
        }
    }
}
