using Michsky.MUIP;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private ProgressView _valueView;
    [SerializeField] private int[] _rewardsArray;
    [SerializeField] private int _maxValue;

    private Queue<int> _rewards;
    private int _value;
    private int _level = 1;
    private int _maxLevels;

    public event Action<int> Rewarded;

    public void Init(ClickerZone clickerZone)
    {
        _progressBar.maxValue = _maxValue;

        _rewards = new Queue<int>();

        foreach (var rewardsArray in _rewardsArray)
            _rewards.Enqueue(rewardsArray);

        _maxLevels = _rewards.Count + 1;
    }

    public void Add()
    {
        if (_level == _maxLevels)
            return;

        _value++;
        _progressBar.ChangeValue(_value);

        if (_value == _maxValue && _level == (_maxLevels - 1))
        {
            _level++;
            Rewarded?.Invoke(_rewards.Dequeue());
            return;
        }

        if (_value == (_maxValue + 1))
        {
            _level++;
            _valueView.ShowValue(_level);

            _value = 0;
            _progressBar.ChangeValue(_value);
            Rewarded?.Invoke(_rewards.Dequeue());
        }
    }
}
