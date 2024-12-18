using UnityEngine;
using System;
using System.Collections;

public class PlayerWallet : MonoBehaviour
{
    private const string PlayerData = nameof(PlayerData);

    [SerializeField] private MoneyView _scoreView;
    [SerializeField] private MoneyView _rewarPerSecondView;
    [SerializeField] private Progress _progress;
    [SerializeField] private RewardAd _rewardAd;

    [Header("DefaultValues"), Space(5)]
    [SerializeField] private PlayerData _playerData;

    private ClickerZone _clickerZone;
    private JsonSavingSystem<PlayerData> _jsonSaving;
    private int _money;
    private int _clickPrice;
    private int _rewardPerSecond;
    private bool _adIsActive = false;

    public event Action ValueChanged;

    public int ClickPrice => _clickPrice;

    public void Init(ClickerZone clickerZone)
    {
        _jsonSaving = new JsonSavingSystem<PlayerData>();

        if (_jsonSaving.KeyIsNull(PlayerData) == false)
            _playerData = _jsonSaving.Load(PlayerData);

        _money = _playerData.Money;
        _rewardPerSecond = _playerData.RewardPerSecond;
        _clickPrice = _playerData.ClickReward;

        _scoreView.ShowMoney(_money);
        _rewarPerSecondView.ShowMoney(_rewardPerSecond);

        _rewardAd.Init().RewardVideo += OnRewardVideo;
        _clickerZone = clickerZone;
        _clickerZone.Clicked += OnClicked;
        StartCoroutine(GetReward());
    } 

    private void OnEnable() => _progress.Rewarded += OnRewarded;

    private void OnDisable()
    {
        _clickerZone.Clicked -= OnClicked;
        _progress.Rewarded -= OnRewarded;
    }

    private void OnClicked()
    {
        ChangeMoney(_clickPrice);
    }

    private void OnRewarded(int reward)
    {
        if (reward < 0)
            throw new ArgumentOutOfRangeException(nameof(reward));

        ChangeMoney(reward);
    }

    private void OnRewardVideo(LevelUpEffect levelUpEffect)
    {
        levelUpEffect.ShowRewardEffect(_money);
        ChangeMoney(_money);
    }

    private IEnumerator GetReward()
    {
        if (_adIsActive)
            yield break;

        yield return new WaitForSeconds(1);
        ChangeMoney(_rewardPerSecond);
        StartCoroutine(GetReward());
    }

    private void ChangeMoney(int value)
    {
        _money += value;
        _scoreView.ShowMoney(_money);
        Save();
        ValueChanged?.Invoke();
    }

    private void Save() => _jsonSaving.Save(PlayerData,
        _playerData.SetValues(_money, _rewardPerSecond, _clickPrice));

    public bool Buy(int price, int reward)
    {
        if (reward < 0)
            throw new ArgumentOutOfRangeException(nameof(reward));

        return Buy(price);
    }

    public bool Buy(int price)
    {
        if (price > _money)
            return false;

        ChangeMoney(-price);
        return true;
    }

    public void BuyClickReward(int price, int clickReward)
    {
        if (Buy(price, clickReward) == false)
            return;

        _clickPrice += clickReward;
    }

    public void BuyRewardPerSecond(int price, int rewardPerSecond)
    {
        if (Buy(price, rewardPerSecond) == false)
            return;

        _rewardPerSecond += rewardPerSecond;
        Save();
        _rewarPerSecondView.ShowMoney(_rewardPerSecond);
    }

    public bool MoneyEnough(int price)
    {
        if (price > _money)
            return false;

        return true;
    }

    [ContextMenu("Stop")]
    public void OnStop()
    {
        StopCoroutine(GetReward());
        _adIsActive = true;
    }

    [ContextMenu("Start")]
    public void OnStart()
    {
        _adIsActive = false;
        StartCoroutine(GetReward());
    }
}
