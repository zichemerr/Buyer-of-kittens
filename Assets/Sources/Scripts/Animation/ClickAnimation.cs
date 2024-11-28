﻿using UnityEngine;
using DG.Tweening;

public class ClickAnimation
{
    private readonly Transform _transform;
    private readonly Vector3 _scale;
    private readonly float _duration;

    private Vector2 _defaultScale;
    private Vector2 _newScale;
    private Sequence _sequence;

    public ClickAnimation(Transform transform, Vector3 scale, float duration)
    {
        _transform = transform;
        _scale = scale;
        _duration = duration;
        _defaultScale = transform.localScale;
        _newScale = transform.localScale + scale;
    }

    public void Play()
    {
        _sequence = DOTween.Sequence();

        _sequence.Append(_transform.DOScale(_newScale, _duration));
        _sequence.onComplete += PlayUp;
    }

    private void PlayUp()
    {
        _transform.DOScale(_defaultScale, _duration);
    }
}