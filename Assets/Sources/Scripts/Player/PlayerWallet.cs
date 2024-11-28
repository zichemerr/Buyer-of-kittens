﻿using UnityEngine;
using System;
using System.Collections;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private ValueView _scoreView;
    [SerializeField] private ValueView _rewarPerSecondView;
    [SerializeField] private int _clickPrice;
    [SerializeField] private int _rewardPerSecond;

    private ClickerZone _clickerZone;
    private int _money;

    public event Action<int> ValueChanged;

    public void Init(ClickerZone clickerZone)
    {
        _clickerZone = clickerZone;
        _clickerZone.Clicked += OnClicked;
        StartCoroutine(GetReward());
    }

    private void OnDisable()
    {
        _clickerZone.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        _money += _clickPrice;
        ValueChanged?.Invoke(_money);
        _scoreView.ShowValue(_money);
    }

    private IEnumerator GetReward()
    {
        yield return new WaitForSeconds(1);
        _money += _rewardPerSecond;
        ValueChanged?.Invoke(_money);
        _scoreView.ShowValue(_money);
        StartCoroutine(GetReward());
    }

    private bool Buy(int price, int reward)
    {
        if (price > _money)
            return false;

        if (reward < 0)
            throw new ArgumentOutOfRangeException(nameof(reward));

        _money -= price;
        ValueChanged?.Invoke(_money);
        return true;
    }

    public bool BuyClickReward(int price, int clickReward)
    {
        if (Buy(price, clickReward))
        {
            _clickPrice += clickReward;
            _scoreView.ShowValue(_money);
            return true;
        }

        return false;
    }

    public bool BuyRewardPerSecond(int price, int rewardPerSecond)
    {
        if (Buy(price, rewardPerSecond))
        {
            _scoreView.ShowValue(_money);
            _rewardPerSecond += rewardPerSecond;
            _rewarPerSecondView.ShowValue(_rewardPerSecond);
            return true;
        }

        return false;
    }

    public bool MoneyEnough(int price)
    {
        if (price > _money)
            return false;

        return true;
    }
}