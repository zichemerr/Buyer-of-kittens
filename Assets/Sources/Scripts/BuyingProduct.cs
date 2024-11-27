using System.Collections.Generic;
using UnityEngine;

public abstract class BuyingProduct : MonoBehaviour
{
    [SerializeField] private Product[] _productsArray;
    [SerializeField] private ValueView _priceView;
    [SerializeField] private InteractableButton _interactionButton;

    private PlayerWallet _playerWallet;
    private Queue<Product> _products;

    protected Product CurrentProduct { get; private set; }
    protected PlayerWallet PlayerWallet => _playerWallet;

    public void Init(PlayerWallet playerWallet)
    {
        _playerWallet = playerWallet;
        _playerWallet.ValueChanged += OnValueChanged;
        _products = new Queue<Product>();

        foreach (var productsArray in _productsArray)
            _products.Enqueue(productsArray);

        OnValueChanged(0);
        _priceView.ShowValue(_products.Peek().Price);
    }

    private void OnDisable()
    {
        _playerWallet.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int money)
    {
        if (_products.Count <= 0)
        {
            SetButton(CurrentProduct.Price);
            return;
        }

        SetButton(_products.Peek().Price);
    }

    private void SetButton(int price)
    {
        if (_playerWallet.MoneyEnough(price))
            _interactionButton.Enable();
        else
            _interactionButton.Disable();
    }

    public virtual void OnBuy()
    {
        if (_products.Count <= 0 || _playerWallet.MoneyEnough(_products.Peek().Price) == false)
            return;

        CurrentProduct = _products.Dequeue();

        if (_products.Count > 0)
            _priceView.ShowValue(_products.Peek().Price);
    }
}
