using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinText : MonoBehaviour
{
    private bool _gameStarted = false;
    private TextAnimator animator;

    private void Start()
    {
        animator = GetComponent<TextAnimator>();

        animator.StartAnimation();
    }
}
