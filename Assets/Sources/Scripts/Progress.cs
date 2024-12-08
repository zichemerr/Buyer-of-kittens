using Michsky.MUIP;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    private const string ProgressData = nameof(ProgressData);

    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private ProgressView _valueView;
    [SerializeField] private ProgressData _data;
    [SerializeField] private int[] _rewardsArray;
    [SerializeField] private int _maxValue;

    private Queue<int> _rewards;
    private JsonSavingSystem<ProgressData> _jsonSaving;
    private int _value;
    private int _level = 1;
    private int _maxLevels;

    public event Action<int> Rewarded;

    public void Init(ClickerZone clickerZone)
    {
        _jsonSaving = new JsonSavingSystem<ProgressData>();

        if (_jsonSaving.KeyIsNull(ProgressData) == false)
            _data = new JsonSavingSystem<ProgressData>().Load(ProgressData);

        _value = _data.Value;
        _level = _data.Level;

        _rewards = new Queue<int>();
        _progressBar.maxValue = _maxValue;

        foreach (var rewardsArray in _rewardsArray)
            _rewards.Enqueue(rewardsArray);

        _maxLevels = _rewards.Count + 1;
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
            Save();
            _valueView.ShowValue(_level);

            _value = 0;
            Save();
            _progressBar.ChangeValue(_value);
            Rewarded?.Invoke(_rewards.Dequeue());
        }
    }

    public void Save()
    {
        _jsonSaving.Save(ProgressData, _data.SetValues(_value, _level));
    }
}
