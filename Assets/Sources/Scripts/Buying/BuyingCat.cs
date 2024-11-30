using UnityEngine;

public class BuyingCat : BuyingProduct
{
    [SerializeField] private AnimationSwitcher _animationSwitcher;

    public override void OnBuy()
    {
        base.OnBuy();
        PlayerWallet.Buy(CurrentProduct.Price);
        _animationSwitcher.Switch();
    }
}
