using System.Collections.Generic;
using UnityEngine;

public abstract class BuyingProduct : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Product[] _productsArray;

    private Queue<Product> _products;
    public Product CurrentProduct { get; private set; }
    public PlayerWallet PlayerWallet => _playerWallet;

    //public event Action OperationCompleted;

    private void Awake()
    {
        _products = new Queue<Product>();

        foreach (var productsArray in _productsArray)
            _products.Enqueue(productsArray);
    }

    public virtual void OnBuy()
    {
        if (_products.Count <= 0 || _playerWallet.MoneyEnough(_products.Peek().Price) == false)
            return;

        CurrentProduct = _products.Dequeue();
    }
}
