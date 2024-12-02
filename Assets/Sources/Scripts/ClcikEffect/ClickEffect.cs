using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] private EffectSpawner _effectSpawner;
    [SerializeField] private ClickEffectAnimation _animation;

    public void Init(ClickerZone clickerZone)
    {
        _effectSpawner.Init(transform);
        _animation.Init(transform);
    }

    public void Play(int money)
    {
        RewardText rewardText = _effectSpawner.Spawn();
        rewardText.MoneyView.ShowMoney(money, '+');
        _animation.Play(rewardText);
    }
}
