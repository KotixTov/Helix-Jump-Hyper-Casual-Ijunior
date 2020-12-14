using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _offsetLenght;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;
        
        TraceBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TraceBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TraceBall()
    {
        var beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _offsetLenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform.position);
    }
}
