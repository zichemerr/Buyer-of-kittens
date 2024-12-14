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
        _progress.Rewarded += OnShowRewardEffect;
    }

    private void OnDisable()
    {
        _progress.Rewarded -= OnShowRewardEffect;
    }

    private void OnShowRewardEffect(int reward)
    {
        ShowRewardEffect(reward, "+");
    }

    public void ShowRewardEffect(int reward)
    {
        ShowRewardEffect(reward, "");
    }

    public void ShowRewardEffect(int reward, string prefix)
    {
        RewardText rewardText = _spawner.Spawn(Vector2.zero);
        rewardText.SetScale(new Vector2(1.5f, 1.5f));
        rewardText.MoneyView.ShowMoney(reward, prefix);

        _clickAnimation.Play(rewardText);
        _rewardAnimation.Play();
        _clickSound.Play();
    }
}
