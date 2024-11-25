using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;

    public void ShowValue(int value)
    {
        _valueText.text = $"{value}$";
    }
}