using UnityEngine;
using YG;

public class Level : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ClickerZone _clickerZone;
    [SerializeField] private BuyingProduct[] _buyingProducts;
    [SerializeField] private string _text;

    private void Start()
    {
        //Switch();

        _player.Init(_clickerZone, _playerWallet);

        foreach (var buyingProducts in _buyingProducts)
            buyingProducts.Init(_playerWallet);

    }

    [ContextMenu(nameof(Switch))]
    private void Switch() => YandexGame.SwitchLanguage(_text);
}
