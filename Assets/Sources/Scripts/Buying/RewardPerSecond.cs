public class RewardPerSecond : BuyingProduct
{
    public override void OnBuy()
    {
        base.OnBuy();
        PlayerWallet.BuyRewardPerSecond(CurrentProduct.Price, CurrentProduct.Reward);
    }
}
