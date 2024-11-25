using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerClickSound _clickSound;
    [SerializeField] private ClickerZone _clickerZone;
    [SerializeField] private PlayerAnimaion _animation;

    public void Init()
    {
        _wallet.Init(_clickerZone);
        _animation.Init();
    }

    private void OnEnable()
    {
        _clickerZone.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _clickerZone.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        _clickSound.Play();
        _animation.Play();
    }
}
