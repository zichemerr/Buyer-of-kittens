using System.Collections.Generic;
using UnityEngine;

public abstract class BuyingProduct : MonoBehaviour
{
    [SerializeField] private Product[] _productsArray;
    [SerializeField] private MoneyView _priceView;
    [SerializeField] private InteractableButton _interactionButton;
    [SerializeField] private SoundPlayer _clickSound;

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

        OnValueChanged();
        _priceView.ShowMoney(_products.Peek().Price);
    }

    private void OnDisable()
    {
        _playerWallet.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        if (_products.Count <= 0)
        {
            _interactionButton.Disable();
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
        if (_products.Count <= 0 && _playerWallet.MoneyEnough(_products.Peek().Price) == false)
        {
            _interactionButton.Disable();
            return;
        }

        CurrentProduct = _products.Dequeue();
        _clickSound.Play();

        if (_products.Count > 0)
        {
            _priceView.ShowMoney(_products.Peek().Price);
        }
    }
}
