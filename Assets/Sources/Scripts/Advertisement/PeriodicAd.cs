using UnityEngine;
using TMPro;
using YG;
using System.Collections;

public class PeriodicAd : MonoBehaviour
{
    [SerializeField] private GameObject _warning;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private PlayerWallet _player;
    [SerializeField] private int _startValue;
    [SerializeField] private int _delay;

    private CountingDown _countingDown;

    private void Awake()
    {
        _countingDown = new CountingDown(_text, _startValue);
        StartCoroutine(StartAdTimer());
    }

    private void OnEnable()
    {
        YandexGame.CloseFullAdEvent += OnClose;
        _countingDown.Finished += OnFinished;
    }

    private void OnDisable()
    {
        YandexGame.CloseFullAdEvent -= OnClose;
        _countingDown.Finished -= OnFinished;
    }

    private void OnClose()
    {
        _warning.SetActive(false);
        _player.OnStart();
        StartCoroutine(StartAdTimer());
    }

    private void OnFinished()
    {
        YandexGame.FullscreenShow();
    }

    private IEnumerator StartAdTimer()
    {
        yield return new WaitForSeconds(_delay);
        ShowAd();
    }

    private void ShowAd()
    {
        _player.OnStop();
        _warning.SetActive(true);
        _countingDown.Play(this);
    }
}
