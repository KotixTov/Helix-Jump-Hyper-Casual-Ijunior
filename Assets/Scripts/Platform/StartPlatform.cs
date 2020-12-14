using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;
    void Awake()
    {
        Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
    }
}
