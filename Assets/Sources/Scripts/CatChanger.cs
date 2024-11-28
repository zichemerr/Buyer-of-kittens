using UnityEngine;

public class CatChanger : MonoBehaviour
{
    [SerializeField] private AnimationSwitcher _switcher;
    [SerializeField] private int _maxScore;

    private ClickerZone _clickerZone;
    private int _score;

    public void Init(ClickerZone clickerZone)
    {
        _clickerZone = clickerZone;
        _clickerZone.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _clickerZone.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        _score++;

        if (_score == _maxScore)
        {
            _score = 0;
            _switcher.Switch();
        }
    }
}
