using DG.Tweening;
using System;
using UnityEngine;

[Serializable]
public class ClickEffectAnimation
{
    [SerializeField] private float _endPositionY;
    [SerializeField] private float _duration;

    public void Play(RewardText reward)
    {
        reward.transform
            .DOMoveY(reward.transform.position.y + _endPositionY, _duration);

        reward.CanvasGroup
            .DOFade(0, _duration)
            .onComplete += () => GameObject.Destroy(reward.gameObject);
    }
}