public class RewardPerSecond : BuyingProduct
{
    public void OnBuy()
    {
        Buy();
    }

    public override bool Buy()
    {
        bool buyed = base.Buy();

        if (buyed == false)
            return buyed;

        PlayerWallet.BuyRewardPerSecond(CurrentProduct.Price, CurrentProduct.Reward);
        return buyed;
    }
}
