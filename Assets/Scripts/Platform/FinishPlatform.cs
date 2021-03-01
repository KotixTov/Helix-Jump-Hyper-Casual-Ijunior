using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatform : Platform
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out Ball ball))
        {
            Debug.Log("Win!");
        }
    }
}
