using System;
using UnityEngine;
using DG.Tweening;

[Serializable]
public class SwingAnimation
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Ease _ease;
    [SerializeField] private float _rotateAngle;
    [SerializeField] private float _duration;

    private Sequence _sequence;
    private Vector3 _rotation;

    public void Init()
    {
        _sequence = DOTween.Sequence();
        _rotation = new Vector3(0, 0, _rotateAngle);
    }

    public void Play()
    {
        _transform.DORotate(_rotation, _duration)
            .SetEase(_ease).onComplete += () => 
                _transform.DORotate(-_rotation, _duration)
                .SetEase(_ease)
                .onComplete += Play;
    }
}