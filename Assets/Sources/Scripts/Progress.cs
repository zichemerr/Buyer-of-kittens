using Michsky.MUIP;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    private const string ProgressData = nameof(ProgressData);

    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private ProgressView _valueView;
    [SerializeField] private ProgressData _progressData;

    private Queue<int> _rewards;
    private JsonSavingSystem<ProgressSavingData> _jsonSaving;
    private ProgressSavingData _data;
    private int _value;
    private int _level = 1;
    private int _maxLevels;
    private int _maxValue;

    public event Action<int> Rewarded;

    public void Init()
    {
        _jsonSaving = new JsonSavingSystem<ProgressSavingData>();
        _rewards = new Queue<int>();

        if (_jsonSaving.KeyIsNull(ProgressData))
            _data = new ProgressSavingData(_progressData.RewardsArray, _progressData.Value, _progressData.Level);
        else
            _data = _jsonSaving.Load(ProgressData);

        foreach (var reward in _data.Rewards)
            _rewards.Enqueue(reward);

        _value = _data.Value;
        _level = _data.Level;
        _maxValue = _progressData.MaxValue;
        _progressBar.maxValue = _maxValue;
        _maxLevels = _progressData.RewardsArray.Length + 1;

        _progressBar.ChangeValue(_value);
        _valueView.ShowValue(_level);
    }

    public void Add()
    {
        if (_level == _maxLevels)
            return;

        if (_value == _maxValue && _level == (_maxLevels - 1))
        {
            _level++;
            _valueView.ShowValue(_level);
            Rewarded?.Invoke(_rewards.Dequeue());
            Save();
            return;
        }

        _value++;
        Save();
        _progressBar.ChangeValue(_value);

        if (_value == (_maxValue + 1))
        {
            _level++;
            _valueView.ShowValue(_level);

            _value = 0;
            _progressBar.ChangeValue(_value);
            Rewarded?.Invoke(_rewards.Dequeue());
            Save();
        }
    }

    public void Save()
    {
        _jsonSaving.Save(ProgressData, new ProgressSavingData(_rewards.ToArray(), _value, _level));
    }
}
