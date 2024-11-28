using UnityEngine;
using TMPro;

public class ValueView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _valueText;

    public void ShowValue(int value)
    {
        foreach (var valueText in _valueText)
            valueText.text = $"{value}$";
    }
}