using System.Collections.Generic;
using UnityEngine;

public abstract class BuyingProduct : MonoBehaviour
{
    [SerializeField] private Product[] _productsArray;
    [SerializeField] private BuyingData _buyingData;
    [SerializeField] private MoneyView _priceView;
    [SerializeField] private InteractableButton _interactionButton;
    [SerializeField] private SoundPlayer _clickSound;

    private PlayerWallet _playerWallet;
    private Queue<Product> _products;
    private JsonSavingSystem<BuyingData> _jsonSaving;
    private string _keyData;

    protected Product CurrentProduct { get; private set; }
    protected PlayerWallet PlayerWallet => _playerWallet;

    public int ProductsCount => _productsArray.Length;
    public int CurrentCount => _products.Count;

    public virtual void Init(PlayerWallet playerWallet)
    {
        _playerWallet = playerWallet;
        _playerWallet.ValueChanged += OnValueChanged;

        _products = new Queue<Product>();
        _jsonSaving = new JsonSavingSystem<BuyingData>();

        if (_jsonSaving.KeyIsNull(_keyData))
        {
            foreach (var productsArray in _productsArray)
                _products.Enqueue(productsArray);
        }
        else
        {
            Product[] products = _jsonSaving.Load(_keyData).Products;

            for (int i = 0; i < products.Length; i++)
                _products.Enqueue(products[i]);
        }

        if (_products.Count > 0)
        {
            _priceView.ShowMoney(_products.Peek().Price);
        }

        OnValueChanged();
    }

    protected void SetDataKey(string key)
    {
        _keyData = key;
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
        _jsonSaving.Save(_keyData, _buyingData.Construct(_products.ToArray(), CurrentProduct));
        _clickSound.Play();

        if (_products.Count > 0)
        {
            _priceView.ShowMoney(_products.Peek().Price);
        }
    }
}
