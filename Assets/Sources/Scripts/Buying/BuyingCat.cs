using UnityEngine;

public class BuyingCat : BuyingProduct
{
    private const string CatData = nameof(CatData);

    [SerializeField] private AnimationSwitcher _animationSwitcher;

    public int BuyedCats => ProductsCount - CurrentCount;

    public override void Init(PlayerWallet playerWallet)
    {
        SetDataKey(CatData);
        base.Init(playerWallet);
    }

    public override void OnBuy()
    {
        base.OnBuy();
        PlayerWallet.Buy(CurrentProduct.Price);
        _animationSwitcher.Switch();
    }
}
