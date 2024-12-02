using UnityEngine;

public class RewardText : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private MoneyView _moneyView;

    public CanvasGroup CanvasGroup => _canvasGroup;
    public MoneyView MoneyView => _moneyView;

    public void SetPosition(Vector2 positon)
    {
        transform.position = positon;
    }
}