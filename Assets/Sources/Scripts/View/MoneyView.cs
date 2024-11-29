using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _moneyText;

    public void ShowMoney(int money)
    {
        foreach (var valueText in _moneyText)
            valueText.text = $"{money}$";
    }
}
