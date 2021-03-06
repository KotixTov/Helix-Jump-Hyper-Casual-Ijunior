using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private StartHandler _startHandler;

    [Header("Start position")]
    [SerializeField] private Vector3 _startDirectionOffset;
    [SerializeField] private float _startOffsetLenght;

    [Header("Gameplay position")]
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _offsetLenght;

    [Space]
    [SerializeField] private float _approachSpeed;

    private bool _cameraApproached = false;
    private bool _gameStarted = false;
    private Ball _ball;
    private Beam _beam;
    private Vector3 _minimumBallPosition;

    private void OnEnable()
    {
        _startHandler.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _startHandler.GameStarted -= OnGameStarted;
    }

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _minimumBallPosition = _ball.transform.position;

        transform.position = TraceBall(_startDirectionOffset, _startOffsetLenght);
        transform.LookAt(_ball.transform.position);
    }

    private void Update()
    {
        if (_gameStarted)
        {
            if (_cameraApproached)
            {
                if (_ball.transform.position.y < _minimumBallPosition.y)
                {
                    transform.position = TraceBall(_directionOffset, _offsetLenght);
                    transform.LookAt(_ball.transform.position);

                    _minimumBallPosition = _ball.transform.position;
                }
            }
            else
            {
                Approach();
            }
        }
    }

    private void Approach()
    {
        transform.position = Vector3.MoveTowards(transform.position, TraceBall(_directionOffset, _offsetLenght), _approachSpeed);
        transform.LookAt(_ball.transform.position);

        if (transform.position == TraceBall(_directionOffset, _offsetLenght))
        {
            _cameraApproached = true;
        }
    }

    private Vector3 TraceBall(Vector3 directionOffset, float offsetLenght)
    {
        var beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        var cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + directionOffset;
        cameraPosition -= direction * offsetLenght;

        return cameraPosition;
    }

    public void OnGameStarted()
    {
        _gameStarted = true;
    }
}
