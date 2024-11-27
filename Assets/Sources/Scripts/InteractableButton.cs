using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Enable()
    {
        SetGroup(true, 1f);
    }

    public void Disable()
    {
        SetGroup(false, 0.2f);
    }

    private void SetGroup(bool blocksRaycasts, float alpha)
    {
        _canvasGroup.blocksRaycasts = blocksRaycasts;
        _canvasGroup.alpha = alpha;
    }
}
