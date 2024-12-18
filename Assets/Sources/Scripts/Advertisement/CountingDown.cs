using System.Collections;
using System;
using TMPro;
using UnityEngine;

public class CountingDown
{
    private TMP_Text _value;

    public event Action Finished;

    public CountingDown(TMP_Text text)
    {
        _value = text;
    }

    public void Play(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(StartAd());
    }

    private IEnumerator StartAd()
    {
        _value.text = 2.ToString();
        yield return new WaitForSeconds(1);
        _value.text = 1.ToString();
        yield return new WaitForSeconds(1);
        Finished?.Invoke();
    }
}