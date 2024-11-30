public class ClickReward : BuyingProduct
{
    public override void OnBuy()
    {
        base.OnBuy();
        PlayerWallet.BuyClickReward(CurrentProduct.Price, CurrentProduct.Reward);
    }
}