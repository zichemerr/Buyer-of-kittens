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
        _progress.Rewarded += ShowRewardEffect;
    }

    private void OnDisable()
    {
        _progress.Rewarded -= ShowRewardEffect;
    }

    public void ShowRewardEffect(int reward)
    {
        RewardText rewardText = _spawner.Spawn(Vector2.zero);
        rewardText.SetScale(new Vector2(2, 2));
        rewardText.MoneyView.ShowMoney(reward, "+");

        _clickAnimation.Play(rewardText);
        _rewardAnimation.Play();
        _clickSound.Play();
    }
}
