using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private BuyingProduct[] _buyingProducts;

    private void Start()
    {
        _player.Init(_playerWallet);

        foreach (var buyingProducts in _buyingProducts)
            buyingProducts.Init(_playerWallet);
    }
}