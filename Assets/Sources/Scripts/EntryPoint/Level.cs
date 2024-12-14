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
        foreach (var buyingProducts in _buyingProducts)
            buyingProducts.Init(_playerWallet);

        _player.Init(_clickerZone, _playerWallet);
    }

    [ContextMenu("Play")]
    private void Switch() => YandexGame.SwitchLanguage(_text);
}
