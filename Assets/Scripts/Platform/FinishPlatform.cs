using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatform : Platform
{
    private WinText _winText;
    private bool _gameWinned = false;

    private void Start()
    {
        _winText = GameObject.FindGameObjectWithTag("WinText").GetComponent<WinText>();
        _winText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_gameWinned)
        {
            if (other.transform.TryGetComponent(out Ball ball))
            {
                Debug.Log("Win!");
                _winText.gameObject.SetActive(true);
                _gameWinned = true;
            }
        }
    }
}
