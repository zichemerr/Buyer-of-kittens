using System.Collections;
using System;
using TMPro;
using UnityEngine;

public class CountingDown
{
    private TMP_Text _value;
    private int _startValue;

    public event Action Finished;

    public CountingDown(TMP_Text text, int startValue)
    {
        _value = text;
        _startValue = startValue;
    }

    public void Play(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(StartAd());
    }

    private IEnumerator StartAd()
    {
        _value.text = _startValue.ToString();
        _startValue--;
        yield return new WaitForSeconds(1);
        _value.text = _startValue.ToString();
        yield return new WaitForSeconds(1);
        Finished?.Invoke();
    }
}