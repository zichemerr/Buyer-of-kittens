public class RewardPerSecond : BuyingProduct
{
    private const string RewardPer = nameof(RewardPer);

    public override void Init(PlayerWallet playerWallet)
    {
        SetDataKey(RewardPer);
        base.Init(playerWallet);
    }

    public override void OnBuy()
    {
        base.OnBuy();
        PlayerWallet.BuyRewardPerSecond(CurrentProduct.Price, CurrentProduct.Reward);
    }
}
