using Michsky.MUIP;
using UnityEngine;

public class CatSwitcher : MonoBehaviour
{
    [SerializeField] private AnimationSwitcher _switcher;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private ValueView _valueView;
    [SerializeField] private int _maxScore;
    [SerializeField] private int _maxLevel;

    private int _score;
    private int _level = 1;

    private ClickerZone _clickerZone;

    public void Init(ClickerZone clickerZone)
    {
        _clickerZone = clickerZone;
        _clickerZone.Clicked += OnClicked;
        _progressBar.maxValue = _maxScore;
    }

    private void OnDisable()
    {
        _clickerZone.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        if (_level == _maxLevel)
            return;

        _score++;
        _progressBar.ChangeValue(_score);

        if (_score == (_maxScore + 1))
        {
            _score = 0;
            _progressBar.ChangeValue(_score);
            _level++;
            _valueView.ShowValue(_level);
            _switcher.Switch();
        }
    }
}
