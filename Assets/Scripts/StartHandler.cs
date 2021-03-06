using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartHandler : MonoBehaviour
{
    private bool _gameStarted;

    public event UnityAction GameStarted;

    private void Update()
    {
        if (!_gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStarted?.Invoke();
                _gameStarted = true;
            }
        }
    }
}
