using System;
using System.Collections;
using UnityEngine;
using YG;

public class RewardAd : MonoBehaviour
{
    [SerializeField] private InteractableButton _interactable;
    [SerializeField] private LevelUpEffect _levelUpEffect;
    [SerializeField] private float _delay;

    public event Action<LevelUpEffect> RewardVideo;

    public RewardAd Init()
    {
        _interactable.Enable();
        return this;
    }

    private IEnumerator StartDelayAd()
    {
        yield return new WaitForSeconds(_delay);
        _interactable.Enable();
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += OnRewardVideo;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= OnRewardVideo;
    }

    private void OnRewardVideo(int id)
    {
        RewardVideo?.Invoke(_levelUpEffect);
        _interactable.Disable();
        StartCoroutine(StartDelayAd());
    }

    public void OnShowRewardVideo()
    {
        YandexGame.RewVideoShow(0);
    }
}