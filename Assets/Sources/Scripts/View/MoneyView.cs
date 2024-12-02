using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _moneyText;

    public void ShowMoney(int money, char prefix)
    {
        ShowValue($"{prefix}{money}$");
    }

    public void ShowMoney(int money)
    {
        ShowValue($"{money}$");
    }

    private void ShowValue(string text)
    {
        foreach (var valueText in _moneyText)
            valueText.text = text;
    }
}
