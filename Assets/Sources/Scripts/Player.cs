using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerClickSound _clickSound;
    [SerializeField] private ClickerZone _clickerZone;
    [SerializeField] private PlayerAnimaion _animation;

    private PlayerWallet _wallet;

    public void Init(PlayerWallet playerWallet)
    {
        _wallet = playerWallet;
        _wallet.Init(_clickerZone);
        _clickSound.Init();
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
