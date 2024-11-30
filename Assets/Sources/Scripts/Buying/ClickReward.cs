public class ClickReward : BuyingProduct
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

        PlayerWallet.BuyClickReward(CurrentProduct.Price, CurrentProduct.Reward);
        return buyed;
    }
}