using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ClickSound _clickSound;
    [SerializeField] private PlayerAnimaion _animation;
    [SerializeField] private ClickEffect _clickEffect;
    [SerializeField] private Progress _progress;

    private ClickerZone _clickerZone;
    private PlayerWallet _wallet;

    public void Init(ClickerZone clickerZone, PlayerWallet playerWallet)
    {
        _clickerZone = clickerZone;

        _progress.Init(_clickerZone);
        _clickEffect.Init(_clickerZone);
        _animation.Init();

        _wallet = playerWallet;
        _wallet.Init(_clickerZone);

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
        _clickEffect.Play(_wallet.ClickPrice);
        _progress.Add();
    }
}
