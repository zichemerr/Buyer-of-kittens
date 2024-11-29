using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ClickSound _clickSound;
    [SerializeField] private PlayerAnimaion _animation;

    private ClickerZone _clickerZone;
    private PlayerWallet _wallet;

    public void Init(ClickerZone clickerZone, PlayerWallet playerWallet)
    {
        _clickerZone = clickerZone;
        _clickerZone.Clicked += OnClicked;

        _wallet = playerWallet;
        _wallet.Init(_clickerZone);

        _animation.Init();
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
