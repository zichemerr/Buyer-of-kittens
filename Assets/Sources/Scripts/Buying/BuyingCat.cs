using UnityEngine;

public class BuyingCat : BuyingProduct
{
    [SerializeField] private AnimationSwitcher _animationSwitcher;

    public void OnBuy()
    {
        Buy();
    }

    public override bool Buy()
    {
        bool buyed = base.Buy();

        if (buyed == false)
            return buyed;

        PlayerWallet.Buy(CurrentProduct.Price);
        _animationSwitcher.Switch();
        return buyed;
    }
}
