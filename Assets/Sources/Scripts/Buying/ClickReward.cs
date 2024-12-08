using UnityEngine;

public class ClickReward : BuyingProduct
{
    private const string ClickData = nameof(ClickData);

    public override void Init(PlayerWallet playerWallet)
    {
        SetDataKey(ClickData);
        base.Init(playerWallet);
    }

    public override void OnBuy()
    {
        base.OnBuy();
        PlayerWallet.BuyClickReward(CurrentProduct.Price, CurrentProduct.Reward);
    }
}