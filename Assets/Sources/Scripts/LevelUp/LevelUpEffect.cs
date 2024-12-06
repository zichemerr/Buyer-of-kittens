using UnityEngine;

public class LevelUpEffect : MonoBehaviour
{
    [SerializeField] private EffectSpawner _spawner;
    [SerializeField] private ClickEffectAnimation _clickAnimation;
    [SerializeField] private LevelUpAnimation _rewardAnimation;
    [SerializeField] private SoundPlayer _clickSound;
    [SerializeField] private Transform _transfrom;

    private Progress _progress;

    public void Init(Progress progress)
    {
        _spawner.Init(_transfrom);
        _progress = progress;
        _progress.Rewarded += OnRewarded;
    }

    private void OnDisable()
    {
        _progress.Rewarded -= OnRewarded;
    }

    private void OnRewarded(int reward)
    {
        RewardText rewardText = _spawner.Spawn(Vector2.zero);
        rewardText.SetScale(new Vector2(1.5f, 1.5f));
        rewardText.MoneyView.ShowMoney(reward, '+');

        _clickAnimation.Play(rewardText);
        _rewardAnimation.Play();
        _clickSound.Play();
    }
}
