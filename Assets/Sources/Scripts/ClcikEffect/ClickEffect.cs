using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] private EffectSpawner _effectSpawner;
    [SerializeField] private ClickEffectAnimation _animation;
    [SerializeField] private Transform _transform;

    public void Init()
    {
        _effectSpawner.Init(_transform);
    }

    public void Play(int money)
    {
        RewardText rewardText = _effectSpawner.Spawn();
        rewardText.MoneyView.ShowMoney(money, '+');
        _animation.Play(rewardText);
    }
}
