using System.Collections.Generic;
using UnityEngine;

public class BuyingProduct : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private Product[] _productsArray;

    private Queue<Product> _products;

    //public event Action OperationCompleted;

    private void Awake()
    {
        _products = new Queue<Product>();

        foreach (var productsArray in _productsArray)
            _products.Enqueue(productsArray);
    }

    public void OnBuy()
    {
        if (_products.Count <= 0)
            return;

        Product product = _products.Peek();

        bool buy = _wallet.BuyClickReward(product.Price, product.Reward);

        if (buy)
        {
            _products.Dequeue();
            //OperationCompleted?.Invoke();
        }
    }
}
