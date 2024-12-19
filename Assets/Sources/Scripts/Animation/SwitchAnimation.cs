using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SwitchAnimation
{
    [SerializeField] private Image _image;
    [SerializeField] private float _time;

    public void Disable()
    {
        Color color = _image.color;
        _image.color = new Color(color.r, color.g, color.b, 0);
    }

    public void PlayEnable()
    {
        _image.DOFade(1, _time);
    }
}