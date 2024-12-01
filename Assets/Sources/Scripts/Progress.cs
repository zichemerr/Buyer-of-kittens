using Michsky.MUIP;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private ValueView _valueView;
    [SerializeField] private int[] _rewardsArray;
    [SerializeField] private int _maxValue;

    private Queue<int> _rewards;
    private ClickerZone _clickerZone;
    private int _value;
    private int _level = 1;
    private int _maxLevels;

    public event Action<int> Rewarded;

    public void Init(ClickerZone clickerZone)
    {
        _clickerZone = clickerZone;
        _clickerZone.Clicked += OnClicked;
        _progressBar.maxValue = _maxValue;

        _rewards = new Queue<int>();

        foreach (var rewardsArray in _rewardsArray)
            _rewards.Enqueue(rewardsArray);

        _maxLevels = _rewards.Count + 1;
    }

    private void OnDisable()
    {
        _clickerZone.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        _value++;
        _progressBar.ChangeValue(_value);

        if (_value == (_maxValue + 1))
        {
            _value = 0;
            _progressBar.ChangeValue(_value);
            _level++;
            _valueView.ShowValue(_level);
            Rewarded?.Invoke(_rewards.Dequeue());
        }

        if (_level == _maxLevels)
        {
            _clickerZone.Clicked -= OnClicked;
        }
    }
}
