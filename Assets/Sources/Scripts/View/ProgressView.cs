using UnityEngine;
using TMPro;

public class ProgressView : MonoBehaviour
{
    [SerializeField] private TMP_Text _progressText;

    public void ShowValue(int level)
    {
        _progressText.text = $"Уровень {level}";
    }
}