using System;

[Serializable]
public class PlayerData
{
    public int Money;
    public int RewardPerSecond;
    public int ClickReward;

    public PlayerData SetValues(int money, int rewardPerSecond, int clickReward)
    {
        Money = money;
        RewardPerSecond = rewardPerSecond;
        ClickReward = clickReward;

        return this;
    }
}