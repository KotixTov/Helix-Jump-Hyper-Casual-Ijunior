using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextAnimator : MonoBehaviour
{
    [Header("Rotation Animation")]
    [SerializeField] private float _rotationAmplitude;
    [SerializeField] private float _rotationDuration;

    [Header("Scale Animation")]
    [SerializeField] private float _scaleAmplitude;
    [SerializeField] private float _scaleDuration;

    [Header("Disappearing Animation")]
    [SerializeField] private float _xMoving;
    [SerializeField] private float _disappearingDuration;

    public void StartAnimation()
    {
        transform.Rotate(-Vector3.forward * _rotationAmplitude / 2);
        transform.DORotate(Vector3.forward * _rotationAmplitude, _rotationDuration, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Yoyo);
        transform.DOScale(_scaleAmplitude, _scaleDuration).SetLoops(-1, LoopType.Yoyo);
    }

    public void StartDisappearingAnimation()
    {
        transform.DOMoveY(_xMoving, _disappearingDuration);
    }
}
