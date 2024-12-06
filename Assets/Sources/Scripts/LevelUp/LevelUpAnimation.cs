using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[Serializable]
public class LevelUpAnimation
{
    [SerializeField] private Image _image;
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;

    public void Play()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_image.DOFade(_endValue, _duration));        
        sequence.Append(_image.DOFade(0, _duration));
    }
}