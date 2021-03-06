using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StartText : MonoBehaviour
{
    [SerializeField] private StartHandler _startHandler;

    private bool _gameStarted = false;
    private TextAnimator animator;

    private void OnEnable()
    {
        _startHandler.GameStarted += OnGameStarted;
    }

    private void OnGameStarted()
    {
        _gameStarted = true;
    }

    private void OnDisable()
    {
        _startHandler.GameStarted -= OnGameStarted;
    }

    private void Start()
    {
        animator = GetComponent<TextAnimator>();

        animator.StartAnimation();
    }

    private void Update()
    {
        if (_gameStarted)
        {
            animator.StartDisappearingAnimation();
        }
    }
}
